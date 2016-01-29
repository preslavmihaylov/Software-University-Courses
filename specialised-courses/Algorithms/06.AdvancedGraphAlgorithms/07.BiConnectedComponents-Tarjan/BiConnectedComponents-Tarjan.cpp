#ifndef _LIBS_NAMESPACES

#include <iostream>
#include <stack>
#include <stdio.h>
#include <stdlib.h>

using namespace std;

#endif // _LIBS_NAMESPACES

#ifndef _LOCAL_CONSTANTS

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

void FindBiConnectedComponents();
void FindBiConnectedComponentsPrivate(int vertexIndex,
                                      int parent,
                                      int parentEdgeIndex);
void ProcessInput();
void PrintInfo();
void PrintBiConnectedComponents(int rootEdgeIndex);
void InitializeResources();
void DisposeResources();

#endif // _FUNCTION_PROTOTYPES

#ifndef _LOCAL_DATA

static Vertex * vertices;
static Edge * edges;

// Algorithm utils
static stack<int> biConnectedComponents;
static int * visitTimes;
static int * lowTimes;
static bool * visitedVertices;

static int currentVisitTime;

static int verticesCount;
static int edgesCount;

#endif // _LOCAL_DATA

#ifndef _MAIN

int main()
{
    ProcessInput();

    cout << "Bi connected components:" << endl;

    FindBiConnectedComponents();
    // PrintInfo();

    DisposeResources();

    return 0;
}
#endif // _MAIN

#ifndef _ALGO_IMPLEMENTATION

void FindBiConnectedComponents()
{
    for (int index = 0; index < verticesCount; ++index)
    {
        if (!visitedVertices[index])
        {
            FindBiConnectedComponentsPrivate(index, ROOT_INDEX, -1);
            PrintBiConnectedComponents(-1);
        }
    }
}

// Implementing the Tarjan algorithm
void FindBiConnectedComponentsPrivate(int vertexIndex,
                                      int parent,
                                      int parentEdgeIndex)
{
    Vertex vertex = vertices[vertexIndex];
    visitedVertices[vertexIndex] = true;

    visitTimes[vertexIndex] = currentVisitTime;
    lowTimes[vertexIndex] = currentVisitTime;
    ++currentVisitTime;

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
            biConnectedComponents.push(edgeIndex);

            FindBiConnectedComponentsPrivate(nextVertexIndex,
                                             vertexIndex,
                                             edgeIndex);

            if (visitTimes[vertexIndex] <= lowTimes[nextVertexIndex])
            {
                PrintBiConnectedComponents(edgeIndex);
            }

            lowTimes[vertexIndex] =
                min(lowTimes[vertexIndex], lowTimes[nextVertexIndex]);
        }
        else if (parent != nextVertexIndex &&
                 visitTimes[vertexIndex] > visitTimes[nextVertexIndex])
        {
            biConnectedComponents.push(edgeIndex);
            lowTimes[vertexIndex] =
                min(lowTimes[vertexIndex], visitTimes[nextVertexIndex]);
        }
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

void PrintBiConnectedComponents(int rootEdge)
{
    if (biConnectedComponents.size() == 0)
    {
        return;
    }

    bool * printedVertices = (bool*)malloc(sizeof(bool) * verticesCount);
    int lastEdgeIndex = -1;

    do
    {
        int edgeIndex = biConnectedComponents.top();
        biConnectedComponents.pop();

        Edge edge = edges[edgeIndex];

        if (!printedVertices[edge.source])
        {
            printedVertices[edge.source] = true;
            printf("%d ", edge.source);
        }

        if (!printedVertices[edge.destination])
        {
            printedVertices[edge.destination] = true;
            printf("%d ", edge.destination);
        }

        lastEdgeIndex = edgeIndex;

    } while (lastEdgeIndex != rootEdge && biConnectedComponents.size() > 0);

    cout << endl;

    free(printedVertices);
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

#ifndef _RESOURCES_MANAGEMENT

void InitializeResources()
{
    vertices = (Vertex*)malloc(sizeof(Vertex) * verticesCount);
    edges = (Edge*)malloc(sizeof(Edge) * edgesCount);
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
    for (int index = 0; index < verticesCount; ++index)
    {
        free(vertices[index].edges);
    }

    free(vertices);
    free(edges);
    free(visitedVertices);
    free(visitTimes);
    free(lowTimes);
}

#endif // _RESOURCES_DISPOSAL
