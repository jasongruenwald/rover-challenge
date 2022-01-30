using System;
using System.Collections.Generic;
using System.Text;

namespace rover_challenge_jason_gruenwald
{
    public partial class RoverActions : IRoverActions
    {
        public virtual Rover SpinLeft(Rover rover)
        {
            switch (rover.FacingDirection)
            {
                case CardinalDirection.north:
                    rover.FacingDirection = CardinalDirection.west;
                    return (rover);
                case CardinalDirection.west:
                    rover.FacingDirection = CardinalDirection.south;
                    return (rover);
                case CardinalDirection.south:
                    rover.FacingDirection = CardinalDirection.east;
                    return (rover);
                case CardinalDirection.east:
                    rover.FacingDirection = CardinalDirection.north;
                    return (rover);
                default:
                    throw new ArgumentException("The SpinLeft rover.FacingDirection value is null or not valid.");
            }
        }

        public virtual Rover SpinRight(Rover rover)
        {
            switch (rover.FacingDirection)
            {
                case CardinalDirection.north:
                    rover.FacingDirection = CardinalDirection.east;
                    return (rover);
                case CardinalDirection.east:
                    rover.FacingDirection = CardinalDirection.south;
                    return (rover);
                case CardinalDirection.south:
                    rover.FacingDirection = CardinalDirection.west;
                    return (rover);
                case CardinalDirection.west:
                    rover.FacingDirection = CardinalDirection.north;
                    return (rover);
                default:
                    throw new ArgumentException("The SpinRight rover.FacingDirection value is null or not valid.");
            }
        }

        public virtual Rover RollForward(Rover rover, Plateau plateau)
        {
            switch (rover.FacingDirection)
            {
                case CardinalDirection.north:
                    if (rover.YPosition + 1 <= plateau.YOutterBoundary)
                    {
                        rover.YPosition++;
                    }
                    else
                    {
                        rover.SetErrorMessage("We would, but, we would go off the map. You are all the may to the end of the Northern plateau boundary.");
                    }
                    break;
                case CardinalDirection.east:
                    if (rover.XPosition + 1 <= plateau.XOutterBoundary)
                    {
                        rover.XPosition++;
                    }
                    else
                    {
                        rover.SetErrorMessage("We would, but, we would go off the map. You are all the may to the end of the Eastern plateau boundary.");
                    }
                    break;
                case CardinalDirection.south:
                    if (rover.YPosition - 1 < plateau.YStartingBoundary)
                    {

                    }
                    else
                    {
                        rover.YPosition--;
                    }
                    break;
                case CardinalDirection.west:
                    if (rover.XPosition - 1 < plateau.XStartingBoundary)
                    {
                        rover.SetErrorMessage("We would, but, we would go off the map. You are all the may to the end of the Western plateau boundary.");
                    }
                    else
                    {
                        rover.XPosition--;
                    }
                    break;
                default:
                    throw new ArgumentException("The RollForward rover.FacingDirection property could not be read or is not available.");
            }

            return rover;
        }


        public virtual Rover MoveCommand(Rover rover, string commands, Plateau plateau)
        {
            commands = commands.ToString().ToUpper();

            char[] instructions = commands.ToCharArray();
            // loop through the array and call the method that is associated
            for (int i = 0; i < instructions.Length; i++)
            {
                switch (instructions[i])
                {
                    case 'L':
                        rover = SpinLeft(rover);
                        break;
                    case 'R':
                        rover = SpinRight(rover);
                        break;
                    case 'M':
                        rover = RollForward(rover, plateau);
                        break;
                    default:
                        rover.ErrorMessage = "There was an unknown command given.";
                        throw new ArgumentException(rover.ErrorMessage);
                }
            }

            return rover;
        }

        public virtual CardinalDirection DetermineDirectionFromInput(string input)
        {
            switch (input.ToUpper())
            {
                case "N":
                    return CardinalDirection.north;
                case "S":
                    return CardinalDirection.south;
                case "E":
                    return CardinalDirection.east;
                case "W":
                    return CardinalDirection.west;
                default:
                    throw new ArgumentException("No direction of " + input + " is available.");
            }
        }

    }
}
