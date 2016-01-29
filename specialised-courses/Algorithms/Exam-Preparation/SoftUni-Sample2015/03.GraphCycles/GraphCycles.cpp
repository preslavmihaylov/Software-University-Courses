#ifndef _LIBS_NAMESPACES

#include <iostream>
#include <sstream>
#include <vector>
#include <set>
#include <stdio.h>

using namespace std;

#endif // _LIBS_NAMESPACES

#ifndef _LOCAL_CONSTANTS

#endif // _LOCAL_CONSTANTS

#ifndef _STRUCTS_ENUMS

typedef struct
{
    set<int> descendants;
} Vertex;

#endif // _STRUCTS_ENUMS

#ifndef _FUNCTION_PROTOTYPES

bool VertexContainsDescendant(int vertexIndex, int descIndex);
void DetectAppropriateCycles();
void ProcessInput();
void InitializeResources();
void DisposeResources();

#endif // _FUNCTION_PROTOTYPES

#ifndef _LOCAL_DATA

static Vertex * vertices;

static int verticesCount;

#endif // _LOCAL_DATA

#ifndef _MAIN

int main()
{
    ProcessInput();
    DetectAppropriateCycles();
    DisposeResources();

    return 0;
}
#endif // _MAIN

#ifndef _ALGO_IMPLEMENTATION

void DetectAppropriateCycles()
{
    int firstVertexIndex;
    int secondVertexIndex;
    int thirdVertexIndex;
    bool resultFound = false;

    for (int index = 0; index < verticesCount; ++index)
    {
        firstVertexIndex = index;
        Vertex firstVertex = vertices[firstVertexIndex];
        for (auto firstDescItr = firstVertex.descendants.begin();
             firstDescItr != firstVertex.descendants.end();
             ++firstDescItr)
        {
            secondVertexIndex = *firstDescItr;
            Vertex secondVertex = vertices[secondVertexIndex];

            for (auto secondDescItr = secondVertex.descendants.begin();
                 secondDescItr != secondVertex.descendants.end();
                 ++secondDescItr)
            {
                thirdVertexIndex = *secondDescItr;

                if (firstVertexIndex < secondVertexIndex &&
                    firstVertexIndex < thirdVertexIndex &&
                    firstVertexIndex != secondVertexIndex &&
                    secondVertexIndex != thirdVertexIndex &&
                    firstVertexIndex != thirdVertexIndex &&
                    VertexContainsDescendant(thirdVertexIndex, firstVertexIndex))
                {
                    resultFound = true;
                    printf("{%d -> %d -> %d}\n",
                           firstVertexIndex,
                           secondVertexIndex,
                           thirdVertexIndex);
                }
            }
        }
    }

    if (!resultFound)
    {
        cout << "No cycles found" << endl;
    }
}

bool VertexContainsDescendant(int vertexIndex, int descIndex)
{
    return
        vertices[vertexIndex].descendants.find(descIndex) !=
        vertices[vertexIndex].descendants.end();
}

#endif // _ALGO_IMPLEMENTATION

#ifndef _IO_PROCESSING

void ProcessInput()
{
    cin >> verticesCount;

    InitializeResources();

    for (int vI = 0; vI < verticesCount; ++vI)
    {
        int vertexIndex;
        int number;
        string line;
        string garbage;

        cin >> vertexIndex;
        cin >> garbage; // Ignore unnecessary string

        //vertices[vertexIndex].descendants.clear();

        getline(cin, line);
        istringstream iss(line);

        while (iss >> number)
        {
            vertices[vertexIndex].descendants.insert(number);
        }
    }
}

#endif // _IO_PROCESSING

#ifndef _RESOURCES_MANAGEMENT

void InitializeResources()
{
    vertices = new Vertex[verticesCount];
}

void DisposeResources()
{
    delete[] vertices;
}

#endif // _RESOURCES_DISPOSAL
