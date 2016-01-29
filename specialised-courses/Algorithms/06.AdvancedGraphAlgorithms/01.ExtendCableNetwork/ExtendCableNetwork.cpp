#ifndef _LIBS_NAMESPACES

#include <iostream>
#include <stdio.h>
#include <sstream>
#include <limits.h>

using namespace std;

#endif // _LIBS_NAMESPACES

#ifndef _LOCAL_CONSTANTS

#define MAX_DATA 50
#define DELIMITER

#endif // _LOCAL_CONSTANTS

#ifndef _STRUCTS_ENUMS

typedef struct
{
    int firstVertex;
    int secondVertex;
    int weight;

} Edge;

#endif // _STRUCTS_ENUMS

#ifndef _FUNCTION_PROTOTYPES

void SortEdges();
void InitializeData();
int FindRoot(int vertex);
void FindMinimumSpanningTree();
void ProcessInput();
void PrintMST();
void PrintEdges();

#endif // _FUNCTION_PROTOTYPES

#ifndef _LOCAL_DATA

static int parents[MAX_DATA];
static Edge edges[MAX_DATA];
static int minSpanningTree[MAX_DATA];

static int minSpanningTreeLength;
static int edgesCount;
static int verticesCount;
static int budget;
static int budgetUsed;

#endif // _LOCAL_DATA

#ifndef _MAIN

int main()
{
    ProcessInput();
    SortEdges();
    FindMinimumSpanningTree();
    PrintMST();

    return 0;
}

#endif // _MAIN

#ifndef _ALGO_IMPLEMENTATION

void FindMinimumSpanningTree()
{
    for (int index = 0; index < edgesCount; ++index)
    {
        Edge currentEdge = edges[index];

        if (currentEdge.weight + budgetUsed < budget)
        {
            int firstRoot = FindRoot(currentEdge.firstVertex);
            int secondRoot = FindRoot(currentEdge.secondVertex);

            if (firstRoot != secondRoot)
            {
                parents[secondRoot] = firstRoot;
                minSpanningTree[minSpanningTreeLength] = index;
                minSpanningTreeLength++;

                budgetUsed += currentEdge.weight;
            }
        }
    }
}

void SortEdges()
{
    for (int index = 0; index < edgesCount; index++)
    {
        int minEdgeIndex = index;
        int minWeight = INT_MAX;

        for (int innerIndex = index;
             innerIndex < edgesCount;
             innerIndex++)
        {
            if (edges[innerIndex].weight < minWeight)
            {
                minEdgeIndex = innerIndex;
                minWeight = edges[innerIndex].weight;
            }
        }

        if (index != minEdgeIndex)
        {
            Edge temp = edges[index];
            edges[index] = edges[minEdgeIndex];
            edges[minEdgeIndex] = temp;
        }
    }
}

int FindRoot(int vertex)
{
    int currentRoot = vertex;

    while (currentRoot != parents[currentRoot])
    {
        currentRoot = parents[currentRoot];
    }

    int root = currentRoot;
    currentRoot = vertex;

    while (currentRoot != root)
    {
        int lastParent = parents[currentRoot];
        parents[currentRoot] = root;
        currentRoot = lastParent;
    }

    return root;
}

void InitializeData()
{
    for (int index = 0; index < verticesCount; index++)
    {
        parents[index] = index;
    }
}

#endif // _ALGO_IMPLEMENTATION

#ifndef _IO_PROCESSING

void ProcessInput()
{
    string input;
    string connected;
    int firstVertex;
    int secondVertex;
    int weight;

    getline(cin, input);
    stringstream firstLineStream(input);
    firstLineStream.ignore(256, ' '); // Ignore unnecessary string
    firstLineStream >> verticesCount;

    InitializeData();

    while (true)
    {
        getline(cin, input);
        stringstream ss(input);

        if (input.at(0) == 'B')
        {
            ss.ignore(256, ' '); // Ignore unnecessary string
            ss >> budget;
            break;
        }

        ss >> firstVertex;
        ss >> secondVertex;
        ss >> weight;
        ss >> connected;

        if (connected.size() == 0)
        {
            edges[edgesCount].firstVertex = firstVertex;
            edges[edgesCount].secondVertex = secondVertex;
            edges[edgesCount].weight = weight;
            edgesCount++;
        }
        else
        {
            int firstRoot = FindRoot(firstVertex);
            int secondRoot = FindRoot(secondVertex);
            parents[secondRoot] = firstRoot;
        }

        connected = "";
    }

    cout << budget << endl;
}

void PrintMST()
{
    for (int index = 0; index < minSpanningTreeLength; index++)
    {
        Edge currentEdge = edges[minSpanningTree[index]];

        printf("(%d %d) -> %d\n",
               currentEdge.firstVertex,
               currentEdge.secondVertex,
               currentEdge.weight);
    }

    cout << "Budget used: " << budgetUsed << endl;
}

// Used for debugging
void PrintEdges()
{
    for (int index = 0; index < edgesCount; index++)
    {
        printf("(%d %d) -> %d\n",
               edges[index].firstVertex,
               edges[index].secondVertex,
               edges[index].weight);
    }
}

#endif // _IO_PROCESSING

