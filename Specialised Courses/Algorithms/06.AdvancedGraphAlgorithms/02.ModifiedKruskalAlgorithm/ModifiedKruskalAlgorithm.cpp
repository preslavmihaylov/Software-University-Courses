#ifndef _LIBS_NAMESPACES

#include <iostream>
#include <stdio.h>
#include <math.h>

using namespace std;

#endif // _LIBS_NAMESPACES

#ifndef _LOCAL_CONSTANTS

#define MAX_DATA 50

#endif // _LOCAL_CONSTANTS

#ifndef _STRUCTS_ENUMS

typedef struct
{
    int nodeIndex;
    int parentIndex;
    int children[MAX_DATA];
    int childrenCount;
} Vertex;

typedef struct
{
    int firstVertex;
    int secondVertex;
    int weight;
} Edge;

#endif // _STRUCTS_ENUMS

#ifndef _FUNCTION_PROTOTYPES

void KruskalFindMST();
int FindRoot(int vertexIndex);
void MergeNodes(int firstVertexIndex, int secondVertexIndex);
void SortEdges();
void ProcessInput();
void PrintMST();
void PrintEdges();

#endif // _FUNCTION_PROTOTYPES

#ifndef _LOCAL_DATA

static Edge edges[MAX_DATA];
static Edge minSpanningTree[MAX_DATA];
static Vertex vertices[MAX_DATA];

static int verticesCount;
static int minSpanningTreeLength;
static int edgesCount;

#endif // _LOCAL_DATA

#ifndef _MAIN

int main()
{
    ProcessInput();
    SortEdges();
    KruskalFindMST();
    PrintMST();

    return 0;
}

#endif // _MAIN

#ifndef _ALGO_IMPLEMENTATION

void KruskalFindMST()
{
    for (int index = 0; index < verticesCount; index++)
    {
        vertices[index].parentIndex = index;
    }

    int edgeIndex = 0;
    while (edgeIndex < edgesCount)
    {
        Edge currentEdge = edges[edgeIndex];

        int firstRoot = FindRoot(currentEdge.firstVertex);
        int secondRoot = FindRoot(currentEdge.secondVertex);

        if (firstRoot != secondRoot)
        {
            MergeNodes(firstRoot, secondRoot);
            minSpanningTree[minSpanningTreeLength] = currentEdge;
            minSpanningTreeLength++;
        }

        edgeIndex++;
    }
}

void MergeNodes(int firstVertexIndex, int secondVertexIndex)
{
    Vertex * firstVertex = &vertices[firstVertexIndex];
    Vertex * secondVertex = &vertices[secondVertexIndex];

    for (int index = 0; index < (*secondVertex).childrenCount; index++)
    {
        (*firstVertex).children[(*firstVertex).childrenCount] = (*secondVertex).children[index];
        ++(*firstVertex).childrenCount;

        vertices[(*secondVertex).children[index]].parentIndex = firstVertexIndex;
    }

    (*firstVertex).children[(*firstVertex).childrenCount] = secondVertexIndex;
    ++(*firstVertex).childrenCount;

    (*secondVertex).parentIndex = firstVertexIndex;
    (*secondVertex).childrenCount = 0;
}

int FindRoot(int vertexIndex)
{
    return vertices[vertexIndex].parentIndex;
}

void SortEdges()
{
    for (int index = 0; index < edgesCount; index++)
    {
        int minEdgeIndex = index;
        for (int innerIndex = index; innerIndex < edgesCount; innerIndex++)
        {
            if (edges[innerIndex].weight < edges[minEdgeIndex].weight)
            {
                minEdgeIndex = innerIndex;
            }
        }

        Edge tempEdge = edges[minEdgeIndex];
        edges[minEdgeIndex] = edges[index];
        edges[index] = tempEdge;
    }
}

#endif // _ALGO_IMPLEMENTATION

#ifndef _IO_PROCESSING

void ProcessInput()
{
    cin >> edgesCount;

    for (int index = 0; index < edgesCount; index++)
    {
        int firstVertex;
        int secondVertex;
        int weight;

        cin >> firstVertex;
        cin >> secondVertex;
        cin >> weight;

        edges[index].firstVertex = firstVertex;
        edges[index].secondVertex = secondVertex;
        edges[index].weight = weight;



        int maxVertexIndex = max(firstVertex, secondVertex);
        if (maxVertexIndex >= verticesCount)
        {
            verticesCount = maxVertexIndex + 1;
        }
    }
}

void PrintMST()
{
    for (int index = 0; index < minSpanningTreeLength; index++)
    {
        Edge edge = minSpanningTree[index];

        printf("(%d, %d) -> %d\n",
               edge.firstVertex,
               edge.secondVertex,
               edge.weight);
    }
}

// Used for debugging
void PrintEdges()
{
    for (int index = 0; index < edgesCount; index++)
    {
        cout << "F: "
             << edges[index].firstVertex
             << " S: "
             << edges[index].secondVertex
             << " W: "
             << edges[index].weight
             << endl;
    }
}

#endif // _IO_PROCESSING
