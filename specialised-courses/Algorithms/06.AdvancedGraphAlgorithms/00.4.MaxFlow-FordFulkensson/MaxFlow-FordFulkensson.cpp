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

#endif // _LOCAL_CONSTANTS

#ifndef _STRUCTS_ENUMS

typedef struct
{
    int successorEdges[MAX_DATA];
    int predecessorEdges[MAX_DATA];
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
    int elements[MAX_DATA];
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
void ProcessInput();
void PrintGraph();
void PrintMaxFlow();
void InitializeResources();
void DisposeResources();

#endif // _FUNCTION_PROTOTYPES

#ifndef _LOCAL_DATA

static Vertex * vertices;
static Edge * edges;
static bool * occupiedEdges;
static bool * backwardEdges;

static int verticesCount;
static int edgesCount;

static int maxFlow;
static int sourceNode;
static int destinationNode;

#endif // _LOCAL_DATA

#ifndef _MAIN

/*

Example 1:
8
15
0 1 10
0 2 5
0 3 15
1 2 4
2 3 4
1 4 9
1 5 15
2 5 8
6 2 6
3 6 16
4 5 15
5 6 15
4 7 10
5 7 10
6 7 10
0
7
Expected: 28 Ref: https://www.youtube.com/watch?v=-8MwfgB-lyM

*/

int main()
{
    ProcessInput();
    FindMaxFlow();
    PrintMaxFlow();
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
        Path * path = FindAugmentingPath(sourceNode);

        if (path != NULL)
        {
            maxFlow += (*path).minFlow;

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
            free(path);
        }
    }
}

Path* FindAugmentingPath(int source)
{
    if (source == destinationNode)
    {
        Path * path = new Path;
        (*path).minFlow = INT_MAX;
        (*path).elementsCount = 0;
        return path;
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
    cin >> verticesCount;
    cin >> edgesCount;

    InitializeResources();

    int edgeIndex = 0;
    for (int index = 0; index < edgesCount; index++)
    {
        int firstVertex;
        int secondVertex;
        int weight;

        cin >> firstVertex;
        cin >> secondVertex;
        cin >> weight;

        edges[edgeIndex].source = firstVertex;
        edges[edgeIndex].destination = secondVertex;
        edges[edgeIndex].weight = weight;
        edges[edgeIndex].flow = 0;
        ++edgeIndex;

        vertices[firstVertex]
            .successorEdges[vertices[firstVertex].successorEdgesCount] =
                edgeIndex - 1;
        ++vertices[firstVertex].successorEdgesCount;

        vertices[secondVertex]
            .predecessorEdges[vertices[secondVertex].predecessorEdgesCount] =
                edgeIndex - 1;
        ++vertices[secondVertex].predecessorEdgesCount;

    }

    cout << "Source: ";
    cin >> sourceNode;
    cout << "Target: ";
    cin >> destinationNode;
}

void PrintMaxFlow()
{
    cout << "Max flow: " << maxFlow << endl;

    for (int index = 0; index < edgesCount; ++index)
    {
        Edge edge = edges[index];
        printf("(%d -> %d) W: %d F: %d\n",
               edge.source,
               edge.destination,
               edge.weight,
               edge.flow);
    }
}

// Used for debugging
void PrintGraph()
{
    for (int index = 0; index < verticesCount; ++index)
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
    vertices = (Vertex*)malloc(sizeof(Vertex) * verticesCount);
    edges = (Edge*)malloc(sizeof(Edge) * edgesCount);
    occupiedEdges = (bool*)malloc(sizeof(bool) * edgesCount);
    backwardEdges = (bool*)malloc(sizeof(bool) * edgesCount);

    for (int index = 0; index < verticesCount; ++index)
    {
        vertices[index].successorEdgesCount = 0;
        vertices[index].predecessorEdgesCount = 0;
    }

    for (int index = 0; index < edgesCount; ++index)
    {
        backwardEdges[index] = false;
        occupiedEdges[index] = false;
    }
}

void DisposeResources()
{
    free(vertices);
    free(edges);
    free(occupiedEdges);
    free(backwardEdges);
}

#endif // _RESOURCES_MANAGEMENT
