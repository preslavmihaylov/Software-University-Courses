#ifndef _LIBS_NAMESPACES

#include <iostream>
#include <limits.h>
#include <queue>

using namespace std;

#endif // _LIBS_NAMESPACES

#ifndef _LOCAL_CONSTANTS

#define MAX_DATA 50

#endif // _LOCAL_CONSTANTS

#ifndef _FUNCTION_PROTOTYPES

void FindShortestPath(int source, int destination);
void ExtractShortestPath(int destination);
void ProcessInput();
void PrintGraph();
void PrintShortestPath();

#endif // _FUNCTION_PROTOTYPES

#ifndef _LOCAL_DATA

static int adjacencyMatrix[MAX_DATA][MAX_DATA];
static int distances[MAX_DATA];
static bool visitedVertices[MAX_DATA];
static int previousNodes[MAX_DATA];
static int shortestPath[MAX_DATA];

static int shortestPathWeight;
static int shortestPathNodesCount;
static int verticesCount;

static int sourceNode;
static int destinationNode;

#endif // _LOCAL_DATA

#ifndef _STRUCTS_ENUMS

struct Node
{
    int nodeIndex;

    inline bool operator>(Node a) {
        return distances[nodeIndex] > distances[a.nodeIndex];
    }
};

typedef struct Node Node;

// Compare function for nodes
typedef bool (*comp)(Node, Node);
bool compareNodes(Node a, Node b)
{
   return ( a > b );
}

#endif // _STRUCTS_ENUMS

#ifndef _MAIN

/*
Example input 1:
11
0 5 4
0 3 9
0 8 5
3 8 20
3 5 2
3 6 8
8 6 7
6 2 12
4 1 8
4 7 10
1 7 7
0
2

Expected: 24
Path: 0 8 6 2

Example input 2:
18
0 6 10
0 8 12
6 4 17
6 5 6
8 5 3
8 2 14
4 1 20
4 11 11
4 5 5
5 11 33
2 11 9
2 7 15
11 1 6
11 7 20
1 9 5
1 7 26
7 9 3
3 10 7
0
9

Expected: 42 weight
Path: 0 8 5 4 11 1 9

*/

int main()
{
    ProcessInput();
    FindShortestPath(sourceNode, destinationNode);
    ExtractShortestPath(destinationNode);
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
        if (index == source)
        {
            distances[index] = 0;
        }
        else
        {
            distances[index] = INT_MAX;
        }
    }

    priority_queue<Node, vector<Node>, comp>
        priorityQueue(compareNodes);

    Node * sourceNode = new Node;
    sourceNode->nodeIndex = source;

    priorityQueue.push( (*sourceNode) );
    visitedVertices[source] = true;

    while (priorityQueue.size() > 0)
    {
        Node currentNode = priorityQueue.top();
        priorityQueue.pop();
        int currentNodeIndex = currentNode.nodeIndex;

        for (int col = 0; col < verticesCount; col++)
        {
            if (adjacencyMatrix[currentNodeIndex][col] != 0)
            {
                int currentDistance =
                    distances[currentNodeIndex] +
                    adjacencyMatrix[currentNodeIndex][col];

                if (currentDistance < distances[col])
                {
                    distances[col] = currentDistance;
                    previousNodes[col] = currentNodeIndex;
                }

                if (!visitedVertices[col])
                {
                    Node* node = new Node;
                    node->nodeIndex = col;

                    priorityQueue.push( (*node) );
                    visitedVertices[col] = true;
                }
            }
        }

        delete &currentNode;
    }
}

void ExtractShortestPath(int destination)
{
    shortestPathWeight = distances[destination];

    int currentNode = destination;
    while (currentNode != -1)
    {
        shortestPath[shortestPathNodesCount] = currentNode;
        currentNode = previousNodes[currentNode];
        shortestPathNodesCount++;
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
        int weight;

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
    if (shortestPathWeight == INT_MAX)
    {
        cout << "No path found" << endl;
    }
    else
    {
        cout << "Shortest path weight: " << shortestPathWeight << endl;
        cout << "Path: ";

        for (int index = shortestPathNodesCount - 1; index >= 0; --index)
        {
            cout << shortestPath[index] << " ";
        }

        cout << endl;
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
