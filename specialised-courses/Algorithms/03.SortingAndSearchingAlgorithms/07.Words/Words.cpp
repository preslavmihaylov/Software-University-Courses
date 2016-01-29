#include <iostream>
#include <unordered_set>
#include <string.h>
#include <algorithm>

#define MAX_DATA 10
#define MAX_LETTERS 30

using namespace std;

/* FUNCTION PROTOTYPES */
void GenerateValidWordWithoutRepetition(int start, int end);
void SortWord();
void CalculateTotalPermutations();
bool IsValidWord();
bool HasDuplicateLetters();
void Swap(char *first, char *second);
void ProcessInput();
void Print();

static char word[MAX_DATA];
static int wordsCount = 0;
static int lettersCount = 0;

int main()
{
    ProcessInput();

    if (HasDuplicateLetters())
    {
        SortWord();
        GenerateValidWordWithoutRepetition(0, lettersCount - 1);
    }
    else
    {
        CalculateTotalPermutations();
    }

    cout << wordsCount << endl;

    return 0;
}

void GenerateValidWordWithoutRepetition(int start, int end)
{
    int left;
    int right;
    int firstElement;
    int i;

    if (IsValidWord())
    {
        wordsCount++;
    }

    for (left = end - 1; left >= start; left--)
    {
        for (right = left + 1; right <= end; right++)
        {
            if (word[left] != word[right])
            {
                Swap(&word[left], &word[right]);
                GenerateValidWordWithoutRepetition(left + 1, end);
            }
        }

        firstElement = word[left];

        for (i = left; i <= end - 1; i++)
        {
            word[i] = word[i + 1];
        }

        word[end] = firstElement;
    }
}

void SortWord()
{
    sort(word, word + lettersCount);
}

void CalculateTotalPermutations()
{
    wordsCount = 1;
    for (int index = 0; word[index] != '\0'; index++)
    {
        wordsCount *= (index + 1);
    }
}

bool IsValidWord()
{
    for (int index = 0;
         word[index] != '\0' && word[index + 1] != '\0';
         index++)
    {
        if (word[index] == word[index + 1])
        {
            return false;
        }
    }

    return true;
}

bool HasDuplicateLetters()
{
    int boolMask = 0;

    for (int i = 0; word[i] != '\0'; i++)
    {
        int position = word[i] - 'a';
        int cnt = ( boolMask >> position ) & 1;

        if (cnt != 0)
        {
            return true;
        }
        else
        {
            boolMask ^= (1 << position);
        }
    }

    return false;
}

void Swap(char *first, char *second)
{
    char temp = *first;
    *first = *second;
    *second = temp;
}

void ProcessInput()
{
    cin >> word;

    for (int i = 0; word[i] != '\0'; i++)
    {
        ++lettersCount;
    }
}

void Print()
{
    cout << word << endl;
}
