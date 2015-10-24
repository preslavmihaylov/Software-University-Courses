#include <iostream>
#include <algorithm>
#include <sstream>
#include <string>
#include <math.h>

#define MAX_DATA 100
#define DELIMITER ','
#define FIRST_PERSON_NAME "Alan"
#define SECOND_PERSON_NAME "Bob"

using namespace std;

typedef struct
{
    int presents[MAX_DATA];
    int presentsCount;
    int presentsTotalValue;
} Person;

/* FUNCTION PROTOTYPES */
void DividePresents();
void AddPresent(Person *person, int present);
void SortPresentsDescending();
void ProcessInput();
void PrintResult();
void PrintPersonStatistics(Person person, char* name);

/* LOCAL DATA */
static int presents[MAX_DATA];

static Person firstPerson;
static Person secondPerson;

static int presentsCount = 0;

int main()
{
    ProcessInput();
    SortPresentsDescending();
    DividePresents();
    PrintResult();

    return 0;
}

void DividePresents()
{
    for (int index = 0; index < presentsCount; index++)
    {
        if (firstPerson.presentsTotalValue < secondPerson.presentsTotalValue)
        {
            AddPresent(&firstPerson, presents[index]);
        }
        else
        {
            AddPresent(&secondPerson, presents[index]);
        }
    }
}

void AddPresent(Person *person, int present)
{
    (*person).presents[(*person).presentsCount] =
        present;

    (*person).presentsTotalValue +=
        (*person).presents[(*person).presentsCount];

    (*person).presentsCount++;
}

void SortPresentsDescending()
{
    sort(presents, presents + presentsCount, greater<int>());
}

void ProcessInput()
{
    string input;
    string currentToken;

    cin >> input;

    stringstream ss(input);

    while ( getline(ss, currentToken, DELIMITER) )
    {
        presents[presentsCount] = atoi(currentToken.c_str());
        presentsCount++;
    }
}

void PrintResult()
{
    PrintPersonStatistics(firstPerson, FIRST_PERSON_NAME);
    PrintPersonStatistics(secondPerson, SECOND_PERSON_NAME);

    int difference =
        abs(firstPerson.presentsTotalValue - secondPerson.presentsTotalValue);

    cout << endl;
    cout << "Difference: " << difference << endl;
}

void PrintPersonStatistics(Person person, char* name)
{
    cout << endl;
    cout << name << "'s Statistics" << endl;
    cout << "Presents Total Value: " << person.presentsTotalValue << endl;
    cout << "Presents Count: " << person.presentsCount << endl;
    cout << "Presents:" << endl;

    for (int index = 0; index < person.presentsCount; index++)
    {
        cout << person.presents[index] << " ";
    }

    cout << endl;
}
