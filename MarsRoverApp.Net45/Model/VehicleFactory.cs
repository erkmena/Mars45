using MarsRoverApp.Model.Implementations;
using System;
using System.Collections.Generic;
using System.Text;

namespace MarsRoverApp.Model
{
    public class VehicleFactory
    {

        public static IVehicle MakeVehicle(object vehicle)
        {
            if (vehicle is RoboticRover)
            {
                return (RoboticRover)vehicle;

            }
            else
            {
                throw new NotImplementedException();
            }
        }

    }
}
