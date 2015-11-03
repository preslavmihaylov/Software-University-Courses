#ifndef _LIBS_NAMESPACES

#include <iostream>

using namespace std;

#endif // _LIBS_NAMESPACES

#ifndef _LOCAL_CONSTANTS

#define RESULT_NOT_FOUND -1

#endif // _LOCAL_CONSTANTS

typedef struct
{
    int * elements;
    int elementsCount;
} Set;

#ifndef _STRUCTS_ENUMS


#endif // _STRUCTS_ENUMS

#ifndef _FUNCTION_PROTOTYPES

void RemoveSetElementsFromUniverse(int * elements, int elementsCount);
void FindSubsetSets();
void PrintSet(int * elements, int elementsCount);
void ProcessInput();
void InitializeSet(int setIndex, int elementsCount);
void InitializeResources();
void DisposeResources();

#endif // _FUNCTION_PROTOTYPES

#ifndef _LOCAL_DATA

static int * universe;
static Set * sets;
static bool * coveredElements;

static int coveredElementsCount;
static int universeCount;
static int setsCount;

#endif // _LOCAL_DATA

#ifndef _MAIN

int main()
{
    ProcessInput();
    FindSubsetSets();
    DisposeResources();

    return 0;
}
#endif // _MAIN

#ifndef _ALGO_IMPLEMENTATION

void FindSubsetSets()
{
    while (coveredElementsCount < universeCount)
    {

        int currentMaxCoveredElements = 0;
        int setToTake = RESULT_NOT_FOUND;
        for (int index = 0; index < setsCount; ++index)
        {
            int currentCoveredElements = 0;

            for (int elementIndex = 0; elementIndex < sets[index].elementsCount; ++elementIndex)
            {
                int element = sets[index].elements[elementIndex];
                for (int universeIndex = 0; universeIndex < universeCount; ++universeIndex)
                {
                    if (!coveredElements[universeIndex] && universe[universeIndex] == element)
                    {
                        ++currentCoveredElements;
                    }
                }
            }

            if (currentCoveredElements > currentMaxCoveredElements)
            {
                currentMaxCoveredElements = currentCoveredElements;
                setToTake = index;
            }
        }

        if (setToTake != RESULT_NOT_FOUND)
        {
            RemoveSetElementsFromUniverse(sets[setToTake].elements, sets[setToTake].elementsCount);
            PrintSet(sets[setToTake].elements, sets[setToTake].elementsCount);

            coveredElementsCount += currentMaxCoveredElements;
        }
    }
}

void RemoveSetElementsFromUniverse(int * elements, int elementsCount)
{
    for (int index = 0; index < elementsCount; ++index)
    {
        for (int universeIndex = 0; universeIndex < universeCount; ++universeIndex)
        {
            if (universe[universeIndex] == elements[index])
            {
                coveredElements[universeIndex] = true;
            }
        }
    }
}

#endif // _ALGO_IMPLEMENTATION

#ifndef _IO_PROCESSING

void ProcessInput()
{
    cout << "Universe count: ";
    cin >> universeCount;
    cout << "Sets count:";
    cin >> setsCount;

    InitializeResources();

    cout << "Universe elements: ";
    for (int cnt = 0; cnt < universeCount; ++cnt)
    {
        cin >> universe[cnt];
    }

    for (int cnt = 0; cnt < setsCount; ++cnt)
    {
        cout << "Set " << cnt << " elements count: ";
        cin >> sets[cnt].elementsCount;

        InitializeSet(cnt, sets[cnt].elementsCount);

        cout << "Set " << cnt << " elements: ";
        for (int index = 0; index < sets[cnt].elementsCount; ++index)
        {
            cin >> sets[cnt].elements[index];
        }
    }
}

void PrintSet(int * elements, int elementsCount)
{
    cout << "{";
    for (int index = 0; index < elementsCount; ++index)
    {
        cout << elements[index];

        if (index != elementsCount - 1)
        {
            cout << ", ";
        }
    }

    cout << "}" << endl;
}

#endif // _IO_PROCESSING

#ifndef _RESOURCES_MANAGEMENT

void InitializeSet(int setIndex, int elementsCount)
{
    sets[setIndex].elements = new int[elementsCount];
}

void InitializeResources()
{
    universe = new int[universeCount];
    sets = new Set[setsCount];
    coveredElements = new bool[universeCount];
}

void DisposeResources()
{
    for (int index = 0; index < setsCount; ++index)
    {
        delete sets[index].elements;
    }

    delete sets;
    delete coveredElements;
    delete universe;
}

#endif // _RESOURCES_DISPOSAL
