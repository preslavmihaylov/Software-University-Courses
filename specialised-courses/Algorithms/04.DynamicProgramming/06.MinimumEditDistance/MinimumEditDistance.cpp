#ifndef _LIBS_NAMESPACES

#include <iostream>
#include <string.h>
#include <math.h>
#include <limits.h>

using namespace std;


#endif // _LIBS_NAMESPACES

#ifndef _LOCAL_CONSTANTS

#define MAX_DATA 100

#endif // _LOCAL_CONSTANTS

#ifndef _STRUCTS_ENUMS

typedef enum
{
    eReplace,
    eInsert,
    eDelete
} Operation;

#endif // _STRUCTS_ENUMS

#ifndef _FUNCTION_PROTOTYPES
void InitializeData();
int CalculateMinimumEditDistance(int row, int col);
void ExtractMinimumEditOperations();
void PrintOperation(Operation operation, int row, int col);
int ExtractCost(Operation operation, int row, int col);
void PrintMinimumEditDistanceCost();
void PrintMatrix();
void ProcessInput();

#endif // _FUNCTION_PROTOTYPES

#ifndef _LOCAL_DATA

static int editMatrix[MAX_DATA][MAX_DATA];
static char firstString[MAX_DATA];
static char secondString[MAX_DATA];

static int rows;
static int cols;

static int replaceCost;
static int insertCost;
static int deleteCost;

#endif // _LOCAL_DATA

#ifndef _MAIN

int main()
{
    ProcessInput();
    InitializeData();
    CalculateMinimumEditDistance(rows - 1, cols - 1);
    PrintMinimumEditDistanceCost();
    ExtractMinimumEditOperations();

    // Used for debugging
    // PrintMatrix();

    return 0;
}

#endif // _MAIN

#ifndef _MED_CALCULATION_AND_EXTRACTION

int CalculateMinimumEditDistance(int row, int col)
{
    if (row < 0 || col < 0)
    {
        return 0;
    }

    if (editMatrix[row][col])
    {
        return editMatrix[row][col];
    }

    char firstStringChar = firstString[col - 1];
    char secondStringChar = secondString[row - 1];
    int cellEditDistance;

    if (firstStringChar == secondStringChar)
    {
        cellEditDistance = CalculateMinimumEditDistance(row - 1, col - 1);
    }
    else
    {
        int replaceEditCost = CalculateMinimumEditDistance(row - 1, col - 1) + replaceCost;
        int insertEditCost = CalculateMinimumEditDistance(row - 1, col) + insertCost;
        int deleteEditCost = CalculateMinimumEditDistance(row, col - 1) + deleteCost;

        cellEditDistance = min(replaceEditCost, min(insertEditCost, deleteEditCost));
    }

    editMatrix[row][col] = cellEditDistance;

    return cellEditDistance;
}

void ExtractMinimumEditOperations()
{
    int row = rows - 1;
    int col = cols - 1;

    while (row > 0 || col > 0)
    {
        if (firstString[col - 1] == secondString[row - 1])
        {
            row = row - 1;
            col = col - 1;
        }
        else
        {
            int replaceEditCost = ExtractCost(eReplace, row - 1, col - 1);
            int insertEditCost = ExtractCost(eInsert, row - 1, col);
            int deleteEditCost = ExtractCost(eDelete, row, col - 1);

            int lowestCostOperation = min(replaceEditCost, min(insertEditCost, deleteEditCost));

            if (lowestCostOperation == replaceEditCost)
            {
                PrintOperation(eReplace, row, col);
                row = row - 1;
                col = col - 1;
            }
            else if (lowestCostOperation == deleteEditCost)
            {
                PrintOperation(eDelete, row, col);
                col = col - 1;
            }
            else
            {
                PrintOperation(eInsert, row, col);
                row = row - 1;
            }
        }
    }
}

int ExtractCost(Operation operation, int row, int col)
{
    int value;

    if (row < 0 || col < 0)
    {
        return INT_MAX;
    }

    value = editMatrix[row][col];

    switch (operation)
    {
        case eReplace:
            value += replaceCost;
            break;
        case eInsert:
            value += insertCost;
            break;
        case eDelete:
            value += deleteCost;
            break;
    }

    return value;
}

#endif // _MED_CALCULATION_AND_EXTRACTION

#ifndef _DATA_INITIALISATION

void InitializeData()
{
    for (int row = 1; secondString[row - 1] != '\0'; row++)
    {
        editMatrix[row][0] = editMatrix[row - 1][0] + insertCost;
    }

    for (int col = 1; firstString[col - 1] != '\0'; col++)
    {
        editMatrix[0][col] = editMatrix[0][col - 1] + deleteCost;
    }
}

#endif // _DATA_INITIALISATION

#ifndef _IO_PROCESSING

void ProcessInput()
{
    cout << "Replace cost: ";
    cin >> replaceCost;

    cout << "Insert cost: ";
    cin >> insertCost;

    cout << "Delete cost: ";
    cin >> deleteCost;

    cout << "First string: ";
    cin >> firstString;

    cout << "Second string: ";
    cin >> secondString;

    rows = strlen(secondString) + 1;
    cols = strlen(firstString) + 1;
}

void PrintOperation(Operation operation, int row, int col)
{
    switch (operation)
    {
        case eReplace:
            cout << "REPLACE("
                 << col - 1
                 << ", "
                 << secondString[row - 1]
                 << ")"
                 << endl;
            break;
        case eInsert:
            cout << "INSERT("
                 << row - 1
                 << ", "
                 << secondString[row - 1]
                 << ")"
                 << endl;
            break;
        case eDelete:
            cout << "DELETE("
                 << col - 1
                 << ")"
                 << endl;
            break;
    }
}

void PrintMinimumEditDistanceCost()
{
    cout << "Minimum edit distance: " << editMatrix[rows - 1][cols - 1] << endl;
}

void PrintMatrix()
{
    cout << "    ";
    for (int index = 0; firstString[index] != '\0'; index++)
    {
        cout << firstString[index] << " ";
    }
    cout << endl;

    for (int row = 0; row < rows; row++)
    {
        cout << (row == 0 ? ' ' : secondString[row - 1]) << " ";

        for (int col = 0; col < cols; col++)
        {
            cout << editMatrix[row][col] << " ";
        }

        cout << endl;
    }
}

#endif // _IO_PROCESSING
