#ifndef _LIBS_NAMESPACES

#include <stdlib.h>
#include <stdio.h>

#include <iostream>
#include <string>
#include <vector>

using namespace std;

#endif // _LIBS_NAMESPACES


#ifndef _LOCAL_CONSTANTS


#endif // _LOCAL_CONSTANTS

#ifndef _STRUCTS_ENUMS

typedef struct
{
    int numerator;
    int denominator;
} Fraction;

#endif // _STRUCTS_ENUMS

#ifndef _FUNCTION_PROTOTYPES

void ProcessEgyptianFractionCalculation();
void CalculateEgyptianFraction(Fraction inputFraction);
Fraction SubtractFraction(Fraction firstTerm, Fraction secondTerm);
void NormalizeFraction(Fraction * fraction);
Fraction ProcessInput();
void PrintEgyptianFractions(Fraction inputFraction);
void PrintInvalidFractionError();

#endif // _FUNCTION_PROTOTYPES

#ifndef _LOCAL_DATA

static vector<Fraction> egyptianFractions;

#endif // _LOCAL_DATA

#ifndef _MAIN

int main()
{
    ProcessEgyptianFractionCalculation();

    return 0;
}

#endif // _MAIN

#ifndef _ALGO_IMPLEMENTATION

void ProcessEgyptianFractionCalculation()
{
    Fraction fraction = ProcessInput();

    if (fraction.numerator < fraction.denominator)
    {
        CalculateEgyptianFraction(fraction);
        PrintEgyptianFractions(fraction);
    }
    else
    {
        PrintInvalidFractionError();
    }
}

void CalculateEgyptianFraction(Fraction inputFraction)
{
    Fraction currentFraction;
    int currentDenominator = 2;

    while (inputFraction.numerator != 0)
    {
        currentFraction.numerator = 1;
        currentFraction.denominator = currentDenominator;

        Fraction result = SubtractFraction(inputFraction, currentFraction);

        if (result.numerator >= 0)
        {
            inputFraction = result;
            egyptianFractions.push_back(currentFraction);
        }

        ++currentDenominator;
    }
}

Fraction SubtractFraction(Fraction firstTerm, Fraction secondTerm)
{
    if ( firstTerm.denominator == secondTerm.denominator)
    {
        firstTerm.numerator -= secondTerm.numerator;
    }
    else
    {
        int firstTermDenominator = firstTerm.denominator;
        firstTerm.numerator *= secondTerm.denominator;
        firstTerm.denominator *= secondTerm.denominator;

        secondTerm.numerator *= firstTermDenominator;
        secondTerm.denominator *= firstTermDenominator;

        firstTerm.numerator -= secondTerm.numerator;
    }

    NormalizeFraction(&firstTerm);

    return firstTerm;
}

void NormalizeFraction(Fraction * fraction)
{
    while ( (*fraction).numerator % 2 == 0 &&
            (*fraction).denominator % 2 == 0)
    {
        (*fraction).numerator /= 2;
        (*fraction).denominator /= 2;
    }
}

#endif // _ALGO_IMPLEMENTATION

#ifndef _IO_PROCESSING

Fraction ProcessInput()
{
    Fraction inputFraction;

    string input;

    cin >> input;

    int slashIndex = input.find('/');

    inputFraction.numerator = atoi(input.substr(0, slashIndex).c_str());
    inputFraction.denominator = atoi(input.substr(slashIndex + 1, input.size() - 1).c_str());

    return inputFraction;
}

void PrintEgyptianFractions(Fraction inputFraction)
{
    printf("%d/%d = ", inputFraction.numerator, inputFraction.denominator);

    for (vector<Fraction>::iterator it = egyptianFractions.begin(); it != egyptianFractions.end(); ++it)
    {
        Fraction fraction = *it;
        printf("%d/%d", fraction.numerator, fraction.denominator);

        if (fraction.denominator != egyptianFractions.at(egyptianFractions.size() - 1).denominator)
        {
            printf(" + ");
        }
    }

    cout << endl;
}

void PrintInvalidFractionError()
{
    cout << "Error (fraction is equal to or greater than 1)" << endl;
}

#endif // _IO_PROCESSING

#ifndef _RESOURCES_MANAGEMENT

#endif // _RESOURCES_MANAGEMENT
