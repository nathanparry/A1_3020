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
        if (!Destinations.Contains(destAirport) && destAirport != this)
        {
            Destinations.Add(destAirport);
        }
        else
        {

        }
    }
    public void RemoveDestination(AirportNode destAirport) //method to remove destination. 5%
    {
        foreach (AirportNode an in Destinations)
        {
            if (destAirport == an)
            {
                Destinations.Remove(destAirport);
                break;
            }
        }
    }

    public override string ToString() //ToString method overload to print out airport name, code, and list of deestinations. 5%
    {
        StringBuilder sb = new StringBuilder();

        sb.Append($"{Name} :: {Code} \n");
        sb.Append("<<< Destinations >>>\n");
        foreach (AirportNode i in Destinations)
        {
            sb.Append($"{i.Name} ({i.Code})\n");
        }
        return sb.ToString();
    }
}
