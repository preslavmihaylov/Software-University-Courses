#include <iostream>

#define MAX_DATA 50

using namespace std;

/* FUNCTION PROTOTYPES */
void CheckForCyclicity();
bool IsCyclic(int vertexIndex);
void CheckForCyclicity();
void ProcessInput();
void PrintResult(bool isCyclic);

typedef struct
{
    int edges[MAX_DATA];
    int edgesCount;
} Vertex;

static int verticesCount;

static Vertex vertices[MAX_DATA];
static bool visited[MAX_DATA];

int main()
{
    ProcessInput();
    CheckForCyclicity();

    return 0;
}

void CheckForCyclicity()
{
    for (int index = 0; index < verticesCount; index++)
    {
        if (!visited[index] && IsCyclic(index))
        {
            PrintResult(true);
            return;
        }
    }

    PrintResult(false);
}

bool IsCyclic(int vertexIndex)
{
    if (visited[vertexIndex])
    {
        return true;
    }

    visited[vertexIndex] = true;
    Vertex vertex = vertices[vertexIndex];

    for (int index = 0; index < vertex.edgesCount; index++)
    {
        bool isCyclic = IsCyclic(vertex.edges[index]);

        if (isCyclic)
        {
            return true;
        }
    }

    return false;
}

void ProcessInput()
{
    cin >> verticesCount;

    for (int count = 0; count < verticesCount; count++)
    {
        char firstLetter;
        char secondLetter;

        cin >> firstLetter;
        cin >> secondLetter; // Ignore the '-' character
        cin >> secondLetter;

        int edgesCount = vertices[firstLetter - 'A'].edgesCount;
        vertices[firstLetter - 'A'].edges[edgesCount] = secondLetter - 'A';
        vertices[firstLetter - 'A'].edgesCount++;
    }
}

void PrintResult(bool isCyclic)
{
    if (isCyclic)
    {
        cout << "Acyclic: No" << endl;
    }
    else
    {
        cout << "Acyclic: Yes" << endl;
    }
}
