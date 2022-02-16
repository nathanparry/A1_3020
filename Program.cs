using System;
class Program
{
    /*
        Names:
        Nathan Parry - 0638178
        Lucas D'Silva -
        Dylan Haggard - 
    */

    // Main starts here 
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

        // create route map
        RouteMap rm = new RouteMap();

        //add each airport node to the route map
        foreach (AirportNode a in airports)
        {
            rm.AddAirport(a);
        }

        // try to add another YYZ
        rm.AddAirport(YYZ);

        // creates the graph/routes
        rm.AddRoute(YYT, YQM);
        rm.AddRoute(YYT, YOW);
        rm.AddRoute(YYT, YUL);
        rm.AddRoute(YYT, YQB);
        rm.AddRoute(YYT, YQM);
        rm.AddRoute(YYT, YQX);
        rm.AddRoute(YHZ, YYT);
        // rm.AddRoute(YHZ, YVR); isolates YVR from the graph
        rm.AddRoute(YHZ, YWG);
        rm.AddRoute(YFC, YQM);
        rm.AddRoute(YFC, YYT);
        rm.AddRoute(YQM, YYZ);
        rm.AddRoute(YEG, YQM);
        rm.AddRoute(YYC, YEG);
        rm.AddRoute(YYZ, YOW);
        rm.AddRoute(YOW, YEG);
        rm.AddRoute(YOW, YUL);
        rm.AddRoute(YQX, YYZ);
        rm.AddRoute(YQX, YQB);
        // end of graph

        // displays route map
        Console.WriteLine(rm);


        // Test cases
        // FastestRoute(YVR, YYZ); // test route for isolated node
        // FastestRoute(YYZ, YYT); // no pathing to destination connected though
        // FastestRoute(YQX, YYZ); // DIRECT FLIGHT
        // FastestRoute(YOW, YOW); // origin = Destination
    }

    // Fastest route possibly using breadth first search
    static void FastestRoute(AirportNode origin, AirportNode Destination)
    {
        // Modified this for finding fastestroute I think
        // BFS actual algorithm
        Queue<AirportNode> Q = new Queue<AirportNode>(); // create queue
        Q.Enqueue(origin);  // queue up origin
        List<AirportNode> visited = new List<AirportNode>(); // visited list
        visited.Add(origin);    // add origin to visited list
        AirportNode current = origin; // set current node to origin
        int cnt = 1; // path counter
        // checks if queue is empty by peeking, if origin contains destination in its list, if origin=Destination
        while (Q.TryPeek(out current) && !current.Destinations.Contains(Destination) && !current.Equals(Destination))
        {
            current = Q.Dequeue(); // dequeues node
            foreach (AirportNode n in current.Destinations) // checks the current nodes destinations list
            {
                if (!visited.Contains(n) && !n.Destinations.Contains(Destination)) // adds node to queue if not in visited list or in nodes destinations list
                {
                    Q.Enqueue(n);   // queues node for next check
                }
                else if (n.Destinations.Contains(Destination)) // Destination is in the node's destinations list
                {
                    cnt++; // increment path counter
                    // add relevant airport nodes to visited for route to Destination
                    if (!visited.Contains(current)) // makes sure it's not already in the list
                    {
                        visited.Add(current);   // adds the node to the visited list for the route
                    }
                    visited.Add(n); // adds second last node to visited list for the route
                    visited.Add(Destination);   // adds final destination

                    //outputs the route
                    Console.WriteLine("\nPath of {0} From {1} To {2}\nRoute:", cnt, origin.Code, Destination.Code); // the origin and destination are outputted

                    // output the list of visited nodes which is the route to be taken
                    foreach (AirportNode a in visited)
                    {
                        if (a == origin)
                        {
                            Console.WriteLine("Leaving... {0}", origin.Name);   // origin
                        }
                        else if (a == Destination)
                        {
                            Console.WriteLine("Arriving... {0}", Destination.Name); // Destination
                        }
                        else
                        {
                            Console.WriteLine("=> {0}", a.Name);    // connecting flights
                        }
                    }
                    return; // found Destination
                }
            }
            if (!visited.Contains(current)) // as long as visited does not contain current node add it to visited
            {
                visited.Add(current);
            }
            cnt++; // increment path counter
        }
        //end of BFS

        // Base Cases of direct flight or no route and orgin=Destination
        if ((visited.Contains(Destination) || origin.Destinations.Contains(Destination)) && !origin.Equals(Destination))
        {
            // fastest case direct flight
            Console.WriteLine("\nPath of {0} From {1} To {2} \nRoute:", cnt, origin.Code, Destination.Code);
            Console.WriteLine("Leaving... {0}", origin.Name);
            Console.WriteLine("Arriving... {0}", Destination.Name);
        }
        else if (origin.Equals(Destination))    // origin = Destination
        {
            Console.WriteLine("\nCurrently at Destination! You are here: \n{0}\n", origin.Name); // already at  destination
        }
        else    // no routing
        {
            Console.WriteLine("\nNo possible route! From {0} => {1}\n", origin.Name, Destination.Name); // no route

        }
    }

}