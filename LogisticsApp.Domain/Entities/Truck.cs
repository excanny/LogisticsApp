using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogisticsApp.Domain.Entities
{
    public class Truck
    {
        public long Id { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public long SiteId { get; set; }
        public long AssetId { get; set; }
        public string? RegistrationNumber { get; set; }
        public DateTime LastPositionTimestamp { get; set; }
        public decimal Latitude { get; set; }
        public decimal Longitude { get; set; }
        public string? CurrentAddress { get; set; }
    }
}
