using RouteFinder.Models;
using RouteFinder.Service;

namespace RouteFinder.Tests
{
    public class RouteCalculatorTests
    {
        private readonly Graph _graph;
        private readonly RouteCalculator _routeCalculator;

        public RouteCalculatorTests()
        {
            string filePath = "../../../../RouteFinder.InputFiles/Input.txt";
            _graph = GraphFactory.CreateGraphFromFile(filePath);
            _routeCalculator = new RouteCalculator(_graph);
        }

        [Fact]
        public void Test1_CalculateDistance_A_B_C()
        {
            var route = new List<string> { "A", "B", "C" };
            int result = _routeCalculator.CalculateRouteDistance(route);
            Assert.Equal(9, result);
        }

        [Fact]
        public void Test2_CalculateDistance_A_D()
        {
            var route = new List<string> { "A", "D" };
            int result = _routeCalculator.CalculateRouteDistance(route);
            Assert.Equal(5, result);
        }

        [Fact]
        public void Test3_CalculateDistance_A_D_C()
        {
            var route = new List<string> { "A", "D", "C" };
            int result = _routeCalculator.CalculateRouteDistance(route);
            Assert.Equal(13, result);
        }

        [Fact]
        public void Test4_CalculateDistance_A_E_B_C_D()
        {
            var route = new List<string> { "A", "E", "B", "C", "D" };
            int result = _routeCalculator.CalculateRouteDistance(route);
            Assert.Equal(22, result);
        }

        [Fact]
        public void Test5_RouteDoesNotExist_A_E_D()
        {
            var route = new List<string> { "A", "E", "D" };
            Assert.Throws<Exception>(() => _routeCalculator.CalculateRouteDistance(route));
        }

        [Fact]
        public void Test6_CountTrips_C_C_Max3Stops()
        {
            int result = _routeCalculator.CountRoutesWithMaxStops("C", "C", 3);
            Assert.Equal(2, result);
        }

        [Fact]
        public void Test7_CountTrips_A_C_Exact4Stops()
        {
            int result = _routeCalculator.CountRoutesWithExactStops("A", "C", 4);
            Assert.Equal(3, result);
        }

        [Fact]
        public void Test8_ShortestRoute_A_C()
        {
            int result = _routeCalculator.ShortestRoute("A", "C");
            Assert.Equal(9, result);
        }

        [Fact]
        public void Test9_ShortestRoute_B_B()
        {
            int result = _routeCalculator.ShortestRoute("B", "B");
            Assert.Equal(9, result);
        }

        [Fact]
        public void Test10_CountTrips_C_C_MaxDistance30()
        {
            int result = _routeCalculator.CountRoutesWithDistanceLessThan("C", "C", 30);
            Assert.Equal(7, result);
        }
    }
}