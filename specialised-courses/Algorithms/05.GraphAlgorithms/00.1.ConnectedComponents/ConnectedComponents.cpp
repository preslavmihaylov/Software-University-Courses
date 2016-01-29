#ifndef _LIBS_NAMESPACES

#include <iostream>
#include <sstream>
#include <stdlib.h>

using namespace std;

#endif // _LIBS_NAMESPACES

#ifndef _LOCAL_CONSTANTS

#define MAX_DATA 50
#define DELIMITER ' '

#endif // _LOCAL_CONSTANTS

#ifndef _STRUCTS_ENUMS

typedef struct
{
    int edges[MAX_DATA];
    int edgesCount;
} Vertex;

#endif // _STRUCTS_ENUMS

#ifndef _FUNCTION_PROTOTYPES

void FindConnectedComponents();
void MarkConnectedComponents(int currentVertexIndex);
void ProcessInput();
void PrintGraph();
void PrintCurrentConnectedComponents(int length);

#endif // _FUNCTION_PROTOTYPES

#ifndef _LOCAL_DATA

static Vertex vertices[MAX_DATA];
static bool visitedVertices[MAX_DATA];
static int currentConnectedComponents[MAX_DATA];

static int currentConnectedComponentsIndex;
static int verticesCount;

#endif // _LOCAL_DATA

#ifndef _MAIN

int main()
{
    ProcessInput();
    FindConnectedComponents();

    return 0;
}

#endif // _MAIN

void FindConnectedComponents()
{
    for (int index = 0; index < verticesCount; index++)
    {
        if (!visitedVertices[index])
        {
            MarkConnectedComponents(index);
            PrintCurrentConnectedComponents(currentConnectedComponentsIndex);

            currentConnectedComponentsIndex = 0;
        }
    }
}

void MarkConnectedComponents(int currentVertexIndex)
{
    if (visitedVertices[currentVertexIndex])
    {
        // TODO:
        return;
    }

    currentConnectedComponents[currentConnectedComponentsIndex] = currentVertexIndex;
    currentConnectedComponentsIndex++;

    visitedVertices[currentVertexIndex] = true;
    Vertex vertex = vertices[currentVertexIndex];

    for (int index = 0; index < vertex.edgesCount; index++)
    {
        MarkConnectedComponents(vertex.edges[index]);
    }
}

#ifndef _IO_PROCESSING

void ProcessInput()
{
    cin >> verticesCount;
    cin.ignore();

    string input;
    string currentToken;

    for (int index = 0; index < verticesCount; index++)
    {
        getline(cin, input);
        stringstream ss(input);

        int edgeIndex = 0;
        while ( getline(ss, currentToken, DELIMITER) )
        {
            vertices[index].edges[edgeIndex] = atoi(currentToken.c_str());
            edgeIndex++;
        }

        vertices[index].edgesCount = edgeIndex;
    }
}

void PrintGraph()
{
    for (int index = 0; index < verticesCount; index++)
    {
        cout << index << " -> ";
        for (int edgeIndex = 0; edgeIndex < vertices[index].edgesCount; edgeIndex++)
        {
            cout << vertices[index].edges[edgeIndex] << " ";
        }

        cout << endl;
    }
}

void PrintCurrentConnectedComponents(int length)
{
    cout << "Connected component: ";

    for (int index = 0; index < length; index++)
    {
        cout << currentConnectedComponents[index] << " ";
    }

    cout << endl;
}

#endif // _IO_PROCESSING
