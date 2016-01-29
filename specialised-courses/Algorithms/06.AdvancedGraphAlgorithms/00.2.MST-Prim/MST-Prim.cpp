#ifndef _LIBS_NAMESPACES

#include <iostream>
#include <stdio.h>
#include "Heap.h"

using namespace std;

#endif // _LIBS_NAMESPACES

#ifndef _LOCAL_CONSTANTS

#define MAX_DATA 50

#endif // _LOCAL_CONSTANTS

#ifndef _STRUCTS_ENUMS

struct Edge
{
    int firstVertex;
    int secondVertex;
    int weight;
    int index;

    inline bool operator>(Edge a) {
        return weight > a.weight;
    }

    inline bool operator<(Edge a) {
        return weight < a.weight;
    }

    inline bool operator==(Edge a) {
        return weight == a.weight;
    }
};

typedef struct Edge Edge;

typedef struct
{
    int edges[MAX_DATA];
    int edgesCount;
} Vertex;

#endif // _STRUCTS_ENUMS

#ifndef _FUNCTION_PROTOTYPES

void FindMST();
void PrimFindMST(int vertexIndex);
void ProcessInput();
void PrintGraph();
void PrintMST();

#endif // _FUNCTION_PROTOTYPES

#ifndef _LOCAL_DATA

static Vertex vertices[MAX_DATA];
static Edge edges[MAX_DATA];
static int minSpanningTree[MAX_DATA];
static bool visitedEdges[MAX_DATA];
static bool visitedVertices[MAX_DATA];

static int verticesCount;
static int edgesCount;
static int minSpanningTreeLength;

#endif // _LOCAL_DATA

#ifndef _MAIN

int main()
{
    ProcessInput();
    FindMST();
    PrintMST();
    // PrintGraph();

    return 0;
}

#endif // _MAIN

#ifndef _ALGO_IMPLEMENTATION

void FindMST()
{
    for (int index = 0; index < verticesCount; index++)
    {
        if (!visitedVertices[index])
        {
            PrimFindMST(index);
        }
    }
}

void PrimFindMST(int vertexIndex)
{
    Vertex currentVertex = vertices[vertexIndex];
    visitedVertices[vertexIndex] = true;
    Heap<Edge> priorityQueue;

    for (int index = 0; index < currentVertex.edgesCount; index++)
    {
        priorityQueue.Insert(edges[currentVertex.edges[index]]);
        visitedEdges[currentVertex.edges[index]] = true;
    }

    while (priorityQueue.Count() > 0)
    {
        Edge edge = priorityQueue.ExtractMin();
        int currentEdgeIndex = edge.index;

        int firstVertexIndex = edge.firstVertex;
        int secondVertexIndex = edge.secondVertex;

        if (visitedVertices[firstVertexIndex] ^ visitedVertices[secondVertexIndex])
        {
            minSpanningTree[minSpanningTreeLength] = currentEdgeIndex;
            minSpanningTreeLength++;

            Vertex vertex;

            if (!visitedVertices[firstVertexIndex])
            {
                visitedVertices[firstVertexIndex] = true;
                vertex = vertices[firstVertexIndex];
            }
            else
            {
                visitedVertices[secondVertexIndex] = true;
                vertex = vertices[secondVertexIndex];
            }

            for (int edgeIndex = 0; edgeIndex < vertex.edgesCount; edgeIndex++)
            {
                if (!visitedEdges[vertex.edges[edgeIndex]])
                {
                    visitedEdges[vertex.edges[edgeIndex]] = true;
                    priorityQueue.Insert(edges[vertex.edges[edgeIndex]]);
                }
            }
        }
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
        edges[index].index = index;

        vertices[firstVertex].edges[vertices[firstVertex].edgesCount] = index;
        vertices[firstVertex].edgesCount++;

        vertices[secondVertex].edges[vertices[secondVertex].edgesCount] = index;
        vertices[secondVertex].edgesCount++;

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
        Edge edge = edges[minSpanningTree[index]];

        printf("(%d, %d) -> %d\n",
               edge.firstVertex,
               edge.secondVertex,
               edge.weight);
    }
}

void PrintGraph()
{
    for (int index = 0; index < verticesCount; index++)
    {
        Vertex vertex = vertices[index];
        cout << index << " -> ";

        for (int edgeIndex = 0; edgeIndex < vertex.edgesCount; edgeIndex++)
        {
            Edge edge = edges[vertex.edges[edgeIndex]];

            cout << "    ";
            cout << "(";

            cout << "F: "
                 << edge.firstVertex
                 << " S: "
                 << edge.secondVertex
                 << " W: "
                 << edge.weight
                 << ")"
                 << endl;
        }

        cout << endl;
    }
}

#endif // _IO_PROCESSING

