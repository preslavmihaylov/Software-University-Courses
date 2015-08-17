namespace _01.DistanceCalculator_SOAP
{
    using System.Runtime.Serialization;
    using System.ServiceModel;

    [ServiceContract]
    public interface IDistanceCalculator
    {
        [OperationContract]
        double CalculateDistance(Point startPoint, Point endPoint);
    }


    // Use a data contract as illustrated in the sample below to add composite types to service operations.
    [DataContract]
    public class Point
    {
        [DataMember]
        public int X { get; set; }

        [DataMember]
        public int Y { get; set; }
    }
}
