using static AirportNode;
using static RouteMap;

AirportNode yyz = new AirportNode("Toronto Pearson International Airport", "YYZ");
AirportNode yul = new AirportNode("Montréal–Trudeau International Airport", "YUL");

yyz.AddDestination(yul);

Console.WriteLine($"{yyz}");
