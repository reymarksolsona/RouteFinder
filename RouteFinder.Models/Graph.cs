namespace RouteFinder.Models
{
    public class Graph
    {
        public Dictionary<string, List<Edge>> AdjacencyList { get; set; }

        public Graph()
        {
            AdjacencyList = new Dictionary<string, List<Edge>>();
        }

        public void AddEdge(string from, string to, int distance)
        {
            if (!AdjacencyList.ContainsKey(from))
            {
                AdjacencyList[from] = new List<Edge>();
            }
            AdjacencyList[from].Add(new Edge(to, distance));
        }
    }

}
