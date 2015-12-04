#ifndef _LIBS_NAMESPACES

#include <iostream>

using namespace std;

#endif // _LIBS_NAMESPACES

#ifndef _LOCAL_CONSTANTS

#define MAX_INPUT_LENGTH 21
#define MAX_LETTERS_COUNT 30

#endif // _LOCAL_CONSTANTS

#ifndef _STRUCTS_ENUMS

#endif // _STRUCTS_ENUMS

#ifndef _FUNCTION_PROTOTYPES

void GeneratePermutations(int currentIndex);
void Swap(int *first, int *second);
void CountLetters();
void PrintCurrentPermutation();
void ProcessInput();
void InitializeResources();
void DisposeResources();

#endif // _FUNCTION_PROTOTYPES

#ifndef _LOCAL_DATA

static char input[MAX_INPUT_LENGTH];
static char output[MAX_INPUT_LENGTH];
static int lettersCount[MAX_LETTERS_COUNT];
static int permutations[MAX_LETTERS_COUNT];

static int permutationsCount;

#endif // _LOCAL_DATA

#ifndef _MAIN

int main()
{
    ProcessInput();
    CountLetters();
    GeneratePermutations(0);
    DisposeResources();

    return 0;
}
#endif // _MAIN

#ifndef _ALGO_IMPLEMENTATION

void GeneratePermutations(int currentIndex)
{
    if (currentIndex >= permutationsCount)
    {
        PrintCurrentPermutation();
        return;
    }

    for (int cnt = currentIndex; cnt < permutationsCount; ++cnt)
    {
        Swap(&permutations[cnt], &permutations[currentIndex]);
        GeneratePermutations(currentIndex + 1);
        Swap(&permutations[cnt], &permutations[currentIndex]);
    }
}

void CountLetters()
{
    for (int index = 0; input[index] != '\0'; ++index)
    {
        int letterIndex = input[index] - 'A';

        if (!lettersCount[letterIndex])
        {
            permutations[permutationsCount++] = letterIndex;
        }

        ++lettersCount[letterIndex];
    }
}

void Swap(int *first, int *second)
{
    int temp = *first;
    *first = *second;
    *second = temp;
}

#endif // _ALGO_IMPLEMENTATION

#ifndef _IO_PROCESSING

void ProcessInput()
{
    cin >> input;
}

void PrintCurrentPermutation()
{
    for (int index = 0; index < permutationsCount; ++index)
    {
        int letterIndex = permutations[index];
        for (int cnt = 0; cnt < lettersCount[letterIndex]; ++cnt)
        {
            cout << (char)(letterIndex + 'A');
        }
    }

    cout << endl;
}

#endif // _IO_PROCESSING

#ifndef _RESOURCES_MANAGEMENT

void InitializeResources()
{
}

void DisposeResources()
{
}

#endif // _RESOURCES_DISPOSAL
