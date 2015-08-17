namespace _02.DistanceCalculator_SOAP_Client
{
    using System;
    using DistanceCalculator;

    class DistanceCalculatorSOAPClient
    {
        static void Main()
        {
            DistanceCalculatorClient calculator = new DistanceCalculatorClient();

            Point startPoint = new Point()
            {
                X = 5,
                Y = 4
            };

            Point endPoint = new Point()
            {
                X = 10,
                Y = 30
            };

            double result = calculator.CalculateDistance(startPoint, endPoint);

            Console.WriteLine(result);
        }
    }
}