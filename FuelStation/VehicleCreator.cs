using NewPetrolPump.Vehicles;

namespace NewPetrolPump.FuelStation
{
  internal class VehicleCreator
  {
    Random Random = new Random();
    private static Timer Timer;
    public Forecourt Forecourt;

    public VehicleCreator()
    {
      Forecourt = new Forecourt();
    }
    public void CreateVehicles()
    {
      int time = Random.Next(2400, 3500);
      Timer = new Timer(AddToVehiclesQueue, null, time, time);
      Console.ReadKey();
    }

    private void AddToVehiclesQueue(object? state)
    {
      int newInterval = Random.Next(2400, 3500);
      IVehicles newVehicle = VehicleFactory.MakeVehicle();
      Forecourt.AddToQueue(newVehicle);
      Timer.Change(newInterval, newInterval);
    }
  }
}
