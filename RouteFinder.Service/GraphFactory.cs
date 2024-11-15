using RouteFinder.Models;

namespace RouteFinder.Service
{
    public class GraphFactory
    {
        public static Graph CreateGraphFromFile(string filePath)
        {
            if (!File.Exists(filePath))
                throw new FileNotFoundException("Input file not found.");

            var graph = new Graph();
            var lines = File.ReadAllLines(filePath);
            foreach (var line in lines)
            {
                var parts = line.Split(',');
                if (parts.Length != 3)
                    throw new Exception("Invalid input format.");

                string from = parts[0], to = parts[1];
                if (!int.TryParse(parts[2], out int distance))
                    throw new Exception("Invalid distance format.");

                graph.AddEdge(from, to, distance);
            }
            return graph;
        }
    }
}
