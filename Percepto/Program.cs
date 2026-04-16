using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

class DroneStatus
{
    public string DroneId { get; set; }
    public double Latitude { get; set; }
    public double Longitude { get; set; }
    public int BatteryPercentage { get; set; }
    public DateTime LastUpdated { get; set; }
}

class DroneMonitorService
{
    private readonly ConcurrentDictionary<string, DroneStatus> _latestDroneStatuses = new();
    private readonly List<DroneStatus> _aggregatedDroneStatuses = new();
    private readonly Timer _aggregationTimer;
    private readonly object _lock = new();

    public DroneMonitorService()
    {
        // Start aggregation every minute
        _aggregationTimer = new Timer(AggregateData, null, TimeSpan.Zero, TimeSpan.FromMinutes(1));
    }

    // Method that gets called every 200ms for each drone
    public void ReceiveDroneUpdate(string droneId, double latitude, double longitude, int battery)
    {
        var droneStatus = new DroneStatus
        {
            DroneId = droneId,
            Latitude = latitude,
            Longitude = longitude,
            BatteryPercentage = battery,
            LastUpdated = DateTime.UtcNow
        };

        _latestDroneStatuses[droneId] = droneStatus; // Updates the latest status for each drone
    }

    // Called every minute to aggregate the latest statuses
    private void AggregateData(object? state)
    {
        lock (_lock)
        {
            _aggregatedDroneStatuses.Clear();
            _aggregatedDroneStatuses.AddRange(_latestDroneStatuses.Values);
        }

        Console.WriteLine($"Aggregated {_aggregatedDroneStatuses.Count} drone updates at {DateTime.UtcNow}");
    }

    // Method to retrieve the latest aggregated statuses
    public List<DroneStatus> GetLatestStatuses()
    {
        lock (_lock)
        {
            return _aggregatedDroneStatuses.ToList();
        }
    }
}

class Program
{
    static async Task Main()
    {
        var droneService = new DroneMonitorService();

        // Simulate drones sending data every 200ms
        var random = new Random();
        
        _ = Task.Run(async () =>
        {
            while (true)
            {
                string droneId = "Drone_" + random.Next(1, 10);
                double lat = random.NextDouble() * 90;
                double lon = random.NextDouble() * 180;
                int battery = random.Next(1, 100);

                droneService.ReceiveDroneUpdate(droneId, lat, lon, battery);
                await Task.Delay(200); // Simulating real-time updates
            }
        });

        // Periodically retrieve the latest aggregated statuses
        while (true)
        {
            await Task.Delay(TimeSpan.FromMinutes(1));
            var statuses = droneService.GetLatestStatuses();
            Console.WriteLine($"Latest Drone Updates ({statuses.Count} drones):");
            foreach (var status in statuses)
            {
                Console.WriteLine($"{status.DroneId} - {status.Latitude}, {status.Longitude} - Battery: {status.BatteryPercentage}%");
            }
        }
    }
}
