namespace NewPetrolPump.Fuels
{
  /// <summary>
  /// A class that uses the base class FuelTypes
  /// LPG has it's own set price and can utilise methods from FuelTypes
  /// </summary>
  internal class LPG : FuelTypes
  {
    /// <summary>
    /// Constructor for LPG, setting it's price and name upon creation
    /// </summary>
    public LPG()
    {
      FuelType = "LPG";
      FuelCost = 1.20;
    }
  }
}
