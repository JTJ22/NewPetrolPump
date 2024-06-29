using NewPetrolPump.FuelStation;

namespace NewPetrolPump
{
  internal class Program
  {
    static void Main(string[] args)
    {
      VehicleCreator creator = new VehicleCreator();
      Timer displayTimer = new Timer(UpdateDisplay, creator, 0, 1000);
      creator.CreateVehicles();
    }

    private static void UpdateDisplay(object? state)
    {
      if(state is VehicleCreator fuelStation)
      {
        Console.Clear();

        foreach(Lane lane in fuelStation.Forecourt.lanes.Values)
        {
          Console.WriteLine($"Lane {lane.LaneName}:");
          int i = 0;
          foreach(Pump pump in lane.pumpsInLane.Values)
          {
            string status = pump.CurrentlyOccupied ? $"Occupied by {pump.CurrentVehicle?.GetType().Name}" : "Available";
            Console.WriteLine($"  Pump {i++}: {status}");
          }
        }
        Console.WriteLine("\n");

        foreach(KeyValuePair<string, double> type in Forecourt.FuelUsed)
        {
          Console.WriteLine($"{type.Key}: £{Math.Round(type.Value),2}");
        }
      }
    }
  }
}
