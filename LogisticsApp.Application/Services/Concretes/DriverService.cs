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
    public class DriverService : IDriverService
    {
        private readonly IRepository<Driver>? _driverRepository;

        public DriverService(IRepository<Driver>? driverRepository)
        {
            _driverRepository = driverRepository;
        }

        public async Task<BaseResponse> GetAllDrivers()
        {
           //Get results using the generic repository pattern
           var drivers = await _driverRepository.GetAllAsync();
           if (drivers == null) return new BaseResponse { Status = false, Message = "No records found" }; 

           return new BaseResponse { Status = true, Message = "Records retrieved successfully", Data = drivers };
        }
    }
}
