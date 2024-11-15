namespace RouteFinder.Core
{
    public class Route
    {
        public string From { get; set; }
        public string To { get; set; }
        public int Distance { get; set; }

        public Route(string from, string to, int distance)
        {
            From = from;
            To = to;
            Distance = distance;
        }
    }

}
