namespace NewPetrolPump.Vehicles
{
  internal static class VehicleFactory
  {
    private static Random randomGen = new Random();
    public static IVehicles MakeVehicle()
    {
      int randomness = randomGen.Next(1, 4);
      return randomness switch
      {
        1 => new Car(),
        2 => new Van(),
        3 => new HGV(),
        _ => new Car()
      };
    }
  }
}
