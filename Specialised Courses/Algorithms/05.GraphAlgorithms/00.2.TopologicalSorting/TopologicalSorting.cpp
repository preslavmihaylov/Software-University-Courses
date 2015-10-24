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
    int descendants[MAX_DATA];
    int predecessorsCount;
    int descendantsCount;
} Vertex;

#endif // _STRUCTS_ENUMS

#ifndef _FUNCTION_PROTOTYPES

void TopologicalSort();
bool HasCycles();
void ProcessInput();
void PrintSortedElements();
void PrintCyclesDetectionError();
void PrintGraph();

#endif // _FUNCTION_PROTOTYPES

#ifndef _LOCAL_DATA

static Vertex vertices[MAX_DATA];
static bool extractedVertices[MAX_DATA];
static int sortedElements[MAX_DATA];

static int sortedElementsIndex;
static int verticesCount;

#endif // _LOCAL_DATA

#ifndef _MAIN

int main()
{
    ProcessInput();
    TopologicalSort();

    if (!HasCycles())
    {
        PrintSortedElements();
    }
    else
    {
        PrintCyclesDetectionError();
    }

    return 0;
}

#endif // _MAIN

#ifndef _TOPOLOGICAL_SORT

void TopologicalSort()
{
    bool rootNodeFound = true;

    while (rootNodeFound)
    {
        rootNodeFound = false;

        for (int index = 0; index < verticesCount; index++)
        {
            if (!extractedVertices[index] && vertices[index].predecessorsCount <= 0)
            {
                sortedElements[sortedElementsIndex] = index;
                sortedElementsIndex++;

                extractedVertices[index] = true;
                rootNodeFound = true;

                for (int descIndex = 0; descIndex < vertices[index].descendantsCount; descIndex++)
                {
                    int currentDescIndex = vertices[index].descendants[descIndex];
                    vertices[currentDescIndex].predecessorsCount--;
                }
            }
        }
    }
}

bool HasCycles()
{
    for (int index = 0; index < verticesCount; index++)
    {
        if (!extractedVertices[index])
        {
            return true;
        }
    }

    return false;
}

#endif // _TOPOLOGICAL_SORT

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

        int descendantsIndex = 0;
        while ( getline(ss, currentToken, DELIMITER) )
        {
            int currentVertex = atoi(currentToken.c_str());
            vertices[index].descendants[descendantsIndex] = currentVertex;
            descendantsIndex++;

            vertices[currentVertex].predecessorsCount++;
        }

        vertices[index].descendantsCount = descendantsIndex;
    }
}

void PrintSortedElements()
{
    cout << "Topological sort:" << endl;
    for (int index = 0; index < verticesCount; index++)
    {
        cout << sortedElements[index] << " ";
    }
    cout << endl;
}

void PrintCyclesDetectionError()
{
    cout << "Cycles detected" << endl;
}

void PrintGraph()
{
    for (int index = 0; index < verticesCount; index++)
    {
        cout << (char)(index + 'A') << " -> ";
        for (int descendantsIndex = 0;
                 descendantsIndex < vertices[index].descendantsCount;
                 descendantsIndex++)
        {
            cout << (char)(vertices[index].descendants[descendantsIndex] + 'A') << " ";
        }

        cout << " PR CNT: " << vertices[index].predecessorsCount;
        cout << endl;
    }
}

#endif // _IO_PROCESSING
