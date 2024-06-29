namespace NewPetrolPump.Fuels
{
  /// <summary>
  /// A class that uses the base class FuelTypes
  /// Petrol has it's own set price and can utilise methods from FuelTypes
  /// </summary>
  internal class Petrol : FuelTypes
  {
    /// <summary>
    /// Constructor for Petrol, setting it's price and name upon creation
    /// </summary>
    public Petrol()
    {
      FuelType = "Petrol";
      FuelCost = 1.39;
    }
  }
}
