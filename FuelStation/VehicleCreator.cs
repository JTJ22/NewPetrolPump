using NewPetrolPump.Vehicles;

namespace NewPetrolPump.FuelStation
{
  internal class VehicleCreator
  {
    private Random Random = new Random();
    private static Timer Timer;
    public Forecourt Forecourt;

    /// <summary>
    /// Creates a new forecourt when VehicleCreator is called
    /// </summary>
    public VehicleCreator()
    {
      Forecourt = new Forecourt();
    }

    /// <summary>
    /// Creates a vehicle based upon a random time selected
    /// Attempts to adds this vehicle to the forecourts queue
    /// </summary>
    public void CreateVehicles()
    {
      int time = Random.Next(2400, 3500);
      Timer = new Timer(AddToVehiclesQueue, null, time, time);
      Console.ReadKey();
    }

    /// <summary>
    /// Callback for the timer which creats a new vehicle, this is added to the forecourt and the timer is reset
    /// </summary>
    /// <param name="state">Implemented to meet callback requirements of Timer</param>
    private void AddToVehiclesQueue(object? state)
    {
      int newInterval = Random.Next(2400, 3500);
      IVehicles newVehicle = VehicleFactory.MakeVehicle();
      Forecourt.AddToQueue(newVehicle);
      Timer.Change(newInterval, newInterval);
    }
  }
}
