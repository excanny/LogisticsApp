using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogisticsApp.Domain.Entities
{
    public class Driver
    {
        public long Id { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public long SiteId { get; set; }
        public long DriverId { get; set; }
        public string Name { get; set; }
        public int EmployeeNumber { get; set; }
        
    }
}
