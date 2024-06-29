namespace NewPetrolPump.Interfaces
{
  internal interface IVehicles
  {
    public double CurrentAmountInTank { get; set; }
    FuelTypes TypeOfFuel { get; }
    public int TankSize();
    public FuelTypes FuelType();
    public double CurrentFuelInTank();
  }
}
