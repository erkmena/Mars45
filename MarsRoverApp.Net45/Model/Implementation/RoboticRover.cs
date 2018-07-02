using MarsRoverApp.Model.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace MarsRoverApp.Model.Implementations
{
    public class RoboticRover : IVehicle
    {
        internal char _direction;

        internal Plateau _coordinate;


        public RoboticRover(char direction, Plateau coordinate)
        {
            _direction = direction;
            _coordinate = coordinate;
        }
        /// <summary>
        /// Get currenct coordinates
        /// </summary>
        /// <returns>Returns current coordinates of vehicle</returns>
        public Plateau CurrentCoordinates()
        {
            return _coordinate;
        }

        /// <summary>
        /// Get currenct direction
        /// </summary>
        /// <returns>Returns current direction of vehicle</returns>
        public char CurrentDirection()
        {
            return _direction;
        }

        /// <summary>
        /// Actual function for moving the vehicle
        /// </summary>
        /// <param name="directionToMove">Which side this vehicle will move</param>
        public void Move(Plateau directionToMove)
        {
            _coordinate.XAxis += directionToMove.XAxis;
            _coordinate.YAxis += directionToMove.YAxis;
        }

        /// <summary>
        /// Actual function for turning the vehicle
        /// </summary>
        /// <param name="directionToMove">Which side this vehicle will turn</param>
        public void Turn(char direction)
        {
            _direction = direction;
        }
    }
}
