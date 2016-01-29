#include <iostream>
#include "Data.h"

/* FUNCTION PROTOTYPES */
void BreakCycles();
bool RemoveCyclicEdges(int vertexIndex);
void InitializeInputData();
void PrintResult();

static bool removedEdges[MAX_DATA];
static bool visitedVertices[MAX_DATA];

static int removedEdgesCount = 0;

int main()
{
    InitializeInputData();
    BreakCycles();
    PrintResult();

    return 0;
}

void BreakCycles()
{
    for (int index = 0; index < verticesCount; index++)
    {
        RemoveCyclicEdges(index);
    }
}

bool RemoveCyclicEdges(int vertexIndex)
{
    if (visitedVertices[vertexIndex])
    {
        return true;
    }

    Vertex vertex = vertices[vertexIndex];

    visitedVertices[vertexIndex] = true;

    for (int index = 0; index < vertex.edgesCount; index++)
    {
        if (removedEdges[vertex.edges[index]])
        {
            continue;
        }

        Edge edge = edges[vertex.edges[index]];

        bool result = RemoveCyclicEdges(edge.secondVertexIndex);

        if (result)
        {
            removedEdges[vertex.edges[index]] = true;
            removedEdgesCount++;
        }
    }

    visitedVertices[vertexIndex] = false;

    return false;
}

void InitializeInputData()
{
    // InitializeFirstSampleData();
    InitializeSecondSampleData();
}

void PrintResult()
{
    cout << "Total edges count: " << removedEdgesCount << endl;

    for (int index = 0; index < edgesCount; index++)
    {
        if (removedEdges[index])
        {
            Edge edge = edges[index];

            string firstVertex =
                mappings.at(edge.firstVertexIndex);

            string secondVertex =
                mappings.at(edge.secondVertexIndex);

            cout << firstVertex
                 << " -> "
                 << secondVertex
                 << endl;
        }
    }
}
