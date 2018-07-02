using MarsRoverApp.Model.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace MarsRoverApp.Model
{
    public interface IVehicle
    {
        /// <summary>
        /// Get currenct coordinates
        /// </summary>
        /// <returns>Returns current coordinates of vehicle</returns>
        Plateau CurrentCoordinates();

        /// <summary>
        /// Get currenct direction
        /// </summary>
        /// <returns>Returns current direction of vehicle</returns>
        char CurrentDirection();

        /// <summary>
        /// Actual function for moving the vehicle
        /// </summary>
        /// <param name="directionToMove">Which side this vehicle will move</param>
        void Move(Plateau directionToMove);


        /// <summary>
        /// Actual function for turning the vehicle
        /// </summary>
        /// <param name="directionToMove">Which side this vehicle will turn</param>
        void Turn(char direction);
    }
}
