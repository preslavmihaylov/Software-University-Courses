using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

class MathExpressionCalculator
{

    static Regex wordRegex = new Regex("[a-zA-Z]+", RegexOptions.IgnoreCase);
    static Regex numRegex = new Regex("[0-9]+", RegexOptions.IgnoreCase);
    static void Main()
    {
        string input = Console.ReadLine();

        string[] elements = getExpressionElements(input);

        Queue<string> postfixElements = convertToPostfix(elements);

        Console.Write("Postfix Notation: ");
        foreach (var element in postfixElements)
        {
            Console.Write(element + " ");
        }
        Console.WriteLine();

        string output = calculatePostfixExpression(postfixElements);

        Console.WriteLine("Result: {0}", output);
    }

    private static string calculatePostfixExpression(Queue<string> postfixElements)
    {
        Stack<string> output = new Stack<string>();

        while (postfixElements.Count > 0)
        {
            string currentToken = postfixElements.Dequeue();
            if (numRegex.IsMatch(currentToken))
            {
                output.Push(currentToken);
            }
            else
            {
                string result = evaluateExpression(ref output, currentToken);
                output.Push(result);
            }
        }

        if (output.Count > 1)
        {
            Console.WriteLine("Invalid Expression");
            Environment.Exit(0);
        }

        return output.Pop();
    }

    private static string evaluateExpression(ref Stack<string> output, string currentToken)
    {
        double result = 0;
        double firstNum = Convert.ToDouble(output.Pop());
        if (currentToken.ToLower() == "sqrt")
        {
            result = Math.Sqrt(firstNum);
            return result.ToString();
        }
        else if (currentToken.ToLower() == "sqrt")
        {
            result = Math.Log(firstNum);
            return result.ToString();
        }

        double secondNum = Convert.ToDouble(output.Pop());

        if (currentToken == "+")
        {
            result = firstNum + secondNum;
        }
        else if (currentToken == "-")
        {
            result = secondNum - firstNum;
        }
        else if (currentToken == "/") 
        {
            result = secondNum / firstNum;
        }
        else if (currentToken == "*")
        {
            result = firstNum * secondNum;
        }
        else if (currentToken.ToLower() == "pow") 
        {
            result = Math.Pow(secondNum, firstNum);
        }

        return result.ToString();
    }

    private static Queue<string> convertToPostfix(string[] elements) // Shunting Yard Algorithm
    {
        Stack<string> unusedOperators = new Stack<string>();
        Queue<string> output = new Queue<string>();

        for (int index = 0; index < elements.Length; index++)
        {
            string currentToken = elements[index];

            if (numRegex.IsMatch(currentToken)) // number --> Queue
            {
                output.Enqueue(currentToken);
            }
            else if (wordRegex.IsMatch(currentToken) || currentToken == "(") // function || left parantheses --> Stack
            {
                unusedOperators.Push(currentToken);
            }
            else if (currentToken == ",") // Pop elements from the stack to the queue until the peek element is not left parantheses
            {
                while (unusedOperators.Peek() != "(")
                {
                    output.Enqueue(unusedOperators.Pop());
                    if (unusedOperators.Count == 0)
	                {
		                Console.WriteLine("Invalid expression");
                        Environment.Exit(0);
	                }
                }
            }
            // while the peek element of the stack is an operator and is with equal or higher precedence --> Enqueue the peek element
            else if (isOperator(currentToken))
            {
                while (unusedOperators.Count > 0 
                    && isOperator(unusedOperators.Peek()) 
                    && isLowerPrecedence(currentToken, unusedOperators.Peek()))
                {
                    output.Enqueue(unusedOperators.Pop());
                }

                unusedOperators.Push(currentToken);
            }
            // if the token is right parantheses, pop everything out into the queue until left parantheses is reached.
            else if (currentToken == ")") 
            {
                while (unusedOperators.Peek() != "(")
                {
                    output.Enqueue(unusedOperators.Pop());
                    if (unusedOperators.Count == 0)
                    {
                        Console.WriteLine("Invalid expression");
                        Environment.Exit(0);
                    }
                }
                if (unusedOperators.Peek() != "(")
                {
                    Console.WriteLine("Invalid expression");
                    Environment.Exit(0);
                }
                else
                {
                    unusedOperators.Pop();
                }

                if (wordRegex.IsMatch(unusedOperators.Peek()))
                {
                    output.Enqueue(unusedOperators.Pop());
                }
            }
        }

        while (unusedOperators.Count > 0)
        {
            if (unusedOperators.Peek() == "(" || unusedOperators.Peek() == ")")
            {
                Console.WriteLine("Invalid expression");
                Environment.Exit(0);
            }

            output.Enqueue(unusedOperators.Pop());
        }

        return output;
    }

    private static bool isOperator(string element)
    {
        if (element == "+" || element == "-" || element == "/" || element == "*")
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    private static bool isLowerPrecedence(string firstToken, string secondToken)
    {
        if ((firstToken == "-" || firstToken == "+") && secondToken == "*" || secondToken == "/")
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    private static string[] getExpressionElements(string input)
    {
        Queue<string> output = new Queue<string>();

        string currentExpression = "";
        for (int index = 0; index < input.Length; index++)
        {
            if (wordRegex.IsMatch(input[index].ToString()))
            {
                currentExpression += input[index];
            }
            else if (numRegex.IsMatch(input[index].ToString()) || input[index] == '.') 
            {
                currentExpression += input[index];
            }
            else if (currentExpression.Length > 0)
            {
                output.Enqueue(currentExpression);
                currentExpression = "";
                index--;
            }
            else
            {
                if (input[index] != ' ')
                {
                    output.Enqueue(input[index].ToString());
                }
            }
        }

        if (currentExpression.Length > 0)
        {
            output.Enqueue(currentExpression);
        }

        return output.ToArray();
    }
}
