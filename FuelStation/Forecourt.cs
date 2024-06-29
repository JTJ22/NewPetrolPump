namespace NewPetrolPump.FuelStation
{
  /// <summary>
  /// Represents the forecourt of the fuel station
  /// The forecourt stores all the lanes currently in use
  /// The forecourt is responsible for adding vehicles to open pumps
  /// Vehicles which have been waiting more than 10 seconds will leave the queue
  /// </summary>
  internal class Forecourt
  {
    public Dictionary<int, Lane> lanes;
    private List<(IVehicles vehicle, Timer vehicleTimer, DateTime timeAdded)> VehicleQueue = new List<(IVehicles vehicles, Timer vehicleTimer, DateTime timeAdded)>();
    private const int MaxWaitTime = 10000;
    public static Dictionary<string, double> FuelUsed = new Dictionary<string, double>();

    /// <summary>
    /// Constructor that occupies all the lanes with pumps upon creation
    /// A list containing fuels is also created so amounts expended can be recorded
    /// </summary>
    public Forecourt()
    {
      lanes = OccupyForecourt();
      FuelUsed = FuelsUsed();
    }

    /// <summary>
    /// Creates lanes which are occupied by pumps, returns a dictionary containing the lanes
    /// </summary>
    /// <returns>The lanes which occupy the forecourt</returns>
    private Dictionary<int, Lane> OccupyForecourt()
    {
      Dictionary<int, Lane> lane = new Dictionary<int, Lane>();
      for(int i = 0; i < 4; i++)
      {
        lane.Add(i, new Lane($"Lane {i.ToString()}"));
      }
      return lane;
    }

    /// <summary>
    /// Creates a dictionary of every fuel used, this is to track total expended and the value
    /// </summary>
    /// <returns>A dictionary of all the fuel types being used</returns>
    private Dictionary<string, double> FuelsUsed()
    {
      Dictionary<string, double> totals = new Dictionary<string, double>()
            {
                {"Petrol", 0 },
                {"Diesel", 0 },
                {"LPG", 0 }
            };
      return totals;
    }

    /// <summary>
    /// When a new vehicle created the forecourt will attempt to add this to the queue
    /// A timer checks every 200 m/s to see if a pump is free
    /// The vehicle is added to the queue
    /// </summary>
    /// <param name="newVehicle">The vehicle to be added to the queue</param>
    public void AddToQueue(IVehicles newVehicle)
    {
      Timer vehicleTimer = new Timer(CheckPumpFree, newVehicle, 200, 200);
      VehicleQueue.Add((newVehicle, vehicleTimer, DateTime.Now));
    }

    /// <summary>
    /// Checks if a pump is available in the current lanes
    /// If a vehicle cannot be added the method exits
    /// If the time elapsed is greater than 10 seconds the vehicle is ejected from the queue
    /// </summary>
    /// <param name="vehicle">The vehicle that is being added to a pump</param>
    private void CheckPumpFree(object? vehicle)
    {
      IVehicles newVehicle = (IVehicles)vehicle!;
      (IVehicles vehicle, Timer vehicleTimer, DateTime timeAdded) vehicleEntry = VehicleQueue.FirstOrDefault(v => v.vehicle == vehicle);
      foreach(Lane lane in lanes.Values)
      {
        if(lane.AddToPumps(newVehicle))
        {
          vehicleEntry.vehicleTimer.Dispose();
          VehicleQueue.Remove(vehicleEntry);
          break;
        }
      }

      if((DateTime.Now - vehicleEntry.timeAdded).TotalMilliseconds > MaxWaitTime)
      {
        vehicleEntry.vehicleTimer.Dispose();
        if(VehicleQueue.Count > 0)
        {
          VehicleQueue.Remove(vehicleEntry);
        }
      }
    }

  }
}
