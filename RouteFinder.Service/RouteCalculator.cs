using RouteFinder.Models;

namespace RouteFinder.Service
{
    public class RouteCalculator
    {
        private readonly Graph _graph;

        public RouteCalculator(Graph graph)
        {
            _graph = graph;
        }

        public int CalculateRouteDistance(List<string> route)
        {
            int totalDistance = 0;
            for (int i = 0; i < route.Count - 1; i++)
            {
                string from = route[i], to = route[i + 1];
                var edge = _graph.AdjacencyList[from]?.FirstOrDefault(e => e.Destination == to);
                if (edge == null)
                    throw new Exception($"No direct route between {from} and {to}");
                totalDistance += edge.Distance;
            }
            return totalDistance;
        }

        public string DoesRouteExist(List<string> route)
        {
            try
            {
                CalculateRouteDistance(route);
                return "Route exists.";
            }
            catch
            {
                return "Route doesn't exists.";
            }
        }

        public int CountRoutesWithMaxStops(string start, string end, int maxStops)
        {
            return CountRoutesWithStops(start, end, 0, maxStops, false);
        }

        public int CountRoutesWithExactStops(string start, string end, int exactStops)
        {
            return CountRoutesWithStops(start, end, 0, exactStops, true);
        }

        private int CountRoutesWithStops(string current, string end, int stops, int targetStops, bool exact)
        {
            if (stops > targetStops) return 0;

            int count = 0;
            if (current == end && stops > 0 && (exact ? stops == targetStops : stops <= targetStops))
            {
                count = 1;
            }

            if (_graph.AdjacencyList.ContainsKey(current))
            {
                foreach (var edge in _graph.AdjacencyList[current])
                {
                    count += CountRoutesWithStops(edge.Destination, end, stops + 1, targetStops, exact);
                }
            }

            return count;
        }

        public int ShortestRoute(string start, string end)
        {
            return FindShortestPath(start, end, 0, new HashSet<string>());
        }

        private int FindShortestPath(string current, string end, int distance, HashSet<string> visited)
        {
            if (current == end && visited.Count > 0) return distance;
            visited.Add(current);

            int shortest = int.MaxValue;
            if (_graph.AdjacencyList.ContainsKey(current))
            {
                foreach (var edge in _graph.AdjacencyList[current])
                {
                    if (!visited.Contains(edge.Destination) || edge.Destination == end)
                    {
                        int path = FindShortestPath(edge.Destination, end, distance + edge.Distance, new HashSet<string>(visited));
                        shortest = Math.Min(shortest, path);
                    }
                }
            }
            return shortest == int.MaxValue ? 0 : shortest;
        }

        public int CountRoutesWithDistanceLessThan(string start, string end, int maxDistance)
        {
            return CountRoutesWithDistance(start, end, 0, maxDistance);
        }

        private int CountRoutesWithDistance(string current, string end, int distance, int maxDistance)
        {
            if (distance >= maxDistance) return 0;

            int count = current == end && distance > 0 ? 1 : 0;
            if (_graph.AdjacencyList.ContainsKey(current))
            {
                foreach (var edge in _graph.AdjacencyList[current])
                {
                    count += CountRoutesWithDistance(edge.Destination, end, distance + edge.Distance, maxDistance);
                }
            }
            return count;
        }
    }
}
