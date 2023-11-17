using LogisticsApp.Application.Abstractions;
using LogisticsApp.Application.Services.Interfaces;
using LogisticsApp.Domain.Entities;

namespace LogisticsApp.Application.Services.Concretes
{
    public class PositionService : IPositionService
    {
        private readonly IRepository<Position>? _positionRepository;
        private readonly IRepository<Truck>? _truckRepository;

        public PositionService(IRepository<Position>? positionRepository, IRepository<Truck>? truckRepository)
        {
            _positionRepository = positionRepository;
            _truckRepository = truckRepository;
        }

        public async Task<BaseResponse> GetPositions()
        {
           //Get results using the generic repository pattern
            var positions = await _positionRepository.GetAllAsync();
            if(positions == null) return new BaseResponse { Status = false, Message = "No records found" };

            return new BaseResponse { Status = true, Message = "Records retrieved successfully", Data = positions };

        }

        public async Task<BaseResponse> GetPosition(long assetId, long driverId)
        {
            var trucks = await _truckRepository.GetAllAsync();
            var truckList = trucks.ToList();

            var positions = await _positionRepository.GetAllAsync();
            var positionList = positions.ToList();

            //Join both Truck and Position tables to get all required details for the search
            var query = truckList.Join(positionList,
                t => t.AssetId,
                p => p.AssetId,
                (t, p) => new
                {
                    AssetID = t.AssetId,
                    DriverID = p.DriverId,
                    Address = t.CurrentAddress,
                    Longitude = t.Longitude,
                    Latitude = t.Latitude,
                    TimeStamp = p.TimeStamp
                }).ToList();

            if (query == null) return new BaseResponse { Status = false, Message = "No record found" };

            //Filter join to get specific driver and truck position
            var result = query.FirstOrDefault(x => x.AssetID == assetId && x.DriverID == driverId);

            return new BaseResponse { Status = true, Message = "Records retrieved successfully", Data = result };
        }

        public async Task<BaseResponse> GetDistanceInKm(long assetId, long driverId, double staticLattitude, double staticLongitutude)
        {
           //Get specific truck/driver position using assetId and driverId
            var truckPosition = await _positionRepository.GetByPositionByIdsAsync(assetId, driverId);
            if(truckPosition == null) return new BaseResponse { Status = false, Message = "No records found with such parameters" };

            // Use Haversine formular to calculate the distance between where the truck/driver is and static coordinate of interest
            var distance = await HaversineFormula((double)truckPosition.Latitude, (double)truckPosition.Longitude, staticLattitude, staticLongitutude);

            return new BaseResponse { Status = true, Message = "Distance in km retrieved succesfully", Data = distance };
        }


        private async Task<double> HaversineFormula(double latt1, double long1, double latt2, double long2)
        {
            const double EarthRadiusInKilometers = 6371; 

            //Convert from degrees to radian measure
            var latt1InRadians = latt1 * (Math.PI / 180);
            var long1InRadians = long1 * (Math.PI / 180);
            var latt2InRadians = latt2 * (Math.PI / 180);
            var long2InRadians = long2 * (Math.PI / 180);

            // Haversine formula
            double dlat = latt2InRadians - latt1InRadians;
            double dlon = long2InRadians - long1InRadians;
            double a = Math.Sin(dlat / 2) * Math.Sin(dlat / 2) +
                       Math.Cos(latt1InRadians) * Math.Cos(latt2InRadians) *
                       Math.Sin(dlon / 2) * Math.Sin(dlon / 2);
            double c = 2 * Math.Atan2(Math.Sqrt(a), Math.Sqrt(1 - a));

            // Distance in kilometers
            double distance = EarthRadiusInKilometers * c;

            return distance;
        }
    }
}
