namespace NewPetrolPump.FuelStation
{
  internal class Pump
  {
    public IVehicles? CurrentVehicle { get; set; }
    public int PumpTime = 1;
    public bool CurrentlyOccupied { get; set; }
    private Timer? fuelTimer;

    public void AddToPump(IVehicles newVehicle)
    {
      CurrentlyOccupied = true;
      CurrentVehicle = newVehicle;
      StartTimer();
    }
    private void StartTimer()
    {
      if(CurrentVehicle != null)
      {
        int timeToFill = (int)(Convert.ToDouble(CurrentVehicle.TankSize()) - CurrentVehicle.CurrentAmountInTank) / PumpTime * 1000;
        fuelTimer = new Timer(Callback, null, timeToFill, timeToFill);
        CurrentlyOccupied = true;
      }
    }
    private void Callback(object? state)
    {
      if(CurrentVehicle is not null)
      {
        IncrementFuelValue();
        CurrentVehicle.CurrentAmountInTank = CurrentVehicle.TankSize();
        StopTimer();
      }
    }
    private void StopTimer()
    {
      CurrentVehicle = null;
      fuelTimer?.Dispose();
      fuelTimer = null;
      CurrentlyOccupied = false;
    }

    private void IncrementFuelValue()
    {
      double amountToAdd = CurrentVehicle.TankSize() - CurrentVehicle.CurrentAmountInTank;
      double fuelCost = CurrentVehicle.TypeOfFuel.FuelCost;
      double totalCost = Math.Round(CurrentVehicle.TypeOfFuel.FuelValue(fuelCost, amountToAdd), 2);
      Forecourt.FuelUsed[CurrentVehicle.TypeOfFuel.GetType().Name] += totalCost;
    }

  }
}
