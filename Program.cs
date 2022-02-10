using static AirportNode;
using static RouteMap;
using static System.Console;
AirportNode yyz = new AirportNode("Toronto Pearson International Airport", "YYZ");
AirportNode yul = new AirportNode("Montréal–Trudeau International Airport", "YUL");

RouteMap rm = new RouteMap();
yyz.AddDestination(yul);
yyz.AddDestination(yul);

yul.AddDestination(yyz);
yul.AddDestination(yyz);
rm.AddAirport(yyz);

WriteLine($"{yyz}");
WriteLine($"{yul}");
