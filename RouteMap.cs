using System.Text;
class RouteMap
{
    private List<AirportNode> A; //List of airport nodes.
    public RouteMap() //RouteMap constructor. 5%
    {
        A = new List<AirportNode>();
    }
    public bool FindAirport(string name) //Method to find airport by name. 5%
    {
        foreach (AirportNode a in A)
        {
            if (a.Name.Equals(name))
            {
                return true;
            }
        }
        return false;
    }
    public bool FindAirportCode(string code) //Method to find airport by code. 5%
    {
        foreach (AirportNode a in A)
        {
            if (a.Code.Equals(code))
            {
                return true;
            }
        }
        return false;
    }
    public bool AddAirport(AirportNode a) //Method to add airportnode. Duplicates not allowed. 5%
    {
        if (!FindAirport(a.Name) && !FindAirportCode(a.Code))
        {
            A.Add(a);
            return true;
        }
        else
        {
            return false;
        }
    }

    public bool RemoveAirport(AirportNode a) //Method to remove airport node. Node must exist. 5%
    {
        foreach (AirportNode an in A)
        {
            if (a == an)
            {
                A.Remove(a);
                return true;
            }
        }
        return false;
    }

    public bool AddRoute(AirportNode origin, AirportNode dest) // 5%
    {
        if (origin.Destinations.Contains(dest))
        {
            return false;
        }
        else
        {
            origin.AddDestination(dest);
            return true;
        }

    }
    public bool RemoveRoute(AirportNode origin, AirportNode dest) // 5%
    {
        foreach (AirportNode a in A)
        {
            if (a == dest)
            {
                origin.RemoveDestination(dest);
                return true;
            }
        }
        return false;
    }
    public override string ToString() //ToString method overload to print out airport name, code, and list of deestinations. 5%
    {
        StringBuilder sb = new StringBuilder();

        foreach (AirportNode i in A)
        {
            // finds destinations from airport i
            sb.Append($"{i} \n");
        }
        return sb.ToString();
    }
}