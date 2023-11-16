using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogisticsApp.Domain.Entities
{
    public class Position
    {
        public long Id { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public int AgeOfReadingSeconds { get; set; }
        public long AssetId { get; set; }
        public decimal AltitudeMetres { get; set; }
        public long DriverId { get; set; }
        public decimal Heading { get; set; }
        public decimal Latitude { get; set; }
        public bool IsAvl { get; set; }
        public decimal OdometerKilometres { get; set; }
        public decimal Longitude { get; set; }
        public decimal Hdop { get; set; }
        public long PositionId { get; set; }
        public decimal Pdop { get; set; }
        public DateTime TimeStamp { get; set; }
        public string Source { get; set; }
        public decimal SpeedKilometresPerHour { get; set; }
        public decimal SpeedLimit { get; set; }
        public decimal Vdop { get; set; }
    }
}
