#include "Data.h"

/* FUNCTION PROTOTYPES */
void ConfigureFirstSampleDataMappings();
void ConfigureSecondSampleDataMappings();

unordered_map<int, string> mappings;
Vertex vertices[MAX_DATA];
Edge edges[MAX_DATA];

int verticesCount;
int edgesCount;

void InitializeFirstSampleData()
{
    // First
    vertices[0].edgesCount = 3;
    vertices[0].edges[0] = 0;
    vertices[0].edges[1] = 1;
    vertices[0].edges[2] = 2;

    edges[0].firstVertexIndex = 0;
    edges[0].secondVertexIndex = 1;

    edges[1].firstVertexIndex = 0;
    edges[1].secondVertexIndex = 4;

    edges[2].firstVertexIndex = 0;
    edges[2].secondVertexIndex = 3;

    // Second
    vertices[1].edgesCount = 1;
    vertices[1].edges[0] = 3;

    edges[3].firstVertexIndex = 1;
    edges[3].secondVertexIndex = 2;

    // Third
    vertices[2].edgesCount = 1;
    vertices[2].edges[0] = 4;

    edges[4].firstVertexIndex = 2;
    edges[4].secondVertexIndex = 4;

    // Fourth and Fifth are empty
    vertices[4].edgesCount = 1;
    vertices[4].edges[0] = 8;

    edges[8].firstVertexIndex = 4;
    edges[8].secondVertexIndex = 0;

    // Sixth
    vertices[5].edgesCount = 2;
    vertices[5].edges[0] = 5;
    vertices[5].edges[1] = 6;

    edges[5].firstVertexIndex = 5;
    edges[5].secondVertexIndex = 6;

    edges[6].firstVertexIndex = 5;
    edges[6].secondVertexIndex = 7;

    // Seventh
    vertices[6].edgesCount = 1;
    vertices[6].edges[0] = 7;

    edges[7].firstVertexIndex = 6;
    edges[7].secondVertexIndex = 7;

    // Eight
    vertices[7].edgesCount = 1;
    vertices[7].edges[0] = 9;

    edges[9].firstVertexIndex = 7;
    edges[9].secondVertexIndex = 5;

    edgesCount = 10;
    verticesCount = 8;

    ConfigureFirstSampleDataMappings();
}

void InitializeSecondSampleData()
{
    // First
    vertices[0].edgesCount = 2;
    vertices[0].edges[0] = 0;
    vertices[0].edges[1] = 1;

    edges[0].firstVertexIndex = 0;
    edges[0].secondVertexIndex = 3;

    edges[1].firstVertexIndex = 0;
    edges[1].secondVertexIndex = 1;

    // Second
    vertices[1].edgesCount = 2;
    vertices[1].edges[0] = 2;
    vertices[1].edges[1] = 3;

    edges[2].firstVertexIndex = 1;
    edges[2].secondVertexIndex = 3;

    edges[3].firstVertexIndex = 1;
    edges[3].secondVertexIndex = 2;

    // Third
    vertices[2].edgesCount = 3;
    vertices[2].edges[0] = 4;
    vertices[2].edges[1] = 5;
    vertices[2].edges[2] = 6;

    edges[4].firstVertexIndex = 2;
    edges[4].secondVertexIndex = 3;

    edges[5].firstVertexIndex = 2;
    edges[5].secondVertexIndex = 6;

    edges[6].firstVertexIndex = 2;
    edges[6].secondVertexIndex = 4;

    // Fourth
    vertices[3].edgesCount = 2;
    vertices[3].edges[0] = 7;
    vertices[3].edges[1] = 8;

    edges[7].firstVertexIndex = 3;
    edges[7].secondVertexIndex = 0;

    edges[8].firstVertexIndex = 3;
    edges[8].secondVertexIndex = 5;

    // Fifth
    vertices[4].edgesCount = 1;
    vertices[4].edges[0] = 9;

    edges[9].firstVertexIndex = 4;
    edges[9].secondVertexIndex = 7;

    // Sixth
    vertices[5].edgesCount = 1;
    vertices[5].edges[0] = 10;

    edges[10].firstVertexIndex = 5;
    edges[10].secondVertexIndex = 3;

    // Seventh
    vertices[6].edgesCount = 2;
    vertices[6].edges[0] = 11;
    vertices[6].edges[1] = 12;

    edges[11].firstVertexIndex = 6;
    edges[11].secondVertexIndex = 2;

    edges[12].firstVertexIndex = 6;
    edges[12].secondVertexIndex = 5;

    // Eight
    vertices[7].edgesCount = 1;
    vertices[7].edges[0] = 13;

    edges[13].firstVertexIndex = 7;
    edges[13].secondVertexIndex = 6;

    verticesCount = 8;
    edgesCount = 14;

    ConfigureSecondSampleDataMappings();
}

void ConfigureFirstSampleDataMappings()
{
    mappings.insert({0, "1"});
    mappings.insert({1, "2"});
    mappings.insert({2, "3"});
    mappings.insert({3, "4"});
    mappings.insert({4, "5"});
    mappings.insert({5, "6"});
    mappings.insert({6, "7"});
    mappings.insert({7, "8"});
}

void ConfigureSecondSampleDataMappings()
{
    mappings.insert({0, "K"});
    mappings.insert({1, "J"});
    mappings.insert({2, "N"});
    mappings.insert({3, "X"});
    mappings.insert({4, "M"});
    mappings.insert({5, "Y"});
    mappings.insert({6, "L"});
    mappings.insert({7, "I"});
}
