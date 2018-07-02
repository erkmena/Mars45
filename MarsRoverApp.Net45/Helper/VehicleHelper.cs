using MarsRoverApp.Model;
using MarsRoverApp.Model.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace MarsRoverApp.Helper
{
    /// <summary>
    ///  TODO : All functions in this class is public static because for use in unit test project. When the test finishes return them to private.
    /// </summary>
    public class VehicleHelper
    {
        /// <summary>
        /// Main function for processing path data.
        /// </summary>
        /// <param name="rawData">Path Data of the vehicle. Ex: "LLLLMMLM"</param>
        /// <param name="vehicle">The vehicle which research the area</param>
        /// <param name="plateau">The area</param>
        /// <returns>Returns vehicle with processed data</returns>
        public static IVehicle ProcessData(string rawData, IVehicle vehicle, Plateau plateau)
        {
            rawData = rawData.Trim();//Trim for unnecessary spaces.
            foreach (char nextCommand in rawData) // Look for every char so, process every command step by step
            {
                char genericCommand = Convert.ToChar(nextCommand.ToString().ToUpper()); // Get a generic command so avoid from little exceptions like uppercase or lowercase
                if (genericCommand == 'M')
                {
                    MoveVehicle(vehicle, plateau); 
                }

                else if (genericCommand == 'L' || genericCommand == 'R')
                {
                    TurnVehicle(vehicle, genericCommand);
                }

                else
                {
                    throw new NotImplementedException(); // If can not find command with specific char throw exception
                }
            }

            return vehicle;
        }

        /// <summary>
        /// The function which will move vehicle. From this function vehicle coordinates changes.
        /// </summary>
        /// <param name="vehicle">The vehicle which will move</param>
        /// <param name="plateau">The area which vehicle will move on.</param>
        public static void MoveVehicle(IVehicle vehicle, Plateau plateau)
        {
            Plateau directionToMove = GetDirectionToMove(vehicle);
            CheckForBoundaries(vehicle.CurrentCoordinates(), directionToMove, plateau);

            vehicle.Move(directionToMove);
        }


        /// <summary>
        /// This function predicts next moves of vehicle and check for if there is any exceed.
        /// </summary>
        /// <param name="currentCoordinates">Vehicle coordinates for calculate moves</param>
        /// <param name="directionToMove">Which direction the vehicle move</param>
        /// <param name="originalPlateau">Main platform</param>
        public static void CheckForBoundaries(Plateau currentCoordinates, Plateau directionToMove, Plateau originalPlateau)
        {
            int predictedXAxis = currentCoordinates.XAxis + directionToMove.XAxis;
            int predictedYAxis = currentCoordinates.YAxis + directionToMove.YAxis;

            if (predictedXAxis > originalPlateau.XAxisLength || predictedXAxis < 0)
            {
                directionToMove.XAxis = 0;
            }
            if(predictedYAxis > originalPlateau.YAxisLength || predictedYAxis < 0)
            {
                directionToMove.YAxis = 0;
            }
        }
        /// <summary>
        /// This function turns vehicle to next direction.
        /// </summary>
        /// <param name="vehicle">Vehicle to turn.</param>
        /// <param name="sideToTurn">Which side vehicle turn.</param>
        public static void TurnVehicle(IVehicle vehicle, char sideToTurn)
        {
            char directionToTurn = GetDirectionToTurn(vehicle, sideToTurn);
            vehicle.Turn(directionToTurn);
        }

        /// <summary>
        /// Calculate the direction which vehicle will turn by side (Left /Right)
        /// </summary>
        /// <param name="vehicle">The vehicke which will turn</param>
        /// <param name="sideToTurn">The side vehicle turn.</param>
        /// <returns>Returns direction to Turn</returns>
        ///                     N
        ///                     /\
        ///                     |
        ///               W <___|___>E
        ///                     |
        ///                     |
        ///                    \/ 
        ///                     S
        public static char GetDirectionToTurn(IVehicle vehicle, char sideToTurn)
        {
            char directionToTurn;

            if (sideToTurn.ToString().ToUpper() == "L")
            {
                switch (Convert.ToChar(vehicle.CurrentDirection()))
                {
                    case Direction.East:
                        directionToTurn = Direction.North;
                        break;
                    case Direction.North:
                        directionToTurn = Direction.West;
                        break;
                    case Direction.South:
                        directionToTurn = Direction.East;
                        break;
                    case Direction.West:
                        directionToTurn = Direction.South;
                        break;

                    default:
                        throw new NotImplementedException();
                        break;
                }
            }
            else if (sideToTurn.ToString().ToUpper() == "R")
            {
                switch (Convert.ToChar(vehicle.CurrentDirection()))
                {
                    case Direction.East:
                        directionToTurn = Direction.South;
                        break;
                    case Direction.North:
                        directionToTurn = Direction.East;
                        break;
                    case Direction.South:
                        directionToTurn = Direction.West;
                        break;
                    case Direction.West:
                        directionToTurn = Direction.North;
                        break;

                    default:
                        throw new NotImplementedException();
                        break;
                }
            }
            else
            {
                throw new NotImplementedException();
            }

            return directionToTurn;
        }
        /// <summary>
        /// Calculate the coordinates so vehicle can move itself coordinates with sum of theese coordinates.
        /// </summary>
        /// <param name="vehicle">Vehicle to move</param>
        /// <returns>Returns the movement</returns>
        public static Plateau GetDirectionToMove(IVehicle vehicle)
        {
            Plateau directionToMove = new Plateau(1,1);
            switch (Convert.ToChar(vehicle.CurrentDirection()))
            {
                case Direction.East:
                    directionToMove.XAxis = 1;
                    break;
                case Direction.North:
                    directionToMove.YAxis = 1;
                    break;
                case Direction.South:
                    directionToMove.YAxis = -1;
                    break;
                case Direction.West:
                    directionToMove.XAxis = -1;
                    break;

                default:
                    throw new NotImplementedException();
                    break;
            }
            return directionToMove;
        }
    }
}
