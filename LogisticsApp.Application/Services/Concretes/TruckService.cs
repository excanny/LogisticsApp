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
    public class TruckService : ITruckService
    {
        private readonly IRepository<Truck>? _truckRepository;

        public TruckService(IRepository<Truck>? truckRepository)
        {
            _truckRepository = truckRepository;
        }

        public async Task<BaseResponse> GetAllTrucks()
        {
            var trucks = await _truckRepository.GetAllAsync();
            if (trucks == null) return new BaseResponse { Status = false, Message = "No records found" };

            return new BaseResponse { Status = true, Message = "Records retrieved successfully", Data = trucks };
        }
    }
}
