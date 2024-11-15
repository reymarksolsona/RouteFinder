using RouteFinder.Core;

public class RouteGraph
{
    private Dictionary<string, List<Route>> _routes;

    public RouteGraph()
    {
        _routes = new Dictionary<string, List<Route>>();
    }

    public void AddRoute(string from, string to, int distance)
    {
        if (!_routes.ContainsKey(from))
        {
            _routes[from] = new List<Route>();
        }
        _routes[from].Add(new Route(from, to, distance));
    }

    public List<Route> GetRoutesFrom(string town)
    {
        return _routes.ContainsKey(town) ? _routes[town] : new List<Route>();
    }

    public bool IsRouteExist(string from, string to)
    {
        return _routes.ContainsKey(from) && _routes[from].Any(r => r.To == to);
    }
}
