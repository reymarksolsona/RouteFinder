using RouteFinder.Service;

namespace RouteFinder
{
    public class Program
    {
        static void Main(string[] args)
        {
            try
            {
                var graph = GraphFactory.CreateGraphFromFile(@"../../../../RouteFinder.InputFiles/Input.txt");

                var calculator = new RouteCalculator(graph);

                var routeCalculator = new RouteCalculator(graph);

                var route1 = new List<string> { "A", "B", "C" };
                Console.WriteLine($"Test #1: Distance A->B->C: {routeCalculator.CalculateRouteDistance(route1)}");

                var route2 = new List<string> { "A", "D" };
                Console.WriteLine($"Test #2: Distance A->D: {routeCalculator.CalculateRouteDistance(route2)}");

                var route3 = new List<string> { "A", "D", "C" };
                Console.WriteLine($"Test #3: Distance A->D->C: {routeCalculator.CalculateRouteDistance(route3)}");

                var route4 = new List<string> { "A", "E", "B", "C", "D" };
                Console.WriteLine($"Test #4: Distance A->E->B->C->D: {routeCalculator.CalculateRouteDistance(route4)}");

                var route5 = new List<string> { "A", "E", "D" };
                Console.WriteLine($"Test #5: Route A->E->D exists: {routeCalculator.DoesRouteExist(route5)}");

                Console.WriteLine($"Test #6: Number of trips from C to C with max 3 stops: {routeCalculator.CountRoutesWithMaxStops("C", "C", 3)}");
                Console.WriteLine($"Test #7: Number of trips from A to C with exactly 4 stops: {routeCalculator.CountRoutesWithExactStops("A", "C", 4)}");
                Console.WriteLine($"Test #8: Shortest route from A to C: {routeCalculator.ShortestRoute("A", "C")}");
                Console.WriteLine($"Test #9: Shortest route from B to B: {routeCalculator.ShortestRoute("B", "B")}");
                Console.WriteLine($"Test #10: Number of trips from C to C with distance less than 30: {routeCalculator.CountRoutesWithDistanceLessThan("C", "C", 30)}");
            
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }
    }
}
