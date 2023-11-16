using LogisticsApp.Application.Abstractions;
using LogisticsApp.Application.Services.Interfaces;
using LogisticsApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogisticsApp.Application.Services.Concretes
{
    public class PositionService : IPositionService
    {
        private readonly IRepository<Position>? _positionRepository;

        public PositionService(IRepository<Position>? positionRepository)
        {
            _positionRepository = positionRepository;
        }

        public async Task<BaseResponse> GetPositions()
        {
           
            var positions = await _positionRepository.GetAllAsync();
            if(positions == null) return new BaseResponse { Status = false, Message = "No records found" };

            return new BaseResponse { Status = true, Message = "Records retrieved successfully", Data = positions };

        }

        public async Task<BaseResponse> GetPosition(long assetId, long driverId)
        {
            
           var position = await _positionRepository.GetByPositionByIdsAsync(assetId, driverId);
           if (position == null) return new BaseResponse { Status = false, Message = "No record found" };

           return new BaseResponse { Status = true, Message = "Records retrieved successfully", Data = position };
        }

        public async Task<BaseResponse> GetDistanceInKm(long assetId, long driverId, double staticLattitude, double staticLongitutude)
        {
           
            var truckPosition = await _positionRepository.GetByPositionByIdsAsync(assetId, driverId);
            if(truckPosition == null) return new BaseResponse { Status = false, Message = "No records found with such parameters" };

            var distance = await HaversineFormula((double)truckPosition.Latitude, (double)truckPosition.Longitude, staticLattitude, staticLongitutude);

            return new BaseResponse { Status = true, Message = "Distance retrieved succesfully", Data = distance };
        }


        private async Task<double> HaversineFormula(double latt1, double long1, double latt2, double long2)
        {
            const double EarthRadiusInKilometers = 6371; 

            var latt1InRadians = latt1 * (Math.PI / 180);
            var long1InRadians = long1 * (Math.PI / 180);
            var latt2InRadians = latt2 * (Math.PI / 180);
            var long2InRadians = long2 * (Math.PI / 180);

            double dlat = latt2InRadians - latt1InRadians;
            double dlon = long2InRadians - long1InRadians;
            double a = Math.Sin(dlat / 2) * Math.Sin(dlat / 2) +
                       Math.Cos(latt1InRadians) * Math.Cos(latt2InRadians) *
                       Math.Sin(dlon / 2) * Math.Sin(dlon / 2);

            double c = 2 * Math.Atan2(Math.Sqrt(a), Math.Sqrt(1 - a));

            double distance = EarthRadiusInKilometers * c;

            return distance;
        }





    }
}
