#ifndef _LIBS_NAMESPACES

#include <iostream>
#include <limits.h>

using namespace std;

#endif // _LIBS_NAMESPACES

#ifndef _LOCAL_CONSTANTS

#define INVALID_VALUE INT_MAX
#define RESULT_NOT_FOUND -1

#endif // _LOCAL_CONSTANTS

#ifndef _STRUCTS_ENUMS

#endif // _STRUCTS_ENUMS

#ifndef _FUNCTION_PROTOTYPES

int CalculateMaxZigZagPath();
int FindMaxSum(int row, int col);
void ExtractPath(int row, int col);
bool IsInBounds(int row, int col);
void PrintMatrix();
void PrintResult(int result);
void ProcessInput();
void InitialiseResources();
void DisposeResources();

#endif // _FUNCTION_PROTOTYPES

#ifndef _LOCAL_DATA

static int ** previousSteps;
static int ** values;
static int ** matrix;
static int * path;

static int rowsCount;
static int colsCount;
static int pathSize;

#endif // _LOCAL_DATA

#ifndef _MAIN

int main()
{
    ProcessInput();
    int result = CalculateMaxZigZagPath();
    PrintResult(result);
    // PrintMatrix();
    DisposeResources();

    return 0;
}
#endif // _MAIN

#ifndef _ALGO_IMPLEMENTATION

int CalculateMaxZigZagPath()
{
    int maxSum = INT_MIN;
    int maxValueStartRow = RESULT_NOT_FOUND;
    int currentSum;


    for (int index = 0; index < rowsCount; ++index)
    {
        currentSum = FindMaxSum(index, 0);

        if (maxSum < currentSum)
        {
            maxSum = currentSum;
            maxValueStartRow = index;
        }
    }

    ExtractPath(maxValueStartRow, 0);
    return maxSum;
}

int FindMaxSum(int row, int col)
{
    if (!IsInBounds(row, col))
    {
        return 0;
    }

    if (values[row][col] != INVALID_VALUE)
    {
        return values[row][col];
    }

    int maxSum = INT_MIN;
    int currentSum = 0;
    int previousRow = RESULT_NOT_FOUND;

    if (col % 2 == 1)
    {
        for (int index = row + 1; index < rowsCount; ++index)
        {
            currentSum = FindMaxSum(index, col + 1);

            if (maxSum < currentSum)
            {
                maxSum = currentSum;
                if (col != colsCount - 1)
                {
                    previousRow = index;
                }
            }
        }
    }
    else
    {
        for (int index = 0; index < row; ++index)
        {
            currentSum = FindMaxSum(index, col + 1);

            if (maxSum < currentSum)
            {
                maxSum = currentSum;
                if (col != colsCount - 1)
                {
                    previousRow = index;
                }
            }
        }
    }

    previousSteps[row][col] = previousRow;
    values[row][col] = maxSum + matrix[row][col];
    return values[row][col];
}

void ExtractPath(int row, int col)
{
    if (!IsInBounds(row, col))
    {
        return;
    }

    path[pathSize++] = row;
    ExtractPath(previousSteps[row][col], col + 1);
}

bool IsInBounds(int row, int col)
{
    return row >= 0 &&
           row < rowsCount &&
           col >= 0 &&
           col < colsCount;
}

#endif // _ALGO_IMPLEMENTATION

#ifndef _IO_PROCESSING

void ProcessInput()
{
    char garbageInput;
    cin >> rowsCount;
    cin >> colsCount;

    InitialiseResources();

    for (int row = 0; row < rowsCount; ++row)
    {
        for (int col = 0; col < colsCount; ++col)
        {
            int number;
            cin >> number;

            if (col != colsCount - 1)
            {
                cin >> garbageInput; // Ignore ','
            }

            matrix[row][col] = number;
        }
    }
}

void PrintResult(int result)
{
    cout << result << " =";

    for (int i = 0; i < pathSize; ++i)
    {
        cout << " " << matrix[path[i]][i];

        if (i != pathSize - 1)
        {
            cout << " +";
        }
    }

    cout << endl;
}


// Used for debugging
void PrintMatrix()
{
    for (int row = 0; row < rowsCount; ++row)
    {
        for (int col = 0; col < colsCount; ++col)
        {
            cout << matrix[row][col] << " ";
        }

        cout << endl;
    }
}

#endif // _IO_PROCESSING


#ifndef _RESOURCES_MANAGEMENT

void InitialiseResources()
{
    matrix = new int*[rowsCount];
    values = new int*[rowsCount];
    previousSteps = new int*[rowsCount];
    path = new int[colsCount];

    for (int row = 0; row < rowsCount; ++row)
    {
        matrix[row] = new int[colsCount];
        values[row] = new int[colsCount];
        previousSteps[row] = new int[colsCount];

        for (int col = 0; col < colsCount; ++col)
        {
            matrix[row][col] = INVALID_VALUE;
            values[row][col] = INVALID_VALUE;
            previousSteps[row][col] = INVALID_VALUE;
        }
    }
}

void DisposeResources()
{
    for (int row = 0; row < rowsCount; ++row)
    {
        delete[] matrix[row];
        delete[] values[row];
        delete[] previousSteps[row];
    }

    delete[] matrix;
    delete[] values;
    delete[] previousSteps;
    delete[] path;
}

#endif // _RESOURCES_DISPOSAL
