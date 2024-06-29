namespace NewPetrolPump.Interfaces
{
  internal abstract class FuelTypes
  {
    public string FuelType { get; set; }
    public double FuelCost { get; set; }
    public double FuelValue(double fuelCost, double totalFuel)
    {
      return totalFuel * FuelCost;
    }
  }
}
