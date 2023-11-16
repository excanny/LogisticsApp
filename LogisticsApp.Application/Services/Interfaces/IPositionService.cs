using LogisticsApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogisticsApp.Application.Services.Interfaces
{
    public interface IPositionService
    {
        Task<BaseResponse> GetDistanceInKm(long assetId, long driverId, double staticLattitude, double staticLongitutude);
        Task<BaseResponse> GetPosition(long assetId, long driverId);
        Task<BaseResponse> GetPositions();
    }
}
