#ifndef _LIBS_NAMESPACES

#include <iostream>
#include <limits.h>
#include <math.h>

using namespace std;

#endif // _LIBS_NAMESPACES

#ifndef _LOCAL_CONSTANTS

#define INVALID_VALUE INT_MAX
#define VERTICES_COUNT ( (rowsCount * colsCount) + 1 )
#define SOURCE_VERTEX (rowsCount * colsCount)
#define TARGET_VERTEX ( (rowsCount * colsCount) - 1 )

#endif // _LOCAL_CONSTANTS

#ifndef _STRUCTS_ENUMS

#endif // _STRUCTS_ENUMS

#ifndef _FUNCTION_PROTOTYPES

int abs(int number);
void ExtractPath();
void CalculateShortestPath();
void BuildGraph();
void ExtractPath(int vertexIndex);
bool IsPathAvailable(int source, int target);
void PrintPath();
void PrintGraph();
void ProcessInput();
void InitialiseResources();
void DisposeResources();

#endif // _FUNCTION_PROTOTYPES

#ifndef _LOCAL_DATA

static int ** inputMatrix;
static int ** adjMatrix;
static int * path;

static int rowsCount;
static int colsCount;
static int pathSize;

#endif // _LOCAL_DATA

#ifndef _MAIN

int main()
{
    ProcessInput();
    BuildGraph();
    CalculateShortestPath();
    ExtractPath(TARGET_VERTEX);
    PrintPath();
    DisposeResources();

    return 0;
}
#endif // _MAIN

#ifndef _ALGO_IMPLEMENTATION

// Implementing Floyd-Warshall Algorithm for shortestPath
void CalculateShortestPath()
{
    for (int mid = 0; mid < VERTICES_COUNT; ++mid)
    {
        for (int left = 0; left < VERTICES_COUNT; ++left)
        {
            for (int right = 0; right < VERTICES_COUNT; ++right)
            {
                if (adjMatrix[left][mid] != INVALID_VALUE &&
                    adjMatrix[mid][right] != INVALID_VALUE)
                {
                    if (adjMatrix[left][right] > (adjMatrix[left][mid] + adjMatrix[mid][right]))
                    {
                        adjMatrix[left][right] =
                            adjMatrix[left][mid] + adjMatrix[mid][right];
                    }
                }
            }
        }
    }
}

void BuildGraph()
{
    // vI - vertexIndex
    int vI = 0;
    for (int row = 0; row < rowsCount; ++row)
    {
        for (int col = 0; col < colsCount; ++col)
        {
            adjMatrix[vI][vI] = 0;
            if (col + 1 < colsCount)
            {
                adjMatrix[vI][vI + 1] = inputMatrix[row][col + 1];
                adjMatrix[vI + 1][vI] = inputMatrix[row][col];
            }

            if (row + 1 < rowsCount)
            {
                adjMatrix[vI][vI + colsCount] = inputMatrix[row + 1][col];
                adjMatrix[vI + colsCount][vI] = inputMatrix[row][col];
            }

            ++vI;
        }
    }

    adjMatrix[vI][0] = inputMatrix[0][0];
}

void ExtractPath(int vertexIndex)
{
    path[pathSize++] = vertexIndex;
    int leftVertex = vertexIndex - 1;
    int upVertex = vertexIndex - colsCount;
    int rightVertex = vertexIndex + 1;
    int downVertex = vertexIndex + colsCount;

    int nextVertex = INVALID_VALUE;
    int currentBestPath = adjMatrix[SOURCE_VERTEX][vertexIndex];

    if (IsPathAvailable(vertexIndex, upVertex) &&
        adjMatrix[SOURCE_VERTEX][upVertex] < currentBestPath)
    {
        currentBestPath = adjMatrix[SOURCE_VERTEX][upVertex];
        nextVertex = upVertex;
    }

    if (IsPathAvailable(vertexIndex, leftVertex) &&
        adjMatrix[SOURCE_VERTEX][leftVertex] < currentBestPath)
    {
        currentBestPath = adjMatrix[SOURCE_VERTEX][leftVertex];
        nextVertex = leftVertex;
    }

    if (IsPathAvailable(vertexIndex, rightVertex) &&
        adjMatrix[SOURCE_VERTEX][rightVertex] < currentBestPath)
    {
        currentBestPath = adjMatrix[SOURCE_VERTEX][rightVertex];
        nextVertex = rightVertex;
    }

    if (IsPathAvailable(vertexIndex, downVertex) &&
        adjMatrix[SOURCE_VERTEX][downVertex] < currentBestPath)
    {
        currentBestPath = adjMatrix[SOURCE_VERTEX][downVertex];
        nextVertex = downVertex;
    }

    if (nextVertex != INVALID_VALUE)
    {
        ExtractPath(nextVertex);
    }
}

bool IsPathAvailable(int source, int target)
{
    if (source >= 0 && source < (VERTICES_COUNT - 1) &&
        target >= 0 && target < (VERTICES_COUNT - 1))
    {
        int srcCol = source % colsCount;
        int srcRow = (source - srcCol) / colsCount;
        int targetCol = target % colsCount;
        int targetRow = (target - targetCol) / colsCount;

        return (srcCol == targetCol && abs(targetRow - srcRow) == 1) ||
               (srcRow == targetRow && abs(targetCol - srcCol) == 1);
    }

    return false;
}

int abs(int number)
{
    return number >= 0 ? number : -number;
}

#endif // _ALGO_IMPLEMENTATION

#ifndef _IO_PROCESSING

void ProcessInput()
{
    cin >> rowsCount;
    cin >> colsCount;

    InitialiseResources();

    for (int row = 0; row < rowsCount; ++row)
    {
        for (int col = 0; col < colsCount; ++col)
        {
            cin >> inputMatrix[row][col];
        }
    }
}

void PrintPath()
{
    cout << "Length: " << adjMatrix[SOURCE_VERTEX][TARGET_VERTEX] << endl;
    cout << "Path:";
    for (int i = pathSize - 1; i >= 0; --i)
    {
        int col = path[i] % colsCount;
        int row = (path[i] - col) / colsCount;

        cout << " " << inputMatrix[row][col];
    }

    cout << endl;
}

// Used for debugging
void PrintGraph()
{
    for (int row = 0; row < VERTICES_COUNT; ++row)
    {
        for (int col = 0; col < VERTICES_COUNT; ++col)
        {
            if (adjMatrix[row][col] != INVALID_VALUE)
            {
                cout << adjMatrix[row][col] << " ";
            }
            else
            {
                cout << -1 << " ";
            }
        }

        cout << endl;
    }
}

#endif // _IO_PROCESSING


#ifndef _RESOURCES_MANAGEMENT

void InitialiseResources()
{
    inputMatrix = new int*[rowsCount];
    adjMatrix = new int*[VERTICES_COUNT];
    path = new int[VERTICES_COUNT];

    for (int row = 0; row < rowsCount; ++row)
    {
        inputMatrix[row] = new int[colsCount];
    }

    for (int vI = 0; vI < VERTICES_COUNT; ++vI)
    {
        adjMatrix[vI] = new int[VERTICES_COUNT];
        for (int col = 0; col < VERTICES_COUNT; ++col)
        {
            adjMatrix[vI][col] = INVALID_VALUE;
        }
    }
}

void DisposeResources()
{
    for (int row = 0; row < rowsCount; ++row)
    {
        delete[] inputMatrix[row];
    }

    for (int row = 0; row < VERTICES_COUNT; ++row)
    {
        delete[] adjMatrix[row];
    }

    delete[] inputMatrix;
    delete[] adjMatrix;
    delete[] path;
}

#endif // _RESOURCES_DISPOSAL
