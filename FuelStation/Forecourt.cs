namespace NewPetrolPump.FuelStation
{
  internal class Forecourt
  {
    public Dictionary<int, Lane> lanes;
    List<(IVehicles vehicle, Timer vehicleTimer, DateTime timeAdded)> VehicleQueue = new List<(IVehicles vehicles, Timer vehicleTimer, DateTime timeAdded)>();
    private const int MaxWaitTime = 10000;
    public static Dictionary<string, double> FuelUsed = new Dictionary<string, double>();
    public Forecourt()
    {
      lanes = OccupyForecourt();
      FuelUsed = FuelsUsed();
    }

    private Dictionary<int, Lane> OccupyForecourt()
    {
      Dictionary<int, Lane> lane = new Dictionary<int, Lane>();
      for (int i = 0; i < 4; i++)
      {
        lane.Add(i, new Lane($"Lane {i.ToString()}"));
      }
      return lane;
    }

    private Dictionary<string, double> FuelsUsed()
    {
      Dictionary<string, double> totals = new Dictionary<string, double>()
            {
                {"Petrol", 0 },
                {"Diesel", 0 },
                {"LPG",0}
            };
      return totals;
    }

    public void AddToQueue(IVehicles newVehicle)
    {
      Timer vehicleTimer = new Timer(CheckPumpFree, newVehicle, 200, 200);
      VehicleQueue.Add((newVehicle, vehicleTimer, DateTime.Now));
    }

    private void CheckPumpFree(object? vehicle)
    {
      IVehicles newVehicle = (IVehicles)vehicle!;
      var vehicleEntry = VehicleQueue.FirstOrDefault(v => v.vehicle == vehicle);
      foreach (Lane lane in lanes.Values)
      {
        if (lane.AddToPumps(newVehicle))
        {
          vehicleEntry.vehicleTimer.Dispose();
          VehicleQueue.Remove(vehicleEntry);
          break;
        }
      }

      if ((DateTime.Now - vehicleEntry.timeAdded).TotalMilliseconds > MaxWaitTime)
      {
        vehicleEntry.vehicleTimer.Dispose();
        if (VehicleQueue.Count > 0)
        {
          VehicleQueue.Remove(vehicleEntry);
        }
      }
    }

  }
}
