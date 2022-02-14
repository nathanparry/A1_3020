using static System.Console;
class Program
{
    /*
        Names:
        Nathan Parry - 0638178
    */

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

    // SHOULD BE FINISHED NEEDS IMEDIATE TESTING
    static void FastestRoute(AirportNode origin, AirportNode Destination)
    {
        // Modified this for finding fastestroute I think
        // BFS actual algorithm
        Queue<AirportNode> Q = new Queue<AirportNode>();
        Q.Enqueue(origin);
        List<AirportNode> visited = new List<AirportNode>();
        visited.Add(origin);
        AirportNode current = origin;
        int cnt = 1;
        while (Q.TryPeek(out current) && !current.Destinations.Contains(Destination))
        {
            current = Q.Dequeue();
            foreach (AirportNode n in current.Destinations)
            {
                if (!visited.Contains(n) && !n.Destinations.Contains(Destination)) // destination not found add airport nodes to queue
                {
                    Q.Enqueue(n);
                }
                else if (n.Destinations.Contains(Destination)) // destination is found
                {
                    cnt++;
                    // add relevant airport nodes to visited for route to take
                    if(!visited.Contains(current)){
                        visited.Add(current);
                    }
                    visited.Add(n);
                    visited.Add(Destination);

                    //outputs for the route
                    WriteLine("\nPath of {0} From {1} To {2}\nRoute:", cnt, origin.Code, Destination.Code);
                    foreach (AirportNode a in visited)
                    {
                        if (a == origin)
                        {
                            WriteLine("Leaving... {0}", origin.Name);
                        }
                        else if (a == Destination)
                        {
                            WriteLine("Arriving... {0}", Destination.Name);
                        }
                        else
                        {
                            WriteLine("To {0}", a.Name);
                        }
                    }
                    return;
                }
            }
            if (!visited.Contains(current)) // as long as visited does not contain current airport node add it to visited
            {
                visited.Add(current);
            }
            cnt++;
        }
        //end of BFS

        // Base Cases of direct flight or no route
        if (visited.Contains(Destination) || origin.Destinations.Contains(Destination))
        {
            // fastest case direct flight
            WriteLine("\nPath of {0} From {1} To {2} \nRoute:", cnt, origin.Code, Destination.Code);
            WriteLine("Leaving... {0}", origin.Name);
            WriteLine("Arriving... {0}", Destination.Name);
        }
        else 
        {
            // no route
            WriteLine("\nNo possible route! From {0} To {1}", origin.Name, Destination.Name);
        }
    }

}
