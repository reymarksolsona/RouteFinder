namespace RouteFinder.Models
{
    public class Edge
    {
        public string Destination { get; set; }
        public int Distance { get; set; }

        public Edge(string destination, int distance)
        {
            Destination = destination;
            Distance = distance;
        }
    }
}
