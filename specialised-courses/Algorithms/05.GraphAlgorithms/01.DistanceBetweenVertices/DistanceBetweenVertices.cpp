#include <stdio.h>
#include <queue>
#include <limits.h>

#define MAX_DATA 50

using namespace std;

/* FUNCTION PROTOTYPES */
void FindDistances();
int FindDistance(int firstVertex, int secondVertex);
void InitilizeGraph();
void PrintResult(int firstVertex,
                 int secondVertex,
                 int distance);
void InitializeFirstSample();
void InitializeSecondSample();
void InitializeThirdSample();

/* STRUCTS */
typedef struct
{
    int edges[MAX_DATA];
    int edgesCount;
} Vertex;

typedef struct
{
    int firstVertex;
    int secondVertex;
} Distance;

typedef struct
{
    int vertex;
    int currentDistance;
} Sequence;

/* LOCAL DATA */
static Vertex graph[MAX_DATA];
static Distance distances[MAX_DATA];
static int verticesIndexes[MAX_DATA];

static int distancesCount;
static int verticesCount;

int main()
{
    InitilizeGraph();
    FindDistances();
    return 0;
}

void FindDistances()
{
    for (int index = 0; index < distancesCount; index++)
    {
        Distance distance = distances[index];

        int result = FindDistance(distance.firstVertex,
                                  distance.secondVertex);

        PrintResult(distance.firstVertex,
                    distance.secondVertex,
                    result);
    }
}

int FindDistance(int firstVertex, int secondVertex)
{
    bool visited[MAX_DATA];
    queue<Sequence> operationQueue;
    int shortestDistance = INT_MAX;

    Sequence currentSequence;
    currentSequence.vertex = firstVertex;
    currentSequence.currentDistance = 0;

    operationQueue.push(currentSequence);

    while (operationQueue.size() > 0)
    {
        currentSequence = operationQueue.front();
        int currentVertexIndex =
            verticesIndexes[currentSequence.vertex];

        operationQueue.pop();

        if (currentSequence.vertex == secondVertex &&
            currentSequence.currentDistance < shortestDistance)
        {
            shortestDistance = currentSequence.currentDistance;
        }

        if (!visited[currentVertexIndex])
        {
            visited[currentVertexIndex] = true;

            Vertex currentVertex =
                graph[currentVertexIndex];

            for (int count = 0; count < currentVertex.edgesCount; count++)
            {
                Sequence newSequence;
                int vertex = currentVertex.edges[count];
                newSequence.vertex = vertex;
                newSequence.currentDistance =
                    currentSequence.currentDistance + 1;

                operationQueue.push(newSequence);
            }
        }
    }

    if (shortestDistance == INT_MAX)
    {
        return -1;
    }

    return shortestDistance;
}

void InitilizeGraph()
{
    // InitializeFirstSample();
    // InitializeSecondSample();
    InitializeThirdSample();
}

void PrintResult(int firstVertex, int secondVertex, int distance)
{
    printf("{%d, %d} -> %d\n",
           firstVertex,
           secondVertex,
           distance);
}

#ifndef _GRAPH_SAMPLES

void InitializeFirstSample()
{
    graph[0].edges[0] = 2;
    graph[0].edgesCount = 1;

    graph[1].edgesCount = 0;

    verticesCount = 2;

    // Distances Initialization
    distances[0].firstVertex = 1;
    distances[0].secondVertex = 2;

    distances[1].firstVertex = 2;
    distances[1].secondVertex = 1;

    distancesCount = 2;

    // Vertices indexes
    verticesIndexes[1] = 0;
    verticesIndexes[2] = 1;
}

void InitializeSecondSample()
{
    graph[0].edges[0] = 4;
    graph[0].edgesCount = 1;

    graph[1].edges[0] = 4;
    graph[1].edgesCount = 1;

    graph[2].edges[0] = 4;
    graph[2].edges[1] = 5;
    graph[2].edgesCount = 2;

    graph[3].edges[0] = 6;
    graph[3].edgesCount = 1;

    graph[4].edges[0] = 3;
    graph[4].edges[1] = 7;
    graph[4].edges[2] = 8;
    graph[4].edgesCount = 3;

    graph[5].edgesCount = 0;

    graph[6].edges[0] = 8;
    graph[6].edgesCount = 1;

    graph[7].edgesCount = 0;

    verticesCount = 8;

    // Distances Initialization
    distances[0].firstVertex = 1;
    distances[0].secondVertex = 6;

    distances[1].firstVertex = 1;
    distances[1].secondVertex = 5;

    distances[2].firstVertex = 5;
    distances[2].secondVertex = 6;

    distances[3].firstVertex = 5;
    distances[3].secondVertex = 8;

    distancesCount = 4;

    // Vertices indexes
    verticesIndexes[1] = 0;
    verticesIndexes[2] = 1;
    verticesIndexes[3] = 2;
    verticesIndexes[4] = 3;
    verticesIndexes[5] = 4;
    verticesIndexes[6] = 5;
    verticesIndexes[7] = 6;
    verticesIndexes[8] = 7;
}

void InitializeThirdSample()
{
    graph[0].edges[0] = 4;
    graph[0].edgesCount = 1;

    graph[1].edges[0] = 12;
    graph[1].edges[1] = 1;
    graph[1].edgesCount = 2;

    graph[2].edges[0] = 12;
    graph[2].edges[1] = 21;
    graph[2].edges[2] = 7;
    graph[2].edgesCount = 3;

    graph[3].edges[0] = 21;
    graph[3].edgesCount = 1;

    graph[4].edges[0] = 4;
    graph[4].edges[1] = 19;
    graph[4].edgesCount = 2;

    graph[5].edges[0] = 1;
    graph[5].edges[1] = 21;
    graph[5].edgesCount = 2;

    graph[6].edges[0] = 14;
    graph[6].edges[1] = 31;
    graph[6].edgesCount = 2;

    graph[7].edges[0] = 14;
    graph[7].edgesCount = 1;

    graph[8].edgesCount = 0;

    verticesCount = 9;

    // Distances Initialization
    distances[0].firstVertex = 11;
    distances[0].secondVertex = 7;

    distances[1].firstVertex = 11;
    distances[1].secondVertex = 21;

    distances[2].firstVertex = 21;
    distances[2].secondVertex = 4;

    distances[3].firstVertex = 19;
    distances[3].secondVertex = 14;

    distances[4].firstVertex = 1;
    distances[4].secondVertex = 4;

    distances[5].firstVertex = 1;
    distances[5].secondVertex = 11;

    distances[6].firstVertex = 31;
    distances[6].secondVertex = 21;

    distances[7].firstVertex = 11;
    distances[7].secondVertex = 14;

    distancesCount = 8;

    // Vertices indexes
    verticesIndexes[11] = 0;
    verticesIndexes[4] = 1;
    verticesIndexes[1] = 2;
    verticesIndexes[7] = 3;
    verticesIndexes[12] = 4;
    verticesIndexes[19] = 5;
    verticesIndexes[21] = 6;
    verticesIndexes[14] = 7;
    verticesIndexes[31] = 8;
}

#endif
