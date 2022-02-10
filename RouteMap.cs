using System.Text;
class RouteMap
{
    private List<AirportNode> A; //List of airport nodes.
    public RouteMap() //RouteMap constructor. 5%
    {
        A = new List<AirportNode>(); // initializes the list
    }
    public bool FindAirport(string name) //Method to find airport by name. 5%
    {
        // look through each airport node by name and compare
        foreach (AirportNode a in A)
        {
            if (a.Name.Equals(name)) // compare names
            {
                return true;    // airport node name found
            }
        }
        return false;   // airport node name not found
    }
    public bool FindAirportCode(string code) //Method to find airport by code. 5%
    {
        // look through each airport node by code and compare
        foreach (AirportNode a in A)
        {
            if (a.Code.Equals(code)) // compare codes
            {
                return true;    // found airport code
            }
        }
        return false;   // airport code not found
    }
    public bool AddAirport(AirportNode a) //Method to add airportnode. Duplicates not allowed. 5%
    {
        // checks if airpot node name and code and already present before adding
        if (!FindAirport(a.Name) && !FindAirportCode(a.Code))
        {
            A.Add(a);   // adds airport node
            return true;
        }
        else
        {
            return false; // no airport node added
        }
    }

    public bool RemoveAirport(AirportNode a) //Method to remove airport node. Node must exist. 5%
    {
        if (A.Contains(a)) // checks if route map contains removal airport node
        {
            A.Remove(a); // removes the airport node
            return true;
        }
        return false; // no airport node removed
    }

    public bool AddRoute(AirportNode origin, AirportNode dest) // 5%
    {
        if (origin.Destinations.Contains(dest)) // checks if route is already present
        {
            return false;
        }
        else
        {
            origin.AddDestination(dest);    // route added
            return true;
        }

    }
    public bool RemoveRoute(AirportNode origin, AirportNode dest) // 5%
    {
        if (origin.Destinations.Contains(dest)) // checks for dest route among the origin node
        {
            origin.RemoveDestination(dest);     // removes route from origin node
            return true;    // route found
        }
        else
        {
            return false;   // route not found
        }
    }

    public override string ToString() //ToString method overload to print out airport name, code, and list of deestinations. 5%
    {
        StringBuilder sb = new StringBuilder();

        // appends each node in the route map to the string builder
        foreach (AirportNode i in A)
        {
            // finds destinations from airport i
            sb.Append($"{i} \n");
        }
        return sb.ToString();
    }
}