namespace NewPetrolPump.Vehicles
{
  internal class HGV : IVehicles
  {
    public double CurrentAmountInTank { get; set; }
    public FuelTypes TypeOfFuel { get; }
    Random randomGen = new Random();
    public HGV()
    {
      CurrentAmountInTank = CurrentFuelInTank();
      TypeOfFuel = FuelType();
    }

    public int TankSize()
    {
      return 150;
    }
    public FuelTypes FuelType()
    {
      int fuelType = randomGen.Next(1, 3);
      return fuelType switch
      {
        1 => new LPG(),
        2 => new Diesel(),
        _ => new Diesel()
      };
    }

    public double CurrentFuelInTank()
    {
      return randomGen.Next(0, TankSize());
    }
  }
}

