namespace NewPetrolPump.Vehicles
{
  internal class Van : IVehicles
  {
    public double CurrentAmountInTank { get; set; }
    public FuelTypes TypeOfFuel { get; }
    Random randomGen = new Random();
    public Van()
    {
      CurrentAmountInTank = CurrentFuelInTank();
      TypeOfFuel = FuelType();
    }

    public int TankSize()
    {
      return 80;
    }
    public FuelTypes FuelType()
    {
      int fuelType = randomGen.Next(1, 4);
      return fuelType switch
      {
        1 => new Petrol(),
        2 => new Diesel(),
        3 => new LPG(),
        _ => new Diesel()
      };
    }

    public double CurrentFuelInTank()
    {
      return randomGen.Next(0, TankSize());
    }
  }
}

