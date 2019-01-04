using System;
using System.Collections.Generic;

namespace WheelSpaMobileApp
{
    public class ResultDataVehicleList
    {
        public string Status { get; set; }

        public string Message { get; set; }

        public List<Vehicle> VehicleDetails { get; set; }
    }
}
