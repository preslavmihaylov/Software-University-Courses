#include <iostream>
#include <sstream>
#include <string>
#include <stdlib.h>

#define MAX_DATA 100
#define DELIMITER ','

using namespace std;

/* FUNCTION PROTOTYPES */
void FindSumElements(int currentIndex, int maxAddendIndex, int sum);
void PrintSequence(int length);
void ProcessInput();
void PrintResult();

static int numbers[MAX_DATA];
static int currentSequence[MAX_DATA];

static int totalSum;
static int numbersCount = 0;
static int sequencesCount = 0;

int main()
{
    ProcessInput();
    FindSumElements(0, numbersCount - 1, totalSum);
    PrintResult();

    return 0;
}

void FindSumElements(int currentIndex, int maxAddendIndex, int sum)
{
    if (sum == 0)
    {
        sequencesCount++;
        PrintSequence(currentIndex);
        return;
    }
    else if (sum < 0)
    {
        return;
    }

    for (int index = maxAddendIndex; index >= 0; index--)
    {
        currentSequence[currentIndex] = numbers[index];

        FindSumElements(currentIndex + 1, index, sum - numbers[index]);
    }
}

void ProcessInput()
{
    cout << "Enter total sum: ";
    cin >> totalSum;

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

void PrintSequence(int length)
{
    for (int index = 0; index < length; index++)
    {
        cout << currentSequence[index] << " ";
    }

    cout << endl;
}

void PrintResult()
{
    cout << sequencesCount << endl;
}
