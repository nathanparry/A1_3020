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
        foreach (AirportNode an in A)
        {
            if (an.Name.Equals(name))
            {
                return true;
            }
        }
        return false;
    }
    public bool FindAirportCode(string code) //Method to find airport by code. 5%
    {
        foreach (AirportNode an in A)
        {
            if (an.Code.Equals(code))
            {
                return true;
            }
        }
        return false;
    }
    public bool AddAirport(AirportNode a) //Methodtoaddairportnode.Duplicatesnotallowed.5% public
    {
        foreach (AirportNode an in A)
        {
            if (a == an)
            {
                return false;
            }
        }
        A.Add(a);
        return true;
    }
    bool RemoveAirport(AirportNode a) //Method to remove airport node. Node must exist. 5% public bool
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
    void AddRoute(AirportNode origin, AirportNode dest) // 5%
    {
        origin.AddDestination(dest);
    }
    public bool RemoveRoute(AirportNode origin, AirportNode dest) // 5%
    {
        foreach (AirportNode an in A)
        {
            if (an == dest)
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
            sb.Append($"{i.Name} ({i.Code}) Destinations \n");
            sb.Append("_____________________________________ \n");
            foreach (AirportNode an in i.Destinations)
            {
                sb.Append($"{an.Name} ({an.Code})\n");
            }
        }
       return sb.ToString();
    }
}