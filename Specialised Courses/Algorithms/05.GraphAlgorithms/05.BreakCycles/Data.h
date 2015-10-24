
#include <unordered_map>

#define MAX_DATA 50

using namespace std;

typedef struct
{
    int firstVertexIndex;
    int secondVertexIndex;
} Edge;

typedef struct
{
    int edges[MAX_DATA];
    int edgesCount;
} Vertex;

extern Vertex vertices[MAX_DATA];
extern Edge edges[MAX_DATA];

extern int verticesCount;
extern int edgesCount;

extern unordered_map<int, string> mappings;

void InitializeFirstSampleData();
void InitializeSecondSampleData();
