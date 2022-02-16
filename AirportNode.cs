using System.Text;

class AirportNode
{
    public string Name { get; set; } //property for name field.
    public string Code { get; set; } //property for code field.
    public List<AirportNode> Destinations { get; set; } //property for list of destinations.
    public AirportNode(string name, string code) //constructor 5%
    {
        Name = name;
        Code = code;
        Destinations = new List<AirportNode>();
    }
    public void AddDestination(AirportNode destAirport) //method to add destination. 5%
    {
        if (!Destinations.Contains(destAirport) && destAirport != this) // checks if Destination list contains the destination airport
        {
            Destinations.Add(destAirport);  // destination is added to the list
        }
        else // destination already in list
        {
            // Do nothing
        }
    }
    public void RemoveDestination(AirportNode destAirport) //method to remove destination. 5%
    {
        if (Destinations.Contains(destAirport)) // checks if the airport node for removal is on the destinations list
        {
            Destinations.Remove(destAirport);   // removes the airport node from destinations list
        }
        else // destination not on list
        {
            // Do Nothing
        }
    }

    public override string ToString() //ToString method overload to print out airport name, code, and list of deestinations. 5%
    {
        StringBuilder sb = new StringBuilder();

        sb.Append($"{Name} :: {Code} \n");
        sb.Append("<<< Destinations >>>\n");
        foreach (AirportNode i in Destinations)
        {
            sb.Append($"({i.Code}) ");
        }
        sb.Append("\n");
        return sb.ToString();
    }
}
