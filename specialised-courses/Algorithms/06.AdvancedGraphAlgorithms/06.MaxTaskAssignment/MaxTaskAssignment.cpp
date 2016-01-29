#ifndef _LIBS_NAMESPACES

#include <stdio.h>
#include <stdlib.h>
#include <limits.h>
#include <iostream>
#include <sstream>
#include <iomanip>

using namespace std;

#endif // _LIBS_NAMESPACES

#ifndef _LOCAL_CONSTANTS

#define MAX_DATA 50
#define VERTICES_COUNT (tasksCount + peopleCount + 2)
#define MAX_EDGES ((tasksCount * peopleCount) + \
                  (tasksCount + peopleCount))

#define PREDECESSORS_COUNT(index) (vertices[index].predecessorEdgesCount)
#define SUCCESSORS_COUNT(index) (vertices[index].successorEdgesCount)

#define TASK_INDEX(index) (peopleCount + index)
#define SOURCE_INDEX (VERTICES_COUNT - 2)
#define DEST_INDEX (VERTICES_COUNT - 1)

#endif // _LOCAL_CONSTANTS

#ifndef _STRUCTS_ENUMS

typedef struct
{
    int * successorEdges;
    int * predecessorEdges;
    int successorEdgesCount;
    int predecessorEdgesCount;
} Vertex;

typedef struct
{
    int source;
    int destination;
    int weight;
    int flow;
} Edge;

typedef struct
{
    int * elements;
    int elementsCount;
    int minFlow;
} Path;

#endif // _STRUCTS_ENUMS

#ifndef _FUNCTION_PROTOTYPES

void FindMaxFlow();
Path * FindSuccessorsPath(int source);
Path * FindPredecessorsPath(int source);
void AddVertexToPath(Path * path, int edgeIndex, int currentFlow);
Path* FindAugmentingPath(int source);
void InitializeFlowNetworkEndpoints();
void AddPossibleTaskToPerson(int pI, int tI, int edgeIndex);
void ProcessInput();
void PrintAssignedTasks();
void PrintGraph();
void InitializeResources();
Path * InitializePath();
void DisposeResources();
void DisposeVertex(int index);
void DisposePath(Path * path);

#endif // _FUNCTION_PROTOTYPES

#ifndef _LOCAL_DATA

static Vertex * vertices;
static Edge * edges;
static bool * occupiedEdges;
static bool * backwardEdges;

static int peopleCount;
static int tasksCount;
static int edgesCount;

#endif // _LOCAL_DATA

#ifndef _MAIN

int main()
{
    ProcessInput();
    FindMaxFlow();
    PrintAssignedTasks();
    DisposeResources();

    return 0;
}

#endif // _MAIN

#ifndef _ALGO_IMPLEMENTATION

void FindMaxFlow()
{
    bool pathFound = true;
    while (pathFound)
    {
        pathFound = false;
        Path * path = FindAugmentingPath(SOURCE_INDEX);

        if (path != NULL)
        {
            for (int index = 0; index < (*path).elementsCount; ++index)
            {
                int edgeIndex = (*path).elements[index];

                if (!backwardEdges[edgeIndex])
                {
                    edges[edgeIndex].flow += (*path).minFlow;
                }
                else
                {
                    edges[edgeIndex].flow -= (*path).minFlow;
                }

                occupiedEdges[edgeIndex] = false;
                backwardEdges[edgeIndex] = false;
            }

            pathFound = true;
            DisposePath(path);
        }
    }
}

Path* FindAugmentingPath(int source)
{
    if (source == DEST_INDEX)
    {
        return InitializePath();
    }

    Path * path = FindSuccessorsPath(source);

    if (path == NULL)
    {
        return FindPredecessorsPath(source);
    }
    else
    {
        return path;
    }
}

Path * FindSuccessorsPath(int source)
{
    Vertex vertex = vertices[source];

    for (int index = 0; index < vertex.successorEdgesCount; ++index)
    {
        int edgeIndex = vertex.successorEdges[index];
        Edge edge = edges[edgeIndex];
        int availableFlow = edge.weight - edge.flow;

        if (occupiedEdges[edgeIndex] || availableFlow <= 0)
        {
            continue;
        }

        occupiedEdges[edgeIndex] = true;
        Path * path = FindAugmentingPath(edge.destination);

        if (path != NULL)
        {
            AddVertexToPath(path, edgeIndex, availableFlow);
            return path;
        }
        else
        {
            occupiedEdges[edgeIndex] = false;
        }
    }

    return NULL;
}

Path * FindPredecessorsPath(int source)
{
    Vertex vertex = vertices[source];

    for (int index = 0; index < vertex.predecessorEdgesCount; ++index)
    {
        int edgeIndex = vertex.predecessorEdges[index];
        Edge edge = edges[edgeIndex];
        int takenFlow = edge.flow;

        if (occupiedEdges[edgeIndex] || takenFlow <= 0)
        {
            continue;
        }

        occupiedEdges[edgeIndex] = true;
        Path * path = FindAugmentingPath(edge.source);

        if (path != NULL)
        {
            backwardEdges[edgeIndex] = true;
            AddVertexToPath(path, edgeIndex, takenFlow);
            return path;
        }
        else
        {
            occupiedEdges[edgeIndex] = false;
        }
    }

    return NULL;
}

void AddVertexToPath(Path * path, int edgeIndex, int currentFlow)
{
    (*path).elements[(*path).elementsCount] = edgeIndex;
    ++(*path).elementsCount;
    (*path).minFlow = min((*path).minFlow, currentFlow);
}

#endif // _ALGO_IMPLEMENTATION

#ifndef _IO_PROCESSING

void ProcessInput()
{
    char input[MAX_DATA];

    cin >> input; // ignore unnecessary string
    cin >> input;

    peopleCount = atoi(input);

    cin >> input; // ignore unnecessary string
    cin >> input;
    tasksCount = atoi(input);

    InitializeResources();

    // pI - personIndex, tI - taskIndex
    for (int pI = 0; pI < peopleCount; ++pI)
    {
        for (int tI = 0; tI < tasksCount; ++tI)
        {
            char taskState;
            cin >> taskState;

            if (taskState == 'Y')
            {
                // Set source/destination of corresponding edge
                edges[edgesCount].source = pI;
                edges[edgesCount].destination =
                    TASK_INDEX(tI);

                // Set edge as successor/predecessor of source/destination vertices
                AddPossibleTaskToPerson(pI, tI, edgesCount);

                ++edgesCount;
            }
        }
    }

    InitializeFlowNetworkEndpoints();
}

void AddPossibleTaskToPerson(int pI, int tI, int edgeIndex)
{
    // pI - personIndex, tI - taskIndex

    vertices[pI]
        .successorEdges[SUCCESSORS_COUNT(pI)] = edgeIndex;
    ++SUCCESSORS_COUNT(pI);

    vertices[TASK_INDEX(tI)]
        .predecessorEdges[PREDECESSORS_COUNT(TASK_INDEX(tI))] = edgeIndex;
    ++PREDECESSORS_COUNT(TASK_INDEX(tI));
}

void InitializeFlowNetworkEndpoints()
{
    for (int pI = 0; pI < peopleCount; ++pI)
    {
        edges[edgesCount].destination = pI;
        edges[edgesCount].source = SOURCE_INDEX;

        vertices[pI]
            .predecessorEdges[PREDECESSORS_COUNT(pI)] = edgesCount;
        ++PREDECESSORS_COUNT(pI);

        vertices[SOURCE_INDEX].
            successorEdges[SUCCESSORS_COUNT(SOURCE_INDEX)] = edgesCount;
        ++SUCCESSORS_COUNT(SOURCE_INDEX);

        ++edgesCount;
    }

    for (int tI = 0; tI < tasksCount; ++tI)
    {
        edges[edgesCount].source = TASK_INDEX(tI);
        edges[edgesCount].destination = DEST_INDEX;

        vertices[TASK_INDEX(tI)]
            .successorEdges[SUCCESSORS_COUNT(TASK_INDEX(tI))] =
                edgesCount;
        ++SUCCESSORS_COUNT(TASK_INDEX(tI));

        vertices[DEST_INDEX]
            .predecessorEdges[PREDECESSORS_COUNT(DEST_INDEX)] =
                edgesCount;
        ++PREDECESSORS_COUNT(DEST_INDEX);

        ++edgesCount;
    }
}

void PrintAssignedTasks()
{
    // pI - personIndex, tI - taskIndex
    for (int pI = 0; pI < peopleCount; ++pI)
    {
        for (int tI = 0; tI < SUCCESSORS_COUNT(pI); ++tI)
        {
            int edgeIndex = vertices[pI].successorEdges[tI];
            Edge edge = edges[edgeIndex];
            if (edge.flow > 0)
            {
                printf("%c - %d\n",
                       (pI + 'A'),
                       edge.destination - peopleCount + 1);
            }
        }
    }
}

// Used for debugging
void PrintGraph()
{
    for (int index = 0; index < VERTICES_COUNT; ++index)
    {
        Vertex vertex = vertices[index];
        cout << "V: " << index;
        cout << " S: ";
        for (int sI = 0; sI < vertex.successorEdgesCount; ++sI)
        {
            cout << edges[vertex.successorEdges[sI]].destination << " ";
        }

        cout << " P: ";
        for (int pI = 0; pI < vertex.predecessorEdgesCount; ++pI)
        {
            cout << edges[vertex.predecessorEdges[pI]].source << " ";
        }

        cout << endl;
    }
}

#endif // _IO_PROCESSING

#ifndef _RESOURCES_MANAGEMENT

void InitializeResources()
{
    vertices = (Vertex*)malloc(sizeof(Vertex) * VERTICES_COUNT);
    edges = (Edge*)malloc(sizeof(Edge) * MAX_EDGES);
    occupiedEdges = (bool*)malloc(sizeof(bool) * MAX_EDGES);
    backwardEdges = (bool*)malloc(sizeof(bool) * MAX_EDGES);

    for (int index = 0; index < VERTICES_COUNT; ++index)
    {
        vertices[index].predecessorEdges = (int*)malloc(sizeof(int) * MAX_EDGES);
        vertices[index].successorEdges = (int*)malloc(sizeof(int) * MAX_EDGES);
        vertices[index].successorEdgesCount = 0;
        vertices[index].predecessorEdgesCount = 0;
    }

    for (int index = 0; index < MAX_EDGES; ++index)
    {
        edges[index].weight = 1;
        edges[index].flow = 0;
        backwardEdges[index] = false;
        occupiedEdges[index] = false;
    }
}

Path * InitializePath()
{
    Path * path = (Path*)malloc(sizeof(Path));
    (*path).elements = (int*)malloc(sizeof(int) * MAX_EDGES);
    (*path).minFlow = INT_MAX;
    (*path).elementsCount = 0;
    return path;
}

void DisposeResources()
{
    for (int vI = 0; vI < VERTICES_COUNT; ++vI)
    {
        DisposeVertex(vI);
    }

    free(vertices);
    free(edges);
    free(occupiedEdges);
    free(backwardEdges);
}

void DisposeVertex(int index)
{
    free(vertices[index].predecessorEdges);
    free(vertices[index].successorEdges);
}

void DisposePath(Path * path)
{
    free((*path).elements);
    free(path);
}

#endif // _RESOURCES_MANAGEMENT
