using static System.Console;
class Program
{
    static void Main(string[] args)
    {
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

        AirportNode[] airports = new AirportNode[13]
        {
            YYC, YEG, YFC, YQX,
            YHZ, YQM, YUL, YOW,
            YQB, YYT, YYZ, YVR,
            YWG
        };

        RouteMap rm = new RouteMap();
        Random r = new Random();
        foreach (AirportNode a in airports)
        {
            rm.AddAirport(a);
        }

        while (rm.AddRoute(airports[r.Next(13)], airports[r.Next(13)]))
        {
            foreach (AirportNode a in airports)
            {
                if (rm.AddRoute(airports[r.Next(13)], airports[r.Next(13)]))
                {
                    for (int i = 0; i < r.Next(13); i++)
                    {
                        rm.AddRoute(airports[r.Next(13)], airports[r.Next(13)]);
                    }
                }
            }
        }

        WriteLine(rm);
    }


    void FastestRoute(AirportNode origin, AirportNode Destination)
    {
        Queue<AirportNode> frontQueue = new Queue<AirportNode>();
        List<AirportNode> discovered = new List<AirportNode>();

        frontQueue.Enqueue(origin);
        discovered.Add(origin);

        while (frontQueue.Peek() != null)
        {
            AirportNode current = frontQueue.Dequeue();

            foreach (AirportNode a in origin.Destinations)
            {
                if (!discovered.Contains(a))
                {
                    frontQueue.Enqueue(a);
                    discovered.Add(a);
                }
            }
        }
    }
}
