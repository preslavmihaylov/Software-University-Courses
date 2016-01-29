#include <iostream>
#include <string.h>
#include <unordered_set>
#include <sstream>

/* CONSTANTS & MACROS */
#define ROTATIONS_COUNT 4
#define EDGES_COUNT 4
#define SIDES_COUNT 3
#define TOTAL_NUMBERS_COUNT (SIDES_COUNT * EDGES_COUNT)
#define MAX_COLOURS 4

#define mSwap(first, second) do { \
    int temp = *first;             \
    *first = *second;               \
    *second = temp;                \
} while (0)

using namespace std;

typedef struct
{
    int firstSide;
    int secondSide;
    int thirdSide;
} Edge;

void GenerateUniqueCubeStates(int start, int end);
void StorePossibleCubeRotations();
void BuildCube();
void StoreCube();
void GetValuesHash(string * buffer);
bool IsDuplicateState(string currentState);
void RotateX();
void RotateY();
void RotateZ();
void sortValues();
void processInput();

/* LOCAL DATA */
static unordered_set<string> similarStates;
static int values[TOTAL_NUMBERS_COUNT];
static Edge cube[4]
{
    { 1, 1, 1 },
    { 1, 1, 1 },
    { 1, 1, 1 },
    { 1, 1, 1 }
};

static int uniqueStatesCount = 0;

int main()
{
    processInput();
    sortValues();
    GenerateUniqueCubeStates(0, TOTAL_NUMBERS_COUNT - 1);

    for (auto itr = similarStates.begin(); itr != similarStates.end(); itr++)
    {
        delete &itr;
    }

    cout << uniqueStatesCount << endl;

    return 0;
}

void GenerateUniqueCubeStates(int start, int end)
{
    string currentState;
    GetValuesHash(&currentState);

    if (!IsDuplicateState(currentState))
    {
        StorePossibleCubeRotations();
        uniqueStatesCount++;
    }

    for (int left = end - 1; left >= start; left--)
    {
        for (int right = left + 1; right <= end; right++)
        {
            if (values[left] != values[right])
            {
                mSwap(&values[left], &values[right]);
                GenerateUniqueCubeStates(left + 1, end);
            }
        }

        int firstElement = values[left];
        for (int i = left; i <= end - 1; i++)
        {
            values[i] = values[i + 1];
        }

        values[end] = firstElement;
    }
}

void StorePossibleCubeRotations()
{
    int index;

    // First three cube walls
    BuildCube();
    StoreCube();

    for (index = 0; index < ROTATIONS_COUNT - 1; index++)
    {
        RotateZ();
        StoreCube();
    }

    RotateX();
    StoreCube();

    for (index = 0; index < ROTATIONS_COUNT - 1; index++)
    {
        RotateY();
        StoreCube();
    }

    RotateZ();
    StoreCube();

    for (index = 0; index < ROTATIONS_COUNT - 1; index++)
    {
        RotateX();
        StoreCube();
    }

    // Second three cube walls
    RotateZ();
    StoreCube();

    for (index = 0; index < ROTATIONS_COUNT - 1; index++)
    {
        RotateY();
        StoreCube();
    }

    RotateX();
    RotateX();
    StoreCube();

    for (index = 0; index < ROTATIONS_COUNT - 1; index++)
    {
        RotateY();
        StoreCube();
    }

    RotateX();
    StoreCube();

    for (index = 0; index < ROTATIONS_COUNT - 1; index++)
    {
        RotateZ();
        StoreCube();
    }

    RotateX();
    RotateZ();
    StoreCube();

    for (index = 0; index < ROTATIONS_COUNT - 1; index++)
    {
        RotateX();
        StoreCube();
    }
}

void BuildCube()
{
    // First edge
    cube[0].firstSide = values[0];
    cube[0].secondSide = values[1];
    cube[0].thirdSide = values[2];

    // Second edge
    cube[1].firstSide = values[3];
    cube[1].secondSide = values[4];
    cube[1].thirdSide = values[5];

    // Third edge
    cube[2].firstSide = values[6];
    cube[2].secondSide = values[7];
    cube[2].thirdSide = values[8];

    // Fourth edge
    cube[3].firstSide = values[9];
    cube[3].secondSide = values[10];
    cube[3].thirdSide = values[11];
}

void StoreCube()
{
    stringstream ss;

    ss << cube[0].firstSide;
    ss << cube[0].secondSide;
    ss << cube[0].thirdSide;

    ss << cube[1].firstSide;
    ss << cube[1].secondSide;
    ss << cube[1].thirdSide;

    ss << cube[2].firstSide;
    ss << cube[2].secondSide;
    ss << cube[2].thirdSide;

    ss << cube[3].firstSide;
    ss << cube[3].secondSide;
    ss << cube[3].thirdSide;

    string* cubeHashToStore = new string;
    *cubeHashToStore = ss.str();
    string deb = *cubeHashToStore;

    similarStates.insert(*cubeHashToStore);
}

void GetValuesHash(string * buffer)
{
    int index;
    stringstream ss;

    for (index = 0; index < TOTAL_NUMBERS_COUNT; index++)
    {
        ss << values[index];
    }

    *buffer = ss.str();
}

bool IsDuplicateState(string currentState)
{
    unordered_set<string>::const_iterator elementIndex =
            similarStates.find(currentState);

    return elementIndex != similarStates.end();
}

#ifndef __ROTATIONS

void RotateX() // 3
{
    int tempEdgeValue = cube[2].thirdSide;

    // Upper Sides
    mSwap(&tempEdgeValue, &cube[3].thirdSide);
    mSwap(&tempEdgeValue, &cube[1].thirdSide);
    mSwap(&tempEdgeValue, &cube[0].thirdSide);
    mSwap(&tempEdgeValue, &cube[2].thirdSide);

    // Left Sides
    tempEdgeValue = cube[0].firstSide;

    mSwap(&tempEdgeValue, &cube[3].secondSide);
    mSwap(&tempEdgeValue, &cube[3].firstSide);
    mSwap(&tempEdgeValue, &cube[0].secondSide);
    mSwap(&tempEdgeValue, &cube[0].firstSide);

    // Right Sides
    tempEdgeValue = cube[2].firstSide;

    mSwap(&tempEdgeValue, &cube[2].secondSide);
    mSwap(&tempEdgeValue, &cube[1].firstSide);
    mSwap(&tempEdgeValue, &cube[1].secondSide);
    mSwap(&tempEdgeValue, &cube[2].firstSide);
}

void RotateY() // 2
{
    int tempEdgeValue = cube[3].secondSide;

    // Upper Sides
    mSwap(&tempEdgeValue, &cube[2].secondSide);
    mSwap(&tempEdgeValue, &cube[1].secondSide);
    mSwap(&tempEdgeValue, &cube[0].secondSide);
    mSwap(&tempEdgeValue, &cube[3].secondSide);

    // Left Sides
    tempEdgeValue = cube[3].firstSide;

    mSwap(&tempEdgeValue, &cube[3].thirdSide);
    mSwap(&tempEdgeValue, &cube[1].firstSide);
    mSwap(&tempEdgeValue, &cube[1].thirdSide);
    mSwap(&tempEdgeValue, &cube[3].firstSide);

    // Right Sides
    tempEdgeValue = cube[0].firstSide;

    mSwap(&tempEdgeValue, &cube[2].thirdSide);
    mSwap(&tempEdgeValue, &cube[2].firstSide);
    mSwap(&tempEdgeValue, &cube[0].thirdSide);
    mSwap(&tempEdgeValue, &cube[0].firstSide);
}

void RotateZ() // 1
{
    int tempEdgeValue = cube[0].firstSide;

    // Upper Sides
    mSwap(&tempEdgeValue, &cube[2].firstSide);
    mSwap(&tempEdgeValue, &cube[1].firstSide);
    mSwap(&tempEdgeValue, &cube[3].firstSide);
    mSwap(&tempEdgeValue, &cube[0].firstSide);

    // Left Sides
    tempEdgeValue = cube[3].secondSide;

    mSwap(&tempEdgeValue, &cube[2].thirdSide);
    mSwap(&tempEdgeValue, &cube[2].secondSide);
    mSwap(&tempEdgeValue, &cube[3].thirdSide);
    mSwap(&tempEdgeValue, &cube[3].secondSide);

    // Right Sides
    tempEdgeValue = cube[0].secondSide;

    mSwap(&tempEdgeValue, &cube[0].thirdSide);
    mSwap(&tempEdgeValue, &cube[1].secondSide);
    mSwap(&tempEdgeValue, &cube[1].thirdSide);
    mSwap(&tempEdgeValue, &cube[0].secondSide);

}

#endif // __ROTATIONS

void sortValues()
{
    int outer;
    int inner;
    int smallestNum;
    int smallestNumIndex;

    for (outer = 0; outer < TOTAL_NUMBERS_COUNT; outer++)
    {
        smallestNum = MAX_COLOURS + 1;
        smallestNumIndex = -1;
        for (inner = outer; inner < TOTAL_NUMBERS_COUNT; inner++)
        {
            if (values[inner] < smallestNum)
            {
                smallestNum = values[inner];
                smallestNumIndex = inner;
            }
        }

        mSwap(&values[outer], &values[smallestNumIndex]);
    }
}

void processInput()
{
    int index;

    for (index = 0; index < TOTAL_NUMBERS_COUNT; index++)
    {
        cin >> values[index];
    }
}
