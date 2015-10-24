#include <iostream>
#include <sstream>
#include <string>
#include <stdlib.h>

#define MAX_DATA 100
#define DELIMITER ','

using namespace std;

// The sequence can be either:
// Every odd element to be smaller than its neighbours and
// every even element to be greater than its neighbours
// or the other way around
typedef enum
{
    eFirstCaseSequence,
    eSecondCaseSequence,
    eUndefined
} SubsequenceType;

/* FUNCTION PROTOTYPES */
void FindLongestZigzagSubsequence();
void ExtractLongestZigzagSubsequence();
bool IsValidZigzagSubsequenceMember(int subsequenceIndex,
                                    int candidate,
                                    int previousMember,
                                    SubsequenceType *type);
void ProcessInput();
void PrintResult();

static int numbers[MAX_DATA];
static int longestZigzagSubsequence[MAX_DATA];
static int subsequenceLengths[MAX_DATA];
static int previousIndexes[MAX_DATA];
static SubsequenceType subsequenceTypes[MAX_DATA] = { eUndefined };

static int numbersCount = 0;
static int longestSubsequenceLength = 0;
static int longestSubsequenceIndex = 0;

int main()
{
    ProcessInput();
    FindLongestZigzagSubsequence();
    ExtractLongestZigzagSubsequence();
    PrintResult();

    return 0;
}

void FindLongestZigzagSubsequence()
{
    for (int index = 0; index < numbersCount; ++index)
    {
        int previousLongestSequenceLength = 0;

        for (int innerIndex = index - 1; innerIndex >= 0; --innerIndex)
        {
            if (subsequenceLengths[innerIndex] >= previousLongestSequenceLength &&
                IsValidZigzagSubsequenceMember(subsequenceLengths[innerIndex],
                                               numbers[index],
                                               numbers[innerIndex],
                                               &subsequenceTypes[innerIndex]) )
            {
                subsequenceTypes[index] = subsequenceTypes[innerIndex];
                previousLongestSequenceLength = subsequenceLengths[innerIndex];
                previousIndexes[index] = innerIndex;
            }
        }

        subsequenceLengths[index] = previousLongestSequenceLength + 1;

        if (subsequenceLengths[index] > longestSubsequenceLength)
        {
            longestSubsequenceLength = subsequenceLengths[index];
            longestSubsequenceIndex = index;
        }
    }
}

void ExtractLongestZigzagSubsequence()
{
    int currentIndex = longestSubsequenceIndex;
    int longestZigzagSubsequenceOffset = 1;

    while (longestZigzagSubsequenceOffset <= longestSubsequenceLength)
    {
        int index = longestSubsequenceLength - longestZigzagSubsequenceOffset;
        longestZigzagSubsequence[index] = numbers[currentIndex];
        currentIndex = previousIndexes[currentIndex];
        longestZigzagSubsequenceOffset++;
    }


}

bool IsValidZigzagSubsequenceMember(int subsequenceIndex,
                                    int candidate,
                                    int previousMember,
                                    SubsequenceType *type)
{
    if ( (*type) == eUndefined)
    {
        if ((subsequenceIndex + 1) % 2 == 0)
        {
            if (candidate < previousMember)
            {
                (*type) = eFirstCaseSequence;
            }
            else
            {
                (*type) = eSecondCaseSequence;
            }
        }
        else
        {
            if (candidate > previousMember)
            {
                (*type) = eFirstCaseSequence;
            }
            else
            {
                (*type) = eSecondCaseSequence;
            }
        }

        return true;
    }
    else if ( (*type) == eFirstCaseSequence)
    {
        if ((subsequenceIndex + 1) % 2 == 0)
        {
            if (candidate < previousMember)
            {
                return true;
            }
        }
        else
        {
            if (candidate > previousMember)
            {
                return true;
            }
        }
    }
    else
    {
        if ((subsequenceIndex + 1) % 2 == 0)
        {
            if (candidate > previousMember)
            {
                return true;
            }
        }
        else
        {
            if (candidate < previousMember)
            {
                return true;
            }
        }
    }

    return false;
}

void ProcessInput()
{
    string input;
    string currentToken;

    cin >> input;

    stringstream ss(input);

    while ( getline(ss, currentToken, DELIMITER) )
    {
        numbers[numbersCount] = atoi(currentToken.c_str());
        numbersCount++;
    }
}

void PrintResult()
{
    for (int index = 0; index < longestSubsequenceLength; ++index)
    {
        cout << longestZigzagSubsequence[index] << endl;
    }
}
