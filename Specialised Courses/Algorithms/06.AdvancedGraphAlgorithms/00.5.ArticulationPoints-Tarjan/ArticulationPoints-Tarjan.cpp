#ifndef _LIBS_NAMESPACES

#include <iostream>
#include <stack>
#include <stdio.h>
#include <stdlib.h>

using namespace std;

#endif // _LIBS_NAMESPACES

#ifndef _LOCAL_CONSTANTS

#define MAX_DATA 50
#define INPUT_MAX_LENGTH 10
#define ROOT_INDEX -1

#define EDGES_COUNT(vertexIndex) (vertices[vertexIndex].edgesCount)

#endif // _LOCAL_CONSTANTS

#ifndef _STRUCTS_ENUMS

typedef struct
{
    int source;
    int destination;
} Edge;

typedef struct
{
    int * edges;
    int edgesCount;
} Vertex;

#endif // _STRUCTS_ENUMS

#ifndef _FUNCTION_PROTOTYPES

void FindArticulationPoints();
void FindArticulationPointsPrivate(int vertexIndex, int parent);
void ProcessInput();
void PrintInfo();
void PrintArticulationPoints();
void InitializeResources();
void DisposeResources();
void DisposeVertices();

#endif // _FUNCTION_PROTOTYPES

#ifndef _LOCAL_DATA

static Vertex * vertices;
static Edge * edges;

// Algorithm utils
static int * articulationPoints;
static int * visitTimes;
static int * lowTimes;
static bool * visitedVertices;

static int currentVisitTime;

static int articulationPointsCount;
static int verticesCount;
static int edgesCount;

#endif // _LOCAL_DATA

#ifndef _MAIN

int main()
{
    ProcessInput();
    FindArticulationPoints();
    PrintArticulationPoints();
    // PrintInfo();

    DisposeResources();

    return 0;
}
#endif // _MAIN

#ifndef _ALGO_IMPLEMENTATION

void FindArticulationPoints()
{
    for (int index = 0; index < verticesCount; ++index)
    {
        if (!visitedVertices[index])
        {
            FindArticulationPointsPrivate(index, ROOT_INDEX);
        }
    }
}

// Implementing the Tarjan algorithm
void FindArticulationPointsPrivate(int vertexIndex, int parent)
{
    int childrenCount = 0;
    bool isArticulationPoint = false;
    visitedVertices[vertexIndex] = true;
    visitTimes[vertexIndex] = currentVisitTime;
    lowTimes[vertexIndex] = currentVisitTime;
    ++currentVisitTime;

    Vertex vertex = vertices[vertexIndex];


    for (int descEdgeIndex = 0;
         descEdgeIndex < EDGES_COUNT(vertexIndex);
         ++descEdgeIndex)
    {
        int edgeIndex = vertex.edges[descEdgeIndex];
        Edge edge = edges[edgeIndex];

        int nextVertexIndex =
            edge.source == vertexIndex ? edge.destination : edge.source;

        if (!visitedVertices[nextVertexIndex])
        {
            ++childrenCount;

            FindArticulationPointsPrivate(nextVertexIndex, vertexIndex);

            if (visitTimes[vertexIndex] <= lowTimes[nextVertexIndex] &&
                parent != ROOT_INDEX &&
                !isArticulationPoint)
            {
                isArticulationPoint = true;
                articulationPoints[articulationPointsCount++] = vertexIndex;
            }

            lowTimes[vertexIndex] =
                min(lowTimes[vertexIndex], lowTimes[nextVertexIndex]);
        }
        else if (parent != nextVertexIndex &&
                 visitTimes[vertexIndex] > visitTimes[nextVertexIndex])
        {
            lowTimes[vertexIndex] =
                min(lowTimes[vertexIndex], visitTimes[nextVertexIndex]);
        }
    }

    if (parent == ROOT_INDEX && childrenCount >= 2)
    {
        articulationPoints[articulationPointsCount++] = vertexIndex;
    }
}

#endif // _ALGO_IMPLEMENTATION

#ifndef _IO_PROCESSING

void ProcessInput()
{
    char input[INPUT_MAX_LENGTH];
    cin >> input; // Ignore irrelevant string
    cin >> input;
    verticesCount = atoi(input);

    cin >> input; // Ignore irrelevant string
    cin >> input;
    edgesCount = atoi(input);

    InitializeResources();

    for (int edgeIndex = 0; edgeIndex < edgesCount; ++edgeIndex)
    {
        int firstVertex;
        int secondVertex;

        cin >> firstVertex;
        cin >> secondVertex;

        edges[edgeIndex].source = firstVertex;
        edges[edgeIndex].destination = secondVertex;

        vertices[firstVertex].edges[EDGES_COUNT(firstVertex)] = edgeIndex;
        ++EDGES_COUNT(firstVertex);

        vertices[secondVertex].edges[EDGES_COUNT(secondVertex)] = edgeIndex;
        ++EDGES_COUNT(secondVertex);
    }
}

void PrintArticulationPoints()
{
    cout << "Articulation points: ";
    for (int index = 0; index < articulationPointsCount; ++index)
    {
        cout << articulationPoints[index] << " ";
    }
    cout << endl;
}

// Used for debugging
void PrintInfo()
{
    cout << "Edges:" << endl;
    for (int index = 0; index < edgesCount; ++index)
    {
        Edge edge = edges[index];
        printf("%d: (%d -> %d)\n", index, edge.source, edge.destination);
    }

    cout << "Vertices" << endl;
    for (int index = 0; index < verticesCount; ++index)
    {
        Vertex vertex = vertices[index];
        printf("%d -> ", index);
        for (int i = 0; i < EDGES_COUNT(index); ++i)
        {
            printf("%d ", vertex.edges[i]);
        }
        cout << endl;
    }
}

#endif // _IO_PROCESSING

#ifndef _RESOURCES_DISPOSAL

void InitializeResources()
{
    vertices = (Vertex*)malloc(sizeof(Vertex) * verticesCount);
    edges = (Edge*)malloc(sizeof(Edge) * edgesCount);
    articulationPoints = (int*)malloc(sizeof(int) * verticesCount);
    visitedVertices = (bool*)malloc(sizeof(bool) * verticesCount);
    visitTimes = (int*)malloc(sizeof(int) * verticesCount);
    lowTimes = (int*)malloc(sizeof(int) * verticesCount);

    for (int index = 0; index < verticesCount; ++index)
    {
        vertices[index].edges = (int*)malloc(sizeof(int) * edgesCount);
        vertices[index].edgesCount = 0;
        visitedVertices[index] = false;
    }
}

void DisposeResources()
{
    DisposeVertices();

    free(edges);
    free(articulationPoints);
    free(visitedVertices);
    free(visitTimes);
    free(lowTimes);
}

void DisposeVertices()
{
    for (int index = 0; index < verticesCount; ++index)
    {
        free(vertices[index].edges);
    }

    free(vertices);
}

#endif // _RESOURCES_DISPOSAL
