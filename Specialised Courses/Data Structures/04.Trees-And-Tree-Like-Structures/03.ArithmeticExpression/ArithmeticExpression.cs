using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

class ArithmeticExpression
{
    static Regex wordRegex = new Regex("[a-zA-Z]+", RegexOptions.IgnoreCase);
    static Regex numRegex = new Regex("-?[0-9]+", RegexOptions.IgnoreCase);
    static Regex floatingNumRegex = new Regex("-?[0-9]+\\.[0-9]+");

    static void Main()
    {
        string input = Console.ReadLine();

        string[] elements = GetExpressionElements(input);

        Console.WriteLine("Members of the expression:");
        Console.WriteLine(string.Join(", ", elements));

        Queue<string> postfixExpression = ConvertToPostFix(elements);

        Console.WriteLine();
        Console.WriteLine("Postfix version of the expression:");
        Console.WriteLine(string.Join(", ", postfixExpression));

        double result = CalculatePostfixExpression(postfixExpression);

        Console.WriteLine();
        Console.WriteLine("Result: {0}", result);
    }

    // Implementing the Shunting-Yard Algorithm
    private static Queue<string> ConvertToPostFix(string[] elements)
    {
        Queue<string> outputQueue = new Queue<string>();
        Stack<string> operationStack = new Stack<string>();

        foreach (var element in elements)
        {
            /* 1. push numbers in output queue in any case */
            if (numRegex.IsMatch(element))
            {
                outputQueue.Enqueue(element);
            }
            else if (IsOperator(element))
            {
                /* 2. Push operators in operation stack if stack is empty */
                if (operationStack.Count == 0)
                {
                    operationStack.Push(element);
                }
                else
                {
                    /* 
                     * 3. If operator to push is with higher precedence than 
                     * the top one - push it
                     * If not, pop all operators with higher or equal precedence 
                     * and push them to the queue 
                     */
                    while (operationStack.Count > 0 && 
                        IsOperator(element) &&
                        IsOperator(operationStack.Peek()) &&
                        CheckOperatorPrecedence(operationStack.Peek(), element) >= 0)
                    {
                        string topOperatorInStack = operationStack.Pop();
                        outputQueue.Enqueue(topOperatorInStack);
                    }

                    operationStack.Push(element);
                }
            }
            else if (element == "(")
            {
                /* 4. If left paranthesis - push to stack */
                operationStack.Push(element);
            }
            else if (element == ")")
            {
                /* 
                 * 5. If right paranthesis - 
                 * pop all operators from stack into queue
                 * until left paranthesis is reached 
                 */
                while (operationStack.Count > 0 &&
                        operationStack.Peek() != "(")
                {
                    string topOperatorInStack = operationStack.Pop();
                    outputQueue.Enqueue(topOperatorInStack);
                }

                /* If no left paranthesis is reached - The expression is invalid */
                if (operationStack.Count == 0 || operationStack.Peek() != "(")
                {
                    throw new ArgumentException("The expression is invalid");
                }
                else
                {
                    operationStack.Pop();
                }
            }
            else
            {
                /*
                 * If the element is not a number, operator or a paranthesis,
                 * the expression is invalid.
                 */
                throw new ArgumentException("The expression is invalid");
            }
        }

        /*
         * While there are still operator tokens in the stack:
         *     * If the operator token on the top of the stack is a parenthesis, 
         *          then there are mismatched parentheses.
         *     * Pop the operator onto the output queue.
         */
        while (operationStack.Count > 0)
        {
            string topOperatorInStack = operationStack.Pop();
            
            if (!IsOperator(topOperatorInStack))
            {
                throw new ArgumentException("The expression is invalid");
            }

            outputQueue.Enqueue(topOperatorInStack);
        }

        return outputQueue;
    }

    // Implementing the Reverse Polish Notation Algorithm
    private static double CalculatePostfixExpression(Queue<string> postfixExpression)
    {
        Stack<double> operationStack = new Stack<double>();

        /* While the input queue is not empty, dequeue the next element */
        while (postfixExpression.Count > 0)
        {
            string element = postfixExpression.Dequeue();

            /* If the element is a number, push in to the operation stack */
            if (numRegex.IsMatch(element) || floatingNumRegex.IsMatch(element))
            {
                double number = double.Parse(element);
                operationStack.Push(number);
            }
            else if (IsOperator(element))
            {
                /* 
                 * If it is an operator, get the first two elements 
                 * of the operation stack and apply the operator.
                 * If there are less than two numbers in the stack,
                 * the expression is invalid.
                 */
                try
                {
                    double secondNumber = operationStack.Pop();
                    double firstNumber = operationStack.Pop();
                    double result = 0;

                    switch (element)
                    {
                        case "+":
                            result = firstNumber + secondNumber;
                            break;
                        case "-":
                            result = firstNumber - secondNumber;
                            break;
                        case "*":
                            result = firstNumber * secondNumber;
                            break;
                        case "/":
                            result = firstNumber / secondNumber;
                            break;
                        default:
                            throw new ArgumentException("The expression is invalid");
                    }

                    operationStack.Push(result);
                }
                catch (Exception e)
                {
                    throw new ArgumentException("The expression is invalid");
                }
                
            }
            else
            {
                throw new ArgumentException("The expression is invalid");
            }
        }

        /* 
         * If there are more or less than one element in the stack left,
         * the expression is invalid.
         */
        if (operationStack.Count != 1)
        {
            throw new ArgumentException("The expression is invalid");
        }

        return operationStack.Pop();
    }

    private static bool IsOperator(string element)
    {
        if (element == "-" ||
            element == "+" || 
            element == "/" || 
            element == "*")
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    private static int CheckOperatorPrecedence(string first, string second)
    {
        if ((first == "-" || first == "+") &&
            (second == "*" || second == "/"))
        {
            return -1;
        }
        else if ((second == "-" || second == "+") &&
            (first == "*" || first == "/"))
        {
            return 1;
        }
        else
        {
            return 0;
        }
    }

    /* Convert the input string to an array with every member of the expression */
    private static string[] GetExpressionElements(string input)
    {
        Queue<string> output = new Queue<string>();

        string currentExpression = "";
        for (int index = 0; index < input.Length; index++)
        {
            if (wordRegex.IsMatch(input[index].ToString()))
            {
                currentExpression += input[index];
            }
            else if (numRegex.IsMatch(input[index].ToString()) || 
                input[index] == '.' ||
                    (input[index] == '-' && 
                    index + 1 < input.Length &&
                    numRegex.IsMatch(input[index + 1].ToString())))
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