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

typedef struct
{
    int firstVertex;
    int secondVertex;
    int weight;
} Edge;

#endif // _STRUCTS_ENUMS

#ifndef _FUNCTION_PROTOTYPES

void FindShortestPath();
bool FindCycles();
bool ExtractShortestPath();
void InitializeResources();
void ProcessInput();
void PrintMatrix();
void PrintInfo();
void PrintShortestPath();
void PrintPathNotFound();
void PrintCyclesFound();
void DisposeResources();

#endif // _FUNCTION_PROTOTYPES

#ifndef _LOCAL_DATA

static int * distances;
static int * previous;
static Edge * edges;
static int * cycle;
static int * shortestPath;

static int shortestPathLength;
static int cycleNodesCount;
static int edgesCount;
static int nodesCount;
static int source;
static int destination;

#endif // _LOCAL_DATA

#ifndef _MAIN

int main()
{
    ProcessInput();
    FindShortestPath();

    if (FindCycles())
    {
        PrintCyclesFound();
    }
    else if (ExtractShortestPath())
    {
        PrintShortestPath();
    }
    else
    {
        PrintPathNotFound();
    }

    DisposeResources();
    return 0;
}
#endif // _MAIN

#ifndef _ALGO_IMPLEMENTATION

// Implementing the Bellman-Ford Algorithm
void FindShortestPath()
{
    for (int index = 0; index < nodesCount; ++index)
    {
        for (int edgeIndex = 0; edgeIndex < edgesCount; ++edgeIndex)
        {
            Edge edge = edges[edgeIndex];
            int currentDistance =
                edge.weight + distances[edge.firstVertex];

            if (currentDistance < distances[edge.secondVertex] &&
                edge.secondVertex != source &&
                distances[edge.firstVertex] != INT_MAX)
            {
                distances[edge.secondVertex] = currentDistance;
                previous[edge.secondVertex] = edge.firstVertex;

            }
        }
    }
}

bool ExtractShortestPath()
{
    if (previous[destination] == -1)
    {
        return false;
    }

    int previousNode = destination;

    while (previousNode != -1)
    {
        shortestPath[shortestPathLength] = previousNode;
        ++shortestPathLength;
        previousNode = previous[previousNode];
    }

    return true;
}

bool FindCycles()
{
    for (int edgeIndex = 0; edgeIndex < edgesCount; ++edgeIndex)
    {
        Edge edge = edges[edgeIndex];

        if (distances[edge.secondVertex] >
                distances[edge.firstVertex] + edge.weight)
        {
            int previousNode = previous[edge.secondVertex];

            cycle[cycleNodesCount++] = previousNode;

            while (previousNode != edge.secondVertex)
            {
                previousNode = previous[previousNode];
                cycle[cycleNodesCount++] = previousNode;
            }

            return true;
        }
    }

    return false;
}

#endif // _ALGO_IMPLEMENTATION

#ifndef _IO_PROCESSING

void InitializeResources()
{
    distances = (int*)malloc(sizeof(int) * nodesCount);
    previous = (int*)malloc(sizeof(int) * nodesCount);
    edges = (Edge*)malloc(sizeof(Edge) * edgesCount);
    cycle = (int*)malloc(sizeof(int) * nodesCount);
    shortestPath = (int*)malloc(sizeof(int) * nodesCount);

    for (int index = 0; index < nodesCount; ++index)
    {
        if (index == source)
        {
            distances[index] = 0;
        }
        else
        {
            distances[index] = INT_MAX;
        }

        previous[index] = -1;
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
    source = atoi(input);
    cin >> input; // Ignore irrelevant string
    cin >> input;
    destination = atoi(input);

    cin >> input; // Ignore irrelevant string
    cin >> input;
    edgesCount = atoi(input);

    InitializeResources();

    for (int edgeIndex = 0; edgeIndex < edgesCount; ++edgeIndex)
    {
        int firstVertex;
        int secondVertex;
        int weight;

        cin >> firstVertex;
        cin >> secondVertex;
        cin >> weight;

        edges[edgeIndex].firstVertex = firstVertex;
        edges[edgeIndex].secondVertex = secondVertex;
        edges[edgeIndex].weight = weight;
    }
}

// Used for debugging
void PrintInfo()
{
    for (int index = 0; index < nodesCount; ++index)
    {
        printf("D: %d P: %d\n", distances[index], previous[index]);
    }
}

void PrintShortestPath()
{
    printf("Distance: %d\n", distances[destination]);

    for (int index = shortestPathLength - 1; index >= 0; --index)
    {
        printf("%d", shortestPath[index]);

        if (index != 0)
        {
            printf(" -> ");
        }
    }
}

void PrintPathNotFound()
{
    cout << "Path not found" << endl;
}

void PrintCyclesFound()
{
    cout << "Negative cycle" << endl;

    for (int index = cycleNodesCount - 1; index >= 0; --index)
    {
        printf("%d", cycle[index]);

        if (index != 0)
        {
            printf(" -> ");
        }
    }
}

#endif // _IO_PROCESSING

#ifndef _RESOURCES_DISPOSAL

void DisposeResources()
{
    free(distances);
    free(previous);
    free(edges);
    free(cycle);
    free(shortestPath);
}

#endif // _RESOURCES_DISPOSAL
