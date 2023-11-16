using LogisticsApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogisticsApp.Application.Services.Interfaces
{
    public interface ITruckService
    {
        Task<BaseResponse> GetAllTrucks();
    }
}
