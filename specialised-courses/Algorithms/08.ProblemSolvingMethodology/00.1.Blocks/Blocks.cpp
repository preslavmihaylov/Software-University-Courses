#ifndef _LIBS_NAMESPACES

#include <iostream>
#include <unordered_set>
#include <sstream>

using namespace std;

#endif // _LIBS_NAMESPACES

#ifndef _LOCAL_CONSTANTS

#define LETTERS_TO_GENERATE 4

#define SWAP(first, second) do { \
    int temp = *first;           \
    *first = *second;            \
    *second = temp;              \
    } while (0)

#endif // _LOCAL_CONSTANTS

#ifndef _STRUCTS_ENUMS

#endif // _STRUCTS_ENUMS

#ifndef _FUNCTION_PROTOTYPES

void GenerateVariations(int currentIndex);
void GenerateStringFromLetters(string * buffer);
void RotateLetters();
bool HasDuplicateRotations();
int CalculateBlocksCount(int input);
bool IsDuplicate(size_t strHash);
bool IsLetterTaken(int letterIndex);
void MarkLetterAsTaken(int letterIndex);
void MarkLetterAsFree(int letterIndex);
void PrintBlocksCount();
void PrintSequence();
void ProcessInput();
void InitializeResources();
void DisposeResources();

#endif // _FUNCTION_PROTOTYPES

#ifndef _LOCAL_DATA

int takenLettersMask;
int lettersCount;

unordered_set<size_t> duplicates;
hash<string> hash_func;

int generatedSequence[LETTERS_TO_GENERATE];

#endif // _LOCAL_DATA

#ifndef _MAIN

int main()
{
    ProcessInput();
    PrintBlocksCount();
    GenerateVariations(0);
    DisposeResources();

    return 0;
}
#endif // _MAIN

#ifndef _ALGO_IMPLEMENTATION

void GenerateVariations(int currentIndex)
{
    if (currentIndex >= LETTERS_TO_GENERATE)
    {
        if (!HasDuplicateRotations())
        {
            PrintSequence();
        }

        return;
    }

    // lI - letterIndex
    for (int letterIndex = 0; letterIndex < lettersCount; ++letterIndex)
    {
        if (!IsLetterTaken(letterIndex))
        {
            MarkLetterAsTaken(letterIndex);

            generatedSequence[currentIndex] = letterIndex;
            GenerateVariations(currentIndex + 1);

            MarkLetterAsFree(letterIndex);
        }
    }
}

bool HasDuplicateRotations()
{
    for (int i = 0; i < LETTERS_TO_GENERATE; ++i)
    {
        string currentLettersSequence;
        GenerateStringFromLetters(&currentLettersSequence);
        size_t strHash = hash_func(currentLettersSequence);

        if (!IsDuplicate(strHash))
        {
            duplicates.insert(strHash);
        }
        else
        {
            return true;
        }

        RotateLetters();
    }

    return false;
}

void RotateLetters()
{
    SWAP(&generatedSequence[1], &generatedSequence[2]);
    SWAP(&generatedSequence[0], &generatedSequence[1]);
    SWAP(&generatedSequence[2], &generatedSequence[3]);
}

int CalculateBlocksCount(int input)
{
    return (input - 3) * (input - 2) * (input - 1) * input / 4;
}

#endif // _ALGO_IMPLEMENTATION

#ifndef _IO_PROCESSING

void ProcessInput()
{
    cin >> lettersCount;
}

void PrintBlocksCount()
{
    cout << "Number of blocks: " << CalculateBlocksCount(lettersCount) << endl;
}

void PrintSequence()
{
    for (int i = 0; i < LETTERS_TO_GENERATE; ++i)
    {
        cout << (char)(generatedSequence[i] + 'A');
    }

    cout << endl;
}

#endif // _IO_PROCESSING

#ifndef _DATA_MANAGEMENT

void GenerateStringFromLetters(string * buffer)
{
    for (int i = 0; i < LETTERS_TO_GENERATE; ++i)
    {
        (*buffer) += (char)(generatedSequence[i] + 'A');
    }
}

bool IsDuplicate(size_t strHash)
{
    return duplicates.find(strHash) != duplicates.end();
}

bool IsLetterTaken(int letterIndex)
{
    return ( (takenLettersMask >> letterIndex) & 1) == 1;
}

void MarkLetterAsTaken(int letterIndex)
{
    takenLettersMask |= (1 << letterIndex);
}

void MarkLetterAsFree(int letterIndex)
{
    takenLettersMask &= ~(1 << letterIndex);
}

#endif // _DATA_MANAGEMENT

#ifndef _RESOURCES_MANAGEMENT

void InitializeResources()
{
}

void DisposeResources()
{
}

#endif // _RESOURCES_DISPOSAL
