using MarsRoverApp.Model.Implementations;
using System;
using System.Collections.Generic;
using System.Text;

namespace MarsRoverApp.Model
{
    public class VehicleFactory
    {
        /// <summary>
        /// Vehicle factory for creating new vehicle.
        /// </summary>
        /// <param name="vehicle">Returns new vehicle</param>
        /// <returns></returns>
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
