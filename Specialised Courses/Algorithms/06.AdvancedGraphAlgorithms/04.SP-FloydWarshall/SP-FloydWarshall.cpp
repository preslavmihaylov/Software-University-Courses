#ifndef _LIBS_NAMESPACES

#include <iostream>
#include <stdio.h>
#include <stdlib.h>
#include <limits.h>

using namespace std;

#endif // _LIBS_NAMESPACES

#ifndef _LOCAL_CONSTANTS

#define INPUT_MAX_LENGTH 10

#endif // _LOCAL_CONSTANTS

#ifndef _STRUCTS_ENUMS

#endif // _STRUCTS_ENUMS

#ifndef _FUNCTION_PROTOTYPES

void FindShortestPathBetweenAllPairsOfNodes();
void InitializeMatrix();
void ProcessInput();
void PrintMatrix();
void DisposeResources();

#endif // _FUNCTION_PROTOTYPES

#ifndef _LOCAL_DATA

static int ** adjacencyMatrix;

static int nodesCount;

#endif // _LOCAL_DATA

#ifndef _MAIN

int main()
{
    ProcessInput();
    FindShortestPathBetweenAllPairsOfNodes();
    PrintMatrix();
    DisposeResources();
    return 0;
}
#endif // _MAIN

#ifndef _ALGO_IMPLEMENTATION

// Implementing the Floyd-Warshall Algorithm
void FindShortestPathBetweenAllPairsOfNodes()
{
    // mV - Middle vertex, fV - First vertex, sV - Second vertex
    for (int mV = 0; mV < nodesCount; ++mV)
    {
        for (int fV = 0; fV < nodesCount; ++fV)
        {
            for (int sV = 0; sV < nodesCount; ++sV)
            {
                if (adjacencyMatrix[fV][mV] == INT_MAX ||
                    adjacencyMatrix[mV][sV] == INT_MAX)
                {
                    continue;
                }

                if ( (adjacencyMatrix[fV][mV] + adjacencyMatrix[mV][sV])
                        < adjacencyMatrix[fV][sV])
                {
                    adjacencyMatrix[fV][sV] =
                        adjacencyMatrix[fV][mV] + adjacencyMatrix[mV][sV];
                }
            }
        }
    }
}

#endif // _ALGO_IMPLEMENTATION

#ifndef _IO_PROCESSING

void InitializeMatrix()
{
    adjacencyMatrix = (int**)malloc(sizeof(int*) * nodesCount);

    for (int row = 0; row < nodesCount; ++row)
    {
        adjacencyMatrix[row] = (int*)malloc(sizeof(int) * nodesCount);
        for (int col = 0; col < nodesCount; ++col)
        {
            if (row != col)
            {
                adjacencyMatrix[row][col] = INT_MAX;
            }
            else
            {
                adjacencyMatrix[row][col] = 0;
            }
        }
    }
}

void ProcessInput()
{
    char input[INPUT_MAX_LENGTH];
    cin >> input; // Ignore irrelevant string
    cin >> input;
    nodesCount = atoi(input);

    cin >> input; // Ignore irrelevant string
    cin >> input;
    int edgesCount = atoi(input);

    InitializeMatrix();

    for (int edgeIndex = 0; edgeIndex < edgesCount; ++edgeIndex)
    {
        int firstVertex;
        int secondVertex;
        int weight;

        cin >> firstVertex;
        cin >> secondVertex;
        cin >> weight;

        adjacencyMatrix[firstVertex][secondVertex] = weight;
        adjacencyMatrix[secondVertex][firstVertex] = weight;
    }
}

void PrintMatrix()
{
    for (int row = 0; row < nodesCount; ++row)
    {
        for (int col = 0; col < nodesCount; ++col)
        {
            cout << adjacencyMatrix[row][col] << " ";
        }
        cout << endl;
    }
}

#endif // _IO_PROCESSING

#ifndef _RESOURCES_DISPOSAL

void DisposeResources()
{
    for (int row = 0; row < nodesCount; ++row)
    {
        free(adjacencyMatrix[row]);
    }

    free(adjacencyMatrix);
}

#endif // _RESOURCES_DISPOSAL
