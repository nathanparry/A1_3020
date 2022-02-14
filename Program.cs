using static System.Console;
class Program
{
    // Main start here 
    static void Main(string[] args)
    {
        // Airport Nodes
        AirportNode YYC = new AirportNode("Calgary International Airport", "YYC");
        AirportNode YEG = new AirportNode("Edmonton International Airport", "YEG");
        AirportNode YFC = new AirportNode("Fredericton International Airport", "YFC");
        AirportNode YQX = new AirportNode("Grander International Airport", "YQX");
        AirportNode YHZ = new AirportNode("Halifax Stanfield International Airport", "YHZ");
        AirportNode YQM = new AirportNode("Greater Moncton Romeo LeBlanc International Airport", "YQM");
        AirportNode YUL = new AirportNode("Montréal–Trudeau International Airport", "YUL");
        AirportNode YOW = new AirportNode("Ottawa Macdonald-Cartier International Airport", "YOW");
        AirportNode YQB = new AirportNode("Quebec/Jean Lesage International Airport", "YQB");
        AirportNode YYT = new AirportNode("St. John's International Airport", "YYT");
        AirportNode YYZ = new AirportNode("Toronto Pearson International Airport", "YYZ");
        AirportNode YVR = new AirportNode("Vancouver International Airport", "YVR");
        AirportNode YWG = new AirportNode("Winnepeg International Airport", "YWG");

        // Putem in array
        AirportNode[] airports = new AirportNode[13]
        {
            YYC, YEG, YFC, YQX,
            YHZ, YQM, YUL, YOW,
            YQB, YYT, YYZ, YVR,
            YWG
        };

        RouteMap rm = new RouteMap();

        Random r = new Random();

        //add each airport node to the routemap
        foreach (AirportNode a in airports)
        {
            rm.AddAirport(a);
        }


    }

    // Still breadth first search W.I.P
    static void FastestRoute(AirportNode origin, AirportNode Destination)
    {   
        // BSF actual algorithm
        Queue<AirportNode> Q = new Queue<AirportNode>();
        Q.Enqueue(origin);
        List<AirportNode> visited = new List<AirportNode>();
        visited.Add(origin);
        AirportNode current = origin;
        while(Q.TryPeek(out current)){
            current = Q.Dequeue();
            foreach(AirportNode n in current.Destinations) {
                if (!visited.Contains(n)) {
                    Q.Enqueue(n);
                    visited.Add(n);
                }
            }
        }
        //end of algorithm

    }
}
