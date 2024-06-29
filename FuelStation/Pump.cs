namespace NewPetrolPump.FuelStation
{
  internal class Pump
  {
    public IVehicles? CurrentVehicle { get; set; }
    public int PumpTime = 1;
    public bool CurrentlyOccupied { get; set; }
    private Timer? fuelTimer;

    /// <summary>
    /// Adds a vehicle to the pump, starts a timer which is based upon how much fuel is needed
    /// </summary>
    /// <param name="newVehicle">The vehicle assigned to this pump</param>
    public void AddToPump(IVehicles newVehicle)
    {
      CurrentlyOccupied = true;
      CurrentVehicle = newVehicle;
      StartTimer();
    }

    /// <summary>
    /// Starts a timer based upon fuel currently in the tank, timer runs until this is over
    /// Effectively filling the vehicle
    /// </summary>
    private void StartTimer()
    {
      if(CurrentVehicle != null)
      {
        int timeToFill = (int)(Convert.ToDouble(CurrentVehicle.TankSizeStore) - CurrentVehicle.CurrentAmountInTank) / PumpTime * 1000;
        fuelTimer = new Timer(Callback, null, timeToFill, timeToFill);
        CurrentlyOccupied = true;
      }
    }

    /// <summary>
    /// The callback of the timer, called when the timer elapses
    /// Increases the value of fuel and set the vehicle as full
    /// The timer is then stopped
    /// </summary>
    /// <param name="state">Has to be implemented to utilise the callback of the timer</param>
    private void Callback(object? state)
    {
      if(CurrentVehicle is not null)
      {
        IncrementFuelValue();
        CurrentVehicle.CurrentAmountInTank = CurrentVehicle.TankSizeStore;
        StopTimer();
      }
    }

    /// <summary>
    /// Stops the timer and disposes of it, also sets the pump back to it's default state so a new vehicle can be added
    /// </summary>
    private void StopTimer()
    {
      CurrentVehicle = null;
      fuelTimer?.Dispose();
      fuelTimer = null;
      CurrentlyOccupied = false;
    }

    /// <summary>
    /// Adds the used fuel and it's value to a singleton which tracks these values
    /// </summary>
    private void IncrementFuelValue()
    {
      double amountToAdd = CurrentVehicle.TankSizeStore - CurrentVehicle.CurrentAmountInTank;
      double fuelCost = CurrentVehicle.TypeOfFuel.FuelCost;
      double totalCost = Math.Round(CurrentVehicle.TypeOfFuel.FuelValue(fuelCost, amountToAdd), 2);
      Forecourt.FuelUsed[CurrentVehicle.TypeOfFuel.GetType().Name] += totalCost;
    }

  }
}
