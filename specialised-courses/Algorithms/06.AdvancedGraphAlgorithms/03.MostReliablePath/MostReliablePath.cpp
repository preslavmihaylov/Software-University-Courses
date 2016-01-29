#ifndef _LIBS_NAMESPACES

#include <iostream>
#include <sstream>
#include <iomanip>

using namespace std;

#endif // _LIBS_NAMESPACES

#ifndef _LOCAL_CONSTANTS

#define MAX_DATA 50

#endif // _LOCAL_CONSTANTS

#ifndef _STRUCTS_ENUMS

#endif // _STRUCTS_ENUMS

#ifndef _FUNCTION_PROTOTYPES

void FindShortestPath(int source, int destination);
void ExtractShortestPath();
void ProcessInput();
void PrintShortestPath();

#endif // _FUNCTION_PROTOTYPES

#ifndef _LOCAL_DATA

static float adjacencyMatrix[MAX_DATA][MAX_DATA];
static float reliabilities[MAX_DATA];
static bool visitedVertices[MAX_DATA];
static int previousNodes[MAX_DATA];
static int shortestPath[MAX_DATA];

static float shortestPathReliability;
static int shortestPathNodesCount;
static int verticesCount;

static int sourceNode;
static int destinationNode;

#endif // _LOCAL_DATA

#ifndef _MAIN

/*

Example 1:
10
0 3 85
0 4 88
3 1 95
3 5 98
4 5 99
4 2 14
5 1 5
5 6 90
1 6 100
2 6 95
0
6

Example 2:
4
0 1 94
0 2 97
2 3 99
1 3 98
0
1

*/

int main()
{
    ProcessInput();
    FindShortestPath(sourceNode, destinationNode);
    ExtractShortestPath();
    PrintShortestPath();

    return 0;
}

#endif // _MAIN

#ifndef _ALGO_IMPLEMENTATION

void FindShortestPath(int source, int destination)
{
    for (int index = 0; index < verticesCount; index++)
    {
        previousNodes[index] = -1;
        if (index != source)
        {
            reliabilities[index] = 0;
        }
        else
        {
            reliabilities[index] = 100.0f;
        }
    }

    while (true)
    {
        int maxReliability = 0;
        int minNode = 0;

        for (int index = 0; index < verticesCount; index++)
        {
            if (!visitedVertices[index] && maxReliability < reliabilities[index])
            {
                minNode = index;
                maxReliability = reliabilities[index];
            }
        }

        if (maxReliability == 0)
        {
            break;
        }

        for (int col = 0; col < verticesCount; col++)
        {
            if (adjacencyMatrix[minNode][col] != 0)
            {
                float currentReliability =
                    reliabilities[minNode] *
                    (adjacencyMatrix[minNode][col] / 100);

                if (currentReliability > reliabilities[col])
                {
                    reliabilities[col] = currentReliability;
                    previousNodes[col] = minNode;
                }
            }
        }

        visitedVertices[minNode] = true;
    }
}

void ExtractShortestPath()
{
    shortestPathReliability = reliabilities[destinationNode];
    int currentNode = destinationNode;

    while (previousNodes[currentNode] != -1)
    {
        shortestPath[shortestPathNodesCount] = currentNode;
        currentNode = previousNodes[currentNode];
        ++shortestPathNodesCount;
    }
}

#endif // _ALGO_IMPLEMENTATION

#ifndef _IO_PROCESSING

void ProcessInput()
{
    int edgesCount;
    cin >> edgesCount;

    for (int index = 0; index < edgesCount; index++)
    {
        int firstVertex;
        int secondVertex;
        float weight;

        cin >> firstVertex;
        cin >> secondVertex;
        cin >> weight;

        adjacencyMatrix[firstVertex][secondVertex] = weight;
        adjacencyMatrix[secondVertex][firstVertex] = weight;

        int maxVertexIndex = max(firstVertex, secondVertex);
        if (maxVertexIndex >= verticesCount)
        {
            verticesCount = maxVertexIndex + 1;
        }
    }

    cout << "Source: ";
    cin >> sourceNode;
    cout << "Destination: ";
    cin >> destinationNode;
}

void PrintShortestPath()
{
    if (shortestPathReliability != 0)
    {
        cout << "Reliability: "
             << fixed
             << setprecision(2)
             << shortestPathReliability
             << endl;

        cout << "Path: ";

        for (int index = shortestPathNodesCount; index >= 0; --index)
        {
            cout << shortestPath[index] << " ";
        }

        cout << endl;
    }
    else
    {
        cout << "No path found" << endl;
    }
}

// Used for debugging
void PrintGraph()
{
    for (int row = 0; row < verticesCount; row++)
    {
        cout << row << " -> ";
        for (int col = 0; col < verticesCount; col++)
        {
            if (adjacencyMatrix[row][col])
            {
                cout << "(N: "
                     << col
                     << " W: "
                     << adjacencyMatrix[row][col]
                     << ") ";
            }
        }
        cout << endl;
    }
}

#endif // _IO_PROCESSING
