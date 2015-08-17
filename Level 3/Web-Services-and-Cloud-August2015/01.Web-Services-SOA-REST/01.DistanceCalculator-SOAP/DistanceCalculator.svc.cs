namespace _01.DistanceCalculator_SOAP
{
    using System;

    public class DistanceCalculator : IDistanceCalculator
    {
        public double CalculateDistance(Point startPoint, Point endPoint)
        {
            int deltaX = startPoint.X - endPoint.X;
            int deltaY = startPoint.Y - endPoint.Y;

            return Math.Sqrt(Math.Pow(deltaX, 2) + Math.Pow(deltaY, 2));
        }
    }
}
