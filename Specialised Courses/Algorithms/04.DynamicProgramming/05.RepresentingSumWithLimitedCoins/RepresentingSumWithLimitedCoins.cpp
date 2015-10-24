#include <iostream>
#include <algorithm>
#include <sstream>
#include <unordered_set>

#define MAX_DATA 100
#define DELIMITER ','

using namespace std;

/* FUNCTION PROTOTYPES */
void FindSumElements();
void FindSumElementsPrivate(int currentIndex,
                            int maxAddendIndex,
                            int sum);
void StoreSequence(string sequenceHash);
bool IsUniqueSequence(string sequenceHash);
string* GetSequenceHash(int length);
void ArrangeElements();
void ProcessInput();
void PrintSequence(int length);
void PrintResult();

/* LOCAL DATA */
static int numbers[MAX_DATA];
static int currentSequence[MAX_DATA];

static int totalSum;
static int numbersCount = 0;
static int sequencesCount = 0;

unordered_set<string> uniqueElements;

int main()
{
    //TODO: STORE UNIQUE SEQUENCES
    ProcessInput();
    ArrangeElements();
    FindSumElements();
    PrintResult();

    return 0;
}

void FindSumElements()
{
    FindSumElementsPrivate(0, numbersCount - 1, totalSum);
}

void FindSumElementsPrivate(int currentIndex, int maxAddendIndex, int sum)
{
    if (sum == 0)
    {
        string *sequenceHash = GetSequenceHash(currentIndex);

        if (IsUniqueSequence( (*sequenceHash) ) )
        {
            StoreSequence( (*sequenceHash) );
            sequencesCount++;
            // PrintSequence(currentIndex);
        }

        return;
    }
    else if (sum < 0)
    {
        return;
    }

    for (int index = maxAddendIndex; index >= 0; index--)
    {
        currentSequence[currentIndex] = numbers[index];

        FindSumElementsPrivate(currentIndex + 1,
                               index - 1,
                               sum - numbers[index]);
    }
}

void StoreSequence(string sequenceHash)
{
    uniqueElements.insert(sequenceHash);
}

bool IsUniqueSequence(string sequenceHash)
{
    unordered_set<string>::const_iterator elementIndex =
            uniqueElements.find(sequenceHash);

    return elementIndex == uniqueElements.end();
}

string* GetSequenceHash(int length)
{
    stringstream ss;
    string* result = new string;

    for (int index = 0; index < length; index++)
    {
        ss << currentSequence[index];
    }

    (*result) = ss.str();

    return result;
}

void ArrangeElements()
{
    sort(numbers, numbers + numbersCount);
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
