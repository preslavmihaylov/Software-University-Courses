#ifndef _LIBS_NAMESPACES

#include <iostream>

using namespace std;

#endif // _LIBS_NAMESPACES

#ifndef _LOCAL_CONSTANTS

#define RESULT_NOT_FOUND -1

#endif // _LOCAL_CONSTANTS

#ifndef _STRUCTS_ENUMS

#endif // _STRUCTS_ENUMS

#ifndef _FUNCTION_PROTOTYPES

void TryTurningBoardBlack();
void InvertRow(int row);
void InvertCol(int col);
bool IsBoardBlack();
void PrintPositiveResult();
void PrintNegativeResult();
void ProcessInput();
void InitializeResources();
void DisposeResources();

#endif // _FUNCTION_PROTOTYPES

#ifndef _LOCAL_DATA

static bool ** board;

static int boardSize;
static int stepsCount;

#endif // _LOCAL_DATA

#ifndef _MAIN

int main()
{
    ProcessInput();
    TryTurningBoardBlack();

    if (IsBoardBlack())
    {
        PrintPositiveResult();
    }
    else
    {
        PrintNegativeResult();
    }

    DisposeResources();

    return 0;
}
#endif // _MAIN

#ifndef _ALGO_IMPLEMENTATION

void TryTurningBoardBlack()
{
    for (int row = 0; row < boardSize; ++row)
    {
        if (!board[row][0])
        {
            ++stepsCount;
            InvertRow(row);
        }
    }

    for (int col = 0; col < boardSize; ++col)
    {
        if (!board[0][col])
        {
            ++stepsCount;
            InvertCol(col);
        }
    }
}

void InvertRow(int row)
{
    for (int index = 0; index < boardSize; ++index)
    {
        board[row][index] = !board[row][index];
    }
}

void InvertCol(int col)
{
    for (int index = 0; index < boardSize; ++index)
    {
        board[index][col] = !board[index][col];
    }
}

bool IsBoardBlack()
{
    for (int row = 0; row < boardSize; ++row)
    {
        for (int col = 0; col < boardSize; ++col)
        {
            if (!board[row][col])
            {
                return false;
            }
        }
    }

    return true;
}

#endif // _ALGO_IMPLEMENTATION

#ifndef _IO_PROCESSING

void ProcessInput()
{
    cin >> boardSize;

    InitializeResources();

    for (int row = 0; row < boardSize; ++row)
    {
        board[row] = new bool[boardSize];

        for (int col = 0; col < boardSize; ++col)
        {
            char input;

            cin >> input;

            if (input == 'W')
            {
                board[row][col] = false;
            }
            else
            {
                board[row][col] = true;
            }
        }
    }
}

void PrintPositiveResult()
{
    cout << stepsCount << endl;
}

void PrintNegativeResult()
{
    cout << RESULT_NOT_FOUND << endl;
}

#endif // _IO_PROCESSING

#ifndef _RESOURCES_MANAGEMENT

void InitializeResources()
{
    board = new bool*[boardSize];
}

void DisposeResources()
{
    for (int index = 0; index < boardSize; ++index)
    {
        delete[] board[index];
    }

    delete[] board;
}

#endif // _RESOURCES_DISPOSAL
