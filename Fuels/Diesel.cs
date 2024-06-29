namespace NewPetrolPump.Fuels
{
  /// <summary>
  /// A class that uses the base class FuelTypes
  /// Diesel has it's own set price and can utilise methods from FuelTypes
  /// </summary>
  internal class Diesel : FuelTypes
  {
    /// <summary>
    /// Constructor for Diesel, setting it's price and name upon creation
    /// </summary>
    public Diesel()
    {
      FuelType = "Diesel";
      FuelCost = 1.45;
    }
  }
}
