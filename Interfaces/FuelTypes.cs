namespace NewPetrolPump.Interfaces
{
  /// <summary>
  /// A base class for the FuelTypes which allows fuels to utilise methods from this class
  /// As well as fields
  /// </summary>
  internal abstract class FuelTypes
  {
    public string FuelType { get; set; }
    public double FuelCost { get; set; }

    /// <summary>
    /// Method that returns the total filling value of a vehicle
    /// </summary>
    /// <param name="fuelCost">Cost of the fuel</param>
    /// <param name="totalFuel">Total fuel used</param>
    /// <returns>Value of the fuel taken</returns>
    public double FuelValue(double fuelCost, double totalFuel)
    {
      return totalFuel * FuelCost;
    }
  }
}
