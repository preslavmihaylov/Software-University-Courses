#include <iostream>
#include <math.h>
#include <iostream>

#define MAX_DATA 100

using namespace std;

/* FUNCTION PROTOTYPES */
int FindLongestCommonSubsequence(int firstIndex, int secondIndex);
void CalculateSequencesLength();
void ConstructSequence(int longestSequenceLength);
void ProcessInput();
void PrintResult();

static int occurencesMatrix[MAX_DATA][MAX_DATA];
static int firstSequenceLength = 0;
static int secondSequenceLength = 0;

static char firstSequence[MAX_DATA];
static char secondSequence[MAX_DATA];
static char longestSubsequence[MAX_DATA];

int main()
{
    ProcessInput();

    int longestSubsequenceLength =
        FindLongestCommonSubsequence(firstSequenceLength - 1,
                                      secondSequenceLength - 1);

    ConstructSequence(longestSubsequenceLength);
    PrintResult();
    return 0;
}

int FindLongestCommonSubsequence(int firstIndex, int secondIndex)
{
    if (firstIndex < 0 ||
        secondIndex < 0)
    {
        return 0;
    }

    if (occurencesMatrix[firstIndex][secondIndex] != 0)
    {
        return occurencesMatrix[firstIndex][secondIndex];
    }

    int result;
    int bothExcludedSequenceLength = 0;
    int firstExcludedSequenceLength;
    int secondExcludedSequenceLength;

    if (firstSequence[firstIndex] == secondSequence[secondIndex])
    {
        if (occurencesMatrix[firstIndex - 1][secondIndex - 1] != 0)
        {
            bothExcludedSequenceLength =
                occurencesMatrix[firstIndex - 1][secondIndex - 1];
        }
        else
        {
            bothExcludedSequenceLength =
                FindLongestCommonSubsequence(firstIndex - 1, secondIndex - 1);
        }

        ++bothExcludedSequenceLength;
    }

    if (occurencesMatrix[firstIndex - 1][secondIndex] != 0)
    {
        firstExcludedSequenceLength =
            occurencesMatrix[firstIndex - 1][secondIndex];
    }
    else
    {
        firstExcludedSequenceLength =
            FindLongestCommonSubsequence(firstIndex - 1, secondIndex);
    }

    if (occurencesMatrix[firstIndex][secondIndex - 1] != 0)
    {
        secondExcludedSequenceLength =
            occurencesMatrix[firstIndex][secondIndex - 1];
    }
    else
    {
        secondExcludedSequenceLength =
            FindLongestCommonSubsequence(firstIndex, secondIndex - 1);
    }

    result = max(firstExcludedSequenceLength, secondExcludedSequenceLength);
    result = max(result, bothExcludedSequenceLength);

    occurencesMatrix[firstIndex][secondIndex] = result;

    return result;
}

void ConstructSequence(int longestSequenceLength)
{
    int row = firstSequenceLength - 1;
    int col = secondSequenceLength - 1;

    int sequenceIndex = longestSequenceLength - 1;
    longestSubsequence[longestSequenceLength] = '\0';

    while (row >= 0 && col >= 0)
    {
        if (occurencesMatrix[row][col] == FindLongestCommonSubsequence(row - 1, col - 1))
        {
            --row;
            --col;
        }
        else if (occurencesMatrix[row][col] == FindLongestCommonSubsequence(row - 1, col))
        {
            --row;
        }
        else if (occurencesMatrix[row][col] == FindLongestCommonSubsequence(row, col - 1))
        {
            --col;
        }
        else
        {
            longestSubsequence[sequenceIndex] = firstSequence[row];
            sequenceIndex--;
            --row;
            --col;
        }
    }
}

void ProcessInput()
{
    cin.getline(firstSequence, MAX_DATA);
    cin.getline(secondSequence, MAX_DATA);

    CalculateSequencesLength();
}

void CalculateSequencesLength()
{
    bool hasCalculatedFirstSequenceLength = false;
    bool hasCalculatedSecondSequenceLength = false;

    for (int index = 0;
         ( firstSequence[index] != '\0' ||
           secondSequence[index] != '\0' );
         ++index)
    {
        if (!hasCalculatedFirstSequenceLength)
        {
            if (firstSequence[index] != '\0')
            {
                ++firstSequenceLength;
            }
            else
            {
                hasCalculatedFirstSequenceLength = true;
            }
        }

        if (!hasCalculatedSecondSequenceLength)
        {
            if (secondSequence[index] != '\0')
            {
                ++secondSequenceLength;
            }
            else
            {
                hasCalculatedSecondSequenceLength = true;
            }
        }
    }
}

void PrintResult()
{
    cout << longestSubsequence << endl;
}
