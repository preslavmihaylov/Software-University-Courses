namespace _04.DistanceCalculator_REST_Client
{
    using System;
    using System.Net;

    class DistanceCalculatorRESTClient
    {
        private const string ServiceUrl = "http://localhost:2499/api/Math/CalculateDistance";
        private const string ServiceParameters = "?startX=4&startY=5&endX=2&endY=2";

        static void Main()
        {
            WebClient client = new WebClient();

            var result = client.DownloadString(ServiceUrl + ServiceParameters);
            
            Console.WriteLine("Result: " + result);
        }
    }
}