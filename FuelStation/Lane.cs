namespace NewPetrolPump.FuelStation
{
  /// <summary>
  /// A class for a lane, a lane contains pumps which fill the vehicles
  /// The lane is repsonsible for checking which pumps are free or blocked
  /// </summary>
  internal class Lane
  {
    public string LaneName { get; set; }
    public Dictionary<int, Pump> pumpsInLane;

    /// <summary>
    /// Constructor for the Lane, has a name for identification
    /// Also occupies the lane with pumps
    /// </summary>
    /// <param name="name">The lane name created by the forecourt</param>
    public Lane(string name)
    {
      LaneName = name;
      pumpsInLane = OccupyLane();
    }

    /// <summary>
    /// Creates pumps which are added to a dictionary
    /// Allows the lane to uniquely identify pumps in the lane
    /// </summary>
    /// <returns>A dictionary containing the pumps</returns>
    private Dictionary<int, Pump> OccupyLane()
    {
      Dictionary<int, Pump> lane = new Dictionary<int, Pump>();
      for(int i = 0; i < 4; i++)
      {
        lane.Add(i, new Pump());
      }
      return lane;
    }

    /// <summary>
    /// Checks if a pump is free
    /// If so the pumps before the current pump are check
    /// If those pumps are ocupied the current pump is blocked and returns false
    /// </summary>
    /// <param name="newVehicle">The vehicle which should be added to the pump</param>
    /// <returns>Returns true if a vehicle can be added, false if it cannot be added</returns>
    public bool AddToPumps(IVehicles newVehicle)
    {
      bool isBlocked = false;

      for(int i = 0; i < pumpsInLane.Count; i++)
      {
        Pump pump = pumpsInLane[i];

        if(!pump.CurrentlyOccupied)
        {
          bool anyLaterOccupied = false;

          for(int j = i + 1; j < pumpsInLane.Count; j++)
          {
            if(pumpsInLane[j].CurrentlyOccupied)
            {
              anyLaterOccupied = true;
              break;
            }
          }

          if(!anyLaterOccupied)
          {
            isBlocked = true;
            pump.AddToPump(newVehicle);
            break;
          }
        }
      }
      return isBlocked;
    }
  }
}
