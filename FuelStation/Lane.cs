namespace NewPetrolPump.FuelStation
{
  internal class Lane
  {
    public string LaneName { get; set; }
    public Dictionary<int, Pump> pumpsInLane;

    public Lane(string name)
    {
      LaneName = name;
      pumpsInLane = OccupyLane();
    }

    private Dictionary<int, Pump> OccupyLane()
    {
      Dictionary<int, Pump> lane = new Dictionary<int, Pump>();
      for (int i = 0; i < 4; i++)
      {
        lane.Add(i, new Pump());
      }
      return lane;
    }
    public bool AddToPumps(IVehicles newVehicle)
    {
      bool isBlocked = false;

      for (int i = 0; i < pumpsInLane.Count; i++)
      {
        Pump pump = pumpsInLane[i];

        if (!pump.CurrentlyOccupied)
        {
          bool anyLaterOccupied = false;

          for (int j = i + 1; j < pumpsInLane.Count; j++)
          {
            if (pumpsInLane[j].CurrentlyOccupied)
            {
              anyLaterOccupied = true;
              break;
            }
          }

          if (!anyLaterOccupied)
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
