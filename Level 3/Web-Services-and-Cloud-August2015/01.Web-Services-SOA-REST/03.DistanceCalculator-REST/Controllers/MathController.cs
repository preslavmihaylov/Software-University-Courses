namespace _03.DistanceCalculator_REST.Controllers
{
    using System;
    using System.Web.Http;

    public class MathController : ApiController
    {
        [HttpGet]
        public double CalculateDistance(int startX, int startY, int endX, int endY)
        {
            int deltaX = startX - endX;
            int deltaY = startY - endY;

            return Math.Sqrt(Math.Pow(deltaX, 2) + Math.Pow(deltaY, 2));
        }
    }
}
