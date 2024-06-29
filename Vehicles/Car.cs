namespace NewPetrolPump.Vehicles
{
  internal class Car : IVehicles
  {
    public double CurrentAmountInTank { get; set; }
    public FuelTypes TypeOfFuel { get; }
    Random randomGen = new Random();
    public Car()
    {
      CurrentAmountInTank = CurrentFuelInTank();
      TypeOfFuel = FuelType();
    }

    public int TankSize()
    {
      return 50;
    }
    public FuelTypes FuelType()
    {
      int fuelType = randomGen.Next(1, 3);
      return fuelType switch
      {
        1 => new Petrol(),
        2 => new Diesel(),
        _ => new Petrol()
      };
    }

    public double CurrentFuelInTank()
    {
      return randomGen.Next(0, TankSize());
    }
  }
}
