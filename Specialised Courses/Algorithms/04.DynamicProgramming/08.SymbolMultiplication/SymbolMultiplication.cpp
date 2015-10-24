#ifndef _LIBS_NAMESPACES

#include <iostream>
#include <string.h>
#include <deque>

using namespace std;

#endif // _LIBS_NAMESPACES

#ifndef _LOCAL_CONSTANTS

#define MAX_DATA 50
#define TARGET_RESULT 'a'

#endif // _LOCAL_CONSTANTS

#ifndef _STRUCTS_ENUMS

#endif // _STRUCTS_ENUMS

#ifndef _FUNCTION_PROTOTYPES

void MultiplySymbols(deque<char> * buffer, int min, int max, char target);
void JoinDeques(deque<char> * buffer, deque<char> * first, deque<char> * second);
int FindPossibleMultiplications(int * possibleLeft, int * possibleRight, char target);
void ProcessInput();
void PrintTable();
void PrintResult(deque<char> * result);

#endif // _FUNCTION_PROTOTYPES

#ifndef _LOCAL_DATA

static char alphabet[MAX_DATA];
static char table[MAX_DATA][MAX_DATA];
static char sequence[MAX_DATA];

static int alphabetLength;
static char sequenceLength;

#endif // _LOCAL_DATA

#ifndef _MAIN

int main()
{
    ProcessInput();

    deque<char> * result = new deque<char>();
    MultiplySymbols(result, 0, sequenceLength - 1, TARGET_RESULT);

    PrintResult(result);

    delete result;

    return 0;
}

#endif // _MAIN

#ifndef _ALGO_IMPLEMENTATION

void MultiplySymbols(deque<char> * buffer, int min, int max, char target)
{
    int count = (max - min) + 1;
    if (count <= 1)
    {
        if (sequence[min] == target)
        {
            (*buffer).push_back(sequence[min]);
        }

        return;
    }

    int possibleLeft[MAX_DATA];
    int possibleRight[MAX_DATA];

    int possibilitiesLength =
        FindPossibleMultiplications(possibleLeft, possibleRight, target);

    deque<char> * leftRes = new deque<char>();
    deque<char> * rightRes = new deque<char>();

    for (int index = min; index < max; index++)
    {
        for (int possIndex = 0; possIndex < possibilitiesLength; possIndex++)
        {
            char left = alphabet[possibleLeft[possIndex]];
            char right = alphabet[possibleRight[possIndex]];

            MultiplySymbols(leftRes, min, index, left);
            MultiplySymbols(rightRes, index + 1, max, right);

            if ( (*leftRes).size() > 0 && (*rightRes).size() > 0)
            {
                JoinDeques(buffer, leftRes, rightRes);

                delete leftRes;
                delete rightRes;
                return;
            }

            (*leftRes).clear();
            (*rightRes).clear();
        }
    }

    delete leftRes;
    delete rightRes;
}

void JoinDeques(deque<char> * buffer, deque<char> * first, deque<char> * second)
{
    for (auto itr = (*first).begin(); itr != (*first).end(); itr++)
    {
        (*buffer).push_back(*itr);
    }

    (*buffer).push_back('*');

    for (auto itr = (*second).begin(); itr != (*second).end(); itr++)
    {
        (*buffer).push_back(*itr);
    }

    (*buffer).push_front('(');
    (*buffer).push_back(')');
}

int FindPossibleMultiplications(int * possibleLeft, int * possibleRight, char target)
{
    int index = 0;

    for (int row = 0; row < alphabetLength; row++)
    {
        for (int col = 0; col < alphabetLength; col++)
        {
            if (table[row][col] == target)
            {
                possibleLeft[index] = row;
                possibleRight[index] = col;
                index++;
            }
        }
    }

    return index;
}

#endif // _ALGO_IMPLEMENTATION

#ifndef _IO_PROCESSING

void ProcessInput()
{
    cin >> alphabet;

    for (int index = 0; alphabet[index] != '\0'; index++)
    {
        alphabetLength++;

        for (int ch = 0; alphabet[ch] != '\0'; ch++)
        {
            cin >> table[index][ch];
        }
    }

    cin >> sequence;
    sequenceLength = strlen(sequence);
}

void PrintTable()
{
    for (int row = 0; row < alphabetLength; row++)
    {
        for (int col = 0; col < alphabetLength; col++)
        {
            cout << table[row][col] << " ";
        }

        cout << endl;
    }
}

void PrintResult(deque<char> * result)
{
    if ( (*result).size() == 0)
    {
        cout << "No solution";
    }

    while ( (*result).size() > 0)
    {
        char letter = (*result).front();
        (*result).pop_front();

        cout << letter;
    }

    cout << endl;
}

#endif // _IO_PROCESSING

