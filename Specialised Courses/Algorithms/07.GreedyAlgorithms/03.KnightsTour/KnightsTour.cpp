#ifndef _LIBS_NAMESPACES

#include <stdlib.h>
#include <iostream>
#include <iomanip>

using namespace std;

#endif // _LIBS_NAMESPACES

#ifndef _LOCAL_CONSTANTS

#define PAD_LENGTH 4
#define START_ROW 0
#define START_COL 0

#define TOP_LEFT(row, col) row - 2, col - 1
#define TOP_RIGHT(row, col) row - 2, col + 1
#define BOT_LEFT(row, col) row + 2, col - 1
#define BOT_RIGHT(row, col) row + 2, col + 1
#define LEFT_TOP(row, col) row - 1, col - 2
#define LEFT_BOT(row, col) row + 1, col - 2
#define RIGHT_TOP(row, col) row - 1, col + 2
#define RIGHT_BOT(row, col) row + 1, col + 2

#endif // _LOCAL_CONSTANTS

#ifndef _STRUCTS_ENUMS

typedef enum
{
    eTopLeft,
    eTopRight,
    eBotLeft,
    eBotRight,
    eRightTop,
    eRightBot,
    eLeftTop,
    eLeftBot,
    eInvalidMove
} Move;

#endif // _STRUCTS_ENUMS

#ifndef _FUNCTION_PROTOTYPES

void CalculateKnightsTour(int startRow, int startCol);
bool ProcessMove(Move nextMove, int * row, int * col);
Move FindOptimalMoveChoice(int row, int col);
int CalculatePossibleMoves(int row, int col);
bool IsPossibleMove(int row, int col);
bool IsFreeCell(int row, int col);
void ProcessInput();
void PrintBoard();
void InitializeResources();
void DisposeResources();

#endif // _FUNCTION_PROTOTYPES

#ifndef _LOCAL_DATA

static int ** board;

static int boardSize;
static int currentStep = 1;

#endif // _LOCAL_DATA

#ifndef _MAIN

int main()
{
    ProcessInput();
    InitializeResources();
    CalculateKnightsTour(START_ROW, START_COL);
    PrintBoard();

    DisposeResources();

    return 0;
}

#endif // _MAIN

#ifndef _ALGO_IMPLEMENTATION

void CalculateKnightsTour(int startRow, int startCol)
{
    int currentRow = startRow;
    int currentCol = startCol;

    bool resultFound;

    do
    {
        resultFound = false;
        Move nextMove = FindOptimalMoveChoice(currentRow, currentCol);
        resultFound = ProcessMove(nextMove, &currentRow, &currentCol);

    } while(resultFound);
}

bool ProcessMove(Move nextMove, int * row, int * col)
{
    switch (nextMove)
    {
        case eTopLeft:
            (*row) -= 2;
            (*col) -= 1;
            break;
        case eTopRight:
            (*row) -= 2;
            (*col) += 1;
            break;
        case eBotLeft:
            (*row) += 2;
            (*col) -= 1;
            break;
        case eBotRight:
            (*row) += 2;
            (*col) += 1;
            break;
        case eLeftTop:
            (*row) -= 1;
            (*col) -= 2;
            break;
        case eLeftBot:
            (*row) += 1;
            (*col) -= 2;
            break;
        case eRightTop:
            (*row) -= 1;
            (*col) += 2;
            break;
        case eRightBot:
            (*row) += 1;
            (*col) += 2;
            break;
        default:
            return false;
    }

    board[(*row)][(*col)] = ++currentStep;
    return true;
}

// Implementing the Warnsdorf's rule
Move FindOptimalMoveChoice(int row, int col)
{
    int minMoves = INT_MAX;
    int previousMoves = INT_MAX;
    Move nextMove = eInvalidMove;

    // Top right
    minMoves = min(minMoves, CalculatePossibleMoves(TOP_RIGHT(row, col)));
    nextMove = minMoves != previousMoves ? eTopRight : nextMove;
    previousMoves = minMoves;

    // Right top
    minMoves = min(minMoves, CalculatePossibleMoves(RIGHT_TOP(row, col)));
    nextMove = minMoves != previousMoves ? eRightTop : nextMove;
    previousMoves = minMoves;

    // Right bot
    minMoves = min(minMoves, CalculatePossibleMoves(RIGHT_BOT(row, col)));
    nextMove = minMoves != previousMoves ? eRightBot : nextMove;
    previousMoves = minMoves;

    // Bot right
    minMoves = min(minMoves, CalculatePossibleMoves(BOT_RIGHT(row, col)));
    nextMove = minMoves != previousMoves ? eBotRight : nextMove;
    previousMoves = minMoves;

    // Bot left
    minMoves = min(minMoves, CalculatePossibleMoves(BOT_LEFT(row, col)));
    nextMove = minMoves != previousMoves ? eBotLeft : nextMove;
    previousMoves = minMoves;

    // Left bot
    minMoves = min(minMoves, CalculatePossibleMoves(LEFT_BOT(row, col)));
    nextMove = minMoves != previousMoves ? eLeftBot : nextMove;
    previousMoves = minMoves;

    // Left top
    minMoves = min(minMoves, CalculatePossibleMoves(LEFT_TOP(row, col)));
    nextMove = minMoves != previousMoves ? eLeftTop : nextMove;
    previousMoves = minMoves;

    // Top left
    minMoves = min(minMoves, CalculatePossibleMoves(TOP_LEFT(row, col)));
    nextMove = minMoves != previousMoves ? eTopLeft : nextMove;
    previousMoves = minMoves;

    return nextMove;
}

int CalculatePossibleMoves(int row, int col)
{
    if (!IsPossibleMove(row, col) || !IsFreeCell(row, col))
    {
        return INT_MAX;
    }

    int cnt = 0;

    if (IsPossibleMove(TOP_RIGHT(row, col)) && IsFreeCell(TOP_RIGHT(row, col)))
    {
        ++cnt;
    }

    if (IsPossibleMove(TOP_LEFT(row, col)) && IsFreeCell(TOP_LEFT(row, col)))
    {
        ++cnt;
    }

    if (IsPossibleMove(BOT_RIGHT(row, col)) && IsFreeCell(BOT_RIGHT(row, col)))
    {
        ++cnt;
    }

    if (IsPossibleMove(BOT_LEFT(row, col)) && IsFreeCell(BOT_LEFT(row, col)))
    {
        ++cnt;
    }

    if (IsPossibleMove(RIGHT_TOP(row, col)) && IsFreeCell(RIGHT_TOP(row, col)))
    {
        ++cnt;
    }

    if (IsPossibleMove(RIGHT_BOT(row, col)) && IsFreeCell(RIGHT_BOT(row, col)))
    {
        ++cnt;
    }

    if (IsPossibleMove(LEFT_TOP(row, col)) && IsFreeCell(LEFT_TOP(row, col)))
    {
        ++cnt;
    }

    if (IsPossibleMove(LEFT_BOT(row, col)) && IsFreeCell(LEFT_BOT(row, col)))
    {
        ++cnt;
    }

    return cnt;
}

bool IsFreeCell(int row, int col)
{
    return board[row][col] == 0;
}

bool IsPossibleMove(int row, int col)
{
    return row >= 0 &&
           row < boardSize &&
           col >= 0 &&
           col < boardSize;
}

#endif // _ALGO_IMPLEMENTATION

#ifndef _IO_PROCESSING

void ProcessInput()
{
    cin >> boardSize;
}

void PrintBoard()
{
    for (int row = 0; row < boardSize; ++row)
    {
        for (int col = 0; col < boardSize; ++col)
        {
            cout << setfill(' ') << setw(PAD_LENGTH) << board[row][col];
        }

        cout << endl;
    }
}

#endif // _IO_PROCESSING

#ifndef _RESOURCES_MANAGEMENT

void InitializeResources()
{
    board = (int**)malloc(sizeof(int*) * boardSize);

    for (int row = 0; row < boardSize; ++row)
    {
        board[row] = (int*)malloc(sizeof(int) * boardSize);

        for (int col = 0; col < boardSize; ++col)
        {
            board[row][col] = 0;
        }
    }

    board[0][0] = 1;
}

void DisposeResources()
{
    for (int row = 0; row < boardSize; ++row)
    {
        free(board[row]);
    }

    free(board);
}

#endif // _RESOURCES_MANAGEMENT
