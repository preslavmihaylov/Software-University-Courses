#include <iostream>
#include <math.h>

#define MAX_DATA 100

using namespace std;

/* FUNCTION PROTOTYPES */
int FindBinomialCoefficient(int n, int k);
void ProcessInput();

static int pascalTriangle[MAX_DATA][MAX_DATA];

static int initialN;
static int initialK;

int main()
{
    ProcessInput();
    int result = FindBinomialCoefficient(initialN, initialK);
    cout << result << endl;
    return 0;
}

int FindBinomialCoefficient(int n, int k)
{
    int firstTerm;
    int secondTerm;

    if (k <= 0 || k >= n)
    {
        return 1;
    }

    if (!pascalTriangle[n - 1][k - 1])
    {
        firstTerm = FindBinomialCoefficient(n - 1, k - 1);
        pascalTriangle[n - 1][k - 1] = firstTerm;
    }
    else
    {
        firstTerm = pascalTriangle[n - 1][k - 1];
    }

    if (!pascalTriangle[n - 1][k])
    {
        secondTerm = FindBinomialCoefficient(n - 1, k);
        pascalTriangle[n - 1][k] = secondTerm;
    }
    else
    {
        secondTerm = pascalTriangle[n - 1][k];
    }

    return firstTerm + secondTerm;
}

void ProcessInput()
{
    cin >> initialN;
    cin >> initialK;
}
