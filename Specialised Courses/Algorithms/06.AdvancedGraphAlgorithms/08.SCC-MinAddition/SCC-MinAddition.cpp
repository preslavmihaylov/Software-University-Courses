#ifndef _LIBS_NAMESPACES

#include <iostream>
#include <stdio.h>

using namespace std;

#endif // _LIBS_NAMESPACES

#ifndef _LOCAL_CONSTANTS_MACROS

#define MAX_INPUT_LENGTH 10
#define RESULT_NOT_FOUND -1

#define PRED_COUNT(vertexIndex) (vertices[vertexIndex].predecessorsCount)
#define DESC_COUNT(vertexIndex) (vertices[vertexIndex].descendantsCount)
#define SCC_MEMBERS_COUNT(sccIndex) (connectedComps[sccIndex].membersCount)

#endif // _LOCAL_CONSTANTS_MACROS

#ifndef _STRUCTS_ENUMS

typedef struct
{
    int * descendants;
    int * predecessors;
    int descendantsCount;
    int predecessorsCount;
} Vertex;

typedef struct
{
    int * members;
    int membersCount;
} ConnectedComp;

typedef struct
{
    int sourceScc;
    int destScc;
} SccEdge;

#endif // _STRUCTS_ENUMS

#ifndef _FUNCTION_PROTOTYPES

void FindSCC();
void AddMinSccEdges();
bool ConnectIslands();
void ConnectLeftoverComponents();
void ConnectSCC(int vertexIndex);
void AddElementsToOperationStack(int vertexIndex);
int FindFirstFreeSCC();
void InitializeSCCs();
void ClearVisitedVertices();
void PrintSCC();
void PrintGraph();
void PrintEdgesToAdd();
void ProcessInput();
void InitializeResources();
void DisposeResources();

#endif // _FUNCTION_PROTOTYPES

#ifndef _LOCAL_DATA

static Vertex * vertices;

static int verticesCount;

// Algorithm utils
static ConnectedComp * connectedComps;
static SccEdge * matchingSccEdges;
static SccEdge * leftoverSccEdges;
static SccEdge * sccEdgesToAdd;
static int * operationStack;
static bool * visitedVertices;
static bool * visitedScc;
static int * vertexSccIndexes;

static int visitedSccCount;
static int sccEdgesToAddCount;
static int leftoverSccEdgesCount;
static int matchingSccEdgesCount;
static int stackSize;
static int sccCount;

#endif // _LOCAL_DATA

#ifndef _MAIN

int main()
{
    ProcessInput();
    FindSCC();
    PrintEdgesToAdd();
    PrintSCC();
    // PrintGraph();
    DisposeResources();

    return 0;
}
#endif // _MAIN

#ifndef _ALGO_IMPLEMENTATION

// SCC - Strongly Connected Components
void FindSCC()
{
    for (int vertexIndex = 0; vertexIndex < verticesCount; ++vertexIndex)
    {
        if (!visitedVertices[vertexIndex])
        {
            AddElementsToOperationStack(vertexIndex);
        }
    }

    ClearVisitedVertices();

    for (int stackIndex = stackSize - 1; stackIndex >= 0; --stackIndex)
    {
        int vertexIndex = operationStack[stackIndex];
        if (!visitedVertices[vertexIndex])
        {
            ConnectSCC(vertexIndex);
            ++sccCount;
        }
    }

    AddMinSccEdges();
}

void AddMinSccEdges()
{
    bool hasConnected = ConnectIslands();
    int upperBound = matchingSccEdgesCount;

    if (hasConnected)
    {
        --upperBound;
    }

    for (int sccEdgeIndex = 0; sccEdgeIndex < upperBound; ++sccEdgeIndex)
    {
        SccEdge currentEdge = matchingSccEdges[sccEdgeIndex];
        SccEdge nextEdge = matchingSccEdges[(sccEdgeIndex + 1) % matchingSccEdgesCount];

        sccEdgesToAdd[sccEdgesToAddCount].sourceScc = currentEdge.destScc;
        sccEdgesToAdd[sccEdgesToAddCount].destScc = nextEdge.sourceScc;
        ++sccEdgesToAddCount;
    }

    ConnectLeftoverComponents();
}

void ConnectLeftoverComponents()
{
    int * leftoverSources = new int[leftoverSccEdgesCount];
    int * leftoverSinks = new int[leftoverSccEdgesCount];
    int leftoverSourcesCount = 0;
    int leftoverSinksCount = 0;
    int index;

    for (index = 0; index < leftoverSccEdgesCount; ++index)
    {
        SccEdge currentEdge = leftoverSccEdges[index];
        if (!visitedScc[currentEdge.sourceScc])
        {
            leftoverSources[leftoverSourcesCount] = currentEdge.sourceScc;
            ++leftoverSourcesCount;
            visitedScc[currentEdge.sourceScc] = true;
        }
        else if (!visitedScc[currentEdge.destScc])
        {
            leftoverSinks[leftoverSinksCount] = currentEdge.destScc;
            ++leftoverSinksCount;
            visitedScc[currentEdge.destScc] = true;
        }
    }

    for (index = 0; index < min(leftoverSourcesCount, leftoverSinksCount); ++index)
    {
        sccEdgesToAdd[sccEdgesToAddCount].sourceScc = leftoverSinks[index];
        sccEdgesToAdd[sccEdgesToAddCount].destScc = leftoverSources[index];
        ++sccEdgesToAddCount;
    }

    for (index = min(leftoverSourcesCount, leftoverSinksCount);
         index < max(leftoverSourcesCount, leftoverSinksCount);
         ++index)
    {
        int connectedSccIndex = matchingSccEdges[0].sourceScc;

        if (leftoverSinksCount > index)
        {
            sccEdgesToAdd[sccEdgesToAddCount].sourceScc = leftoverSinks[index];
            sccEdgesToAdd[sccEdgesToAddCount].destScc = connectedSccIndex;
            ++sccEdgesToAddCount;
        }
        else
        {
            sccEdgesToAdd[sccEdgesToAddCount].sourceScc = connectedSccIndex;
            sccEdgesToAdd[sccEdgesToAddCount].destScc = leftoverSources[index];
            ++sccEdgesToAddCount;
        }
    }

    delete[] leftoverSources;
    delete[] leftoverSinks;
}

bool ConnectIslands()
{
    for (int index = 0; index < sccCount; ++index)
    {
        if (!visitedScc[index])
        {
            if (matchingSccEdgesCount >= 1)
            {
                SccEdge currentEdge = matchingSccEdges[matchingSccEdgesCount - 1];
                SccEdge nextEdge = matchingSccEdges[0];

                sccEdgesToAdd[sccEdgesToAddCount].sourceScc = currentEdge.destScc;
                sccEdgesToAdd[sccEdgesToAddCount].destScc = index;
                ++sccEdgesToAddCount;

                sccEdgesToAdd[sccEdgesToAddCount].sourceScc = index;
                sccEdgesToAdd[sccEdgesToAddCount].destScc = nextEdge.sourceScc;
                ++sccEdgesToAddCount;

                return true;
            }
            else
            {
                int connectedSccIndex = FindFirstFreeSCC();

                sccEdgesToAdd[sccEdgesToAddCount].sourceScc = connectedSccIndex;
                sccEdgesToAdd[sccEdgesToAddCount].destScc = index;
                ++sccEdgesToAddCount;

                sccEdgesToAdd[sccEdgesToAddCount].sourceScc = index;
                sccEdgesToAdd[sccEdgesToAddCount].destScc = connectedSccIndex;
                ++sccEdgesToAddCount;
            }
        }
    }

    return false;
}

int FindFirstFreeSCC()
{
    for (int index = 0; index < sccCount; ++index)
    {
        if (visitedScc[index])
        {
            return index;
        }
    }

    return RESULT_NOT_FOUND;
}

// DFS the graph and upon leaving a vertex, add it to the operation stack
void AddElementsToOperationStack(int vertexIndex)
{
    Vertex vertex = vertices[vertexIndex];
    visitedVertices[vertexIndex] = true;

    for (int descIndex = 0; descIndex < DESC_COUNT(vertexIndex); ++descIndex)
    {
        int nextVertexIndex = vertex.descendants[descIndex];
        if (!visitedVertices[nextVertexIndex])
        {
            AddElementsToOperationStack(nextVertexIndex);
        }
    }

    operationStack[stackSize++] = vertexIndex;
}

// DFS the reversed graph and add current vertex in current SCC upon leaving
// Upon reaching a visited vertex which is part of a SCC -> that SCC is a source to the current SCC
void ConnectSCC(int vertexIndex)
{
    Vertex vertex = vertices[vertexIndex];
    visitedVertices[vertexIndex] = true;

    for (int prevIndex = 0; prevIndex < PRED_COUNT(vertexIndex); ++prevIndex)
    {
        int nextVertexIndex = vertex.predecessors[prevIndex];
        if (!visitedVertices[nextVertexIndex])
        {
            ConnectSCC(nextVertexIndex);
        }
        else if (vertexSccIndexes[nextVertexIndex] != RESULT_NOT_FOUND) // Sink SCC found
        {
            if (!visitedScc[vertexSccIndexes[nextVertexIndex]] && !visitedScc[sccCount])
            {
                matchingSccEdges[matchingSccEdgesCount].sourceScc = vertexSccIndexes[nextVertexIndex];
                matchingSccEdges[matchingSccEdgesCount].destScc = sccCount;
                ++matchingSccEdgesCount;

                visitedScc[vertexSccIndexes[nextVertexIndex]] = true;
                visitedScc[sccCount] = true;
            }
            else
            {
                leftoverSccEdges[leftoverSccEdgesCount].sourceScc = vertexSccIndexes[nextVertexIndex];
                leftoverSccEdges[leftoverSccEdgesCount].destScc = sccCount;
                ++leftoverSccEdgesCount;
            }
        }
    }

    connectedComps[sccCount].members[SCC_MEMBERS_COUNT(sccCount)] = vertexIndex;
    ++SCC_MEMBERS_COUNT(sccCount);
    vertexSccIndexes[vertexIndex] = sccCount;
}

#endif // _ALGO_IMPLEMENTATION

#ifndef _IO_PROCESSING

void ProcessInput()
{
    char input[MAX_INPUT_LENGTH];
    int edgesCount;

    cin >> input; // Ignore unnecessary string
    cin >> verticesCount;
    cin >> input; // Ignore unnecessary string
    cin >> edgesCount;

    InitializeResources();

    int vertexIndex = 0;
    for (int cnt = 0; cnt < edgesCount; ++cnt)
    {
        int source;
        int destination;

        cin >> source;
        cin >> input; // Ignore unnecessary string
        cin >> destination;

        vertices[source].descendants[DESC_COUNT(source)] = destination;
        vertices[destination].predecessors[PRED_COUNT(destination)] = source;

        ++DESC_COUNT(source);
        ++PRED_COUNT(destination);
    }
}

void PrintEdgesToAdd()
{
    for (int index = 0; index < sccEdgesToAddCount; ++index)
    {
        SccEdge currentEdge = sccEdgesToAdd[index];
        ConnectedComp source = connectedComps[currentEdge.sourceScc];
        ConnectedComp destination = connectedComps[currentEdge.destScc];
        printf("%d -----> %d\n", source.members[0], destination.members[0]);
    }
}

// Used for debugging
void PrintGraph()
{
    for (int index = 0; index < verticesCount; ++index)
    {
        cout << "Vertex: " << index;
        cout << " Parents: ";
        for (int pI = 0; pI < PRED_COUNT(index); ++pI)
        {
            cout << vertices[index].predecessors[pI] << " ";
        }

        cout << " Children: ";
        for (int dI = 0; dI < DESC_COUNT(index); ++dI)
        {
            cout << vertices[index].descendants[dI] << " ";
        }

        cout << endl;
    }
}

// Used for debugging
void PrintSCC()
{
    for (int index = 0; index < sccCount; ++index)
    {
        cout << "SCC " << index << ": ";
        for (int membIndex = 0; membIndex < SCC_MEMBERS_COUNT(index); ++membIndex)
        {
            cout << connectedComps[index].members[membIndex] << " ";
        }
        cout << endl;
    }
}

#endif // _IO_PROCESSING

#ifndef _RESOURCES_MANAGEMENT

void ClearVisitedVertices()
{
    for (int index = 0; index < verticesCount; ++index)
    {
        visitedVertices[index] = false;
    }
}

void InitializeSCCs()
{
    for (int index = 0; index < verticesCount; ++index)
    {
        connectedComps[index].members = new int[verticesCount];
        connectedComps[index].membersCount = 0;
    }
}

void InitializeResources()
{
    operationStack = new int[verticesCount];
    visitedVertices = new bool[verticesCount];
    vertices = new Vertex[verticesCount];
    connectedComps = new ConnectedComp[verticesCount];
    vertexSccIndexes = new int[verticesCount];
    matchingSccEdges = new SccEdge[verticesCount];
    leftoverSccEdges = new SccEdge[verticesCount];
    sccEdgesToAdd = new SccEdge[verticesCount];
    visitedScc = new bool[verticesCount];

    ClearVisitedVertices();
    InitializeSCCs();

    for (int index = 0; index < verticesCount; ++index)
    {
        vertices[index].predecessors = new int[verticesCount];
        vertices[index].descendants = new int[verticesCount];
        vertices[index].predecessorsCount = 0;
        vertices[index].descendantsCount = 0;
        vertexSccIndexes[index] = RESULT_NOT_FOUND;
    }
}

void DisposeResources()
{
    for (int index = 0; index < verticesCount; ++index)
    {
        delete[] vertices[index].descendants;
        delete[] vertices[index].predecessors;
        delete[] connectedComps[index].members;
    }

    delete[] connectedComps;
    delete[] vertices;
    delete[] operationStack;
    delete[] visitedVertices;
    delete[] vertexSccIndexes;
    delete[] matchingSccEdges;
    delete[] leftoverSccEdges;
    delete[] sccEdgesToAdd;
    delete[] visitedScc;
}

#endif // _RESOURCES_DISPOSAL
