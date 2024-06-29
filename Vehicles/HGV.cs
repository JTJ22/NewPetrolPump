namespace NewPetrolPump.Vehicles
{
  internal class HGV : IVehicles
  {
    public double CurrentAmountInTank { get; set; }
    public FuelTypes TypeOfFuel { get; }
    private Random randomGen = new Random();
    public int TankSizeStore { get; set; }
    public HGV()
    {
      CurrentAmountInTank = CurrentFuelInTank();
      TypeOfFuel = FuelType();
    }

    public int TankSize()
    {
      TankSizeStore = randomGen.Next(120, 165);
      return TankSizeStore;
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

