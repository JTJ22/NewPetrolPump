namespace NewPetrolPump.Interfaces
{
  /// <summary>
  /// Interface which vehicle inherit from, vehicles must implement the methods and fields
  /// </summary>
  internal interface IVehicles
  {
    public double CurrentAmountInTank { get; set; }
    public int TankSizeStore { get; set; }
    public FuelTypes TypeOfFuel { get; }
    public int TankSize();
    public FuelTypes FuelType();
    public double CurrentFuelInTank();
  }
}
