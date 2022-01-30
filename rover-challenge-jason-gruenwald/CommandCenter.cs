using System;
using System.Collections.Generic;
using System.Text;

namespace rover_challenge_jason_gruenwald
{
    public static class CommandCenter
    {
        public static void BeginRoverInstructions()
        {
            Console.WriteLine(" ** Welcome to the JG Rover command center! **");
            Console.WriteLine(" ================================================================================");
            Console.WriteLine(" Today you will be exploring an unknown plateau");
            Console.WriteLine(" and giving rovers instructions on where to move on a grid in string commands. ");
            Console.WriteLine(Environment.NewLine);
            Console.WriteLine(" 1. You will input the grid dimensions in line 1. ");
            Console.WriteLine(" 2. Enter the current coordinates of the Rover One. ");
            Console.WriteLine(" 3. Next, enter instructions to move Rover One. ");
            Console.WriteLine(" 4. Enter the current coordinates of Rover Two. ");
            Console.WriteLine(" 5. Then instructions to move Rover Two. ");
            Console.WriteLine(Environment.NewLine);
        }

        public static void PlateauBoundaryInstructions()
        {
            Console.WriteLine(" Enter the upper-right \"X\" and \"Y\" grid coordinates of the plateau the rover is on separated by a space.");
            Console.WriteLine(" They must be numbers/integers.");
            Console.WriteLine(" Coordinates must be >= 5 to make a proper grid.");
            Console.WriteLine(" Example: 5 7 would be five right, and 7 down.");
            Console.WriteLine(" The lower-left coordinates are assumed to be 0,0.");
            Console.WriteLine(" Only two integers will be accepted.");
        }

        public static Plateau GetPlateauBoundariesFromInput()
        {
            Plateau plateau = new Plateau();
            var input = Console.ReadLine();
            var inputConfirmed = string.Empty;

            if (string.IsNullOrWhiteSpace(input))
            {
                Console.WriteLine(Environment.NewLine);
                Console.WriteLine(" Please enter two integers for plateau upper right coordinates.");
            }
            else
            {
                inputConfirmed = Helpers.ScrubPlateauBoundaryInput(input);

                bool correctInput = Helpers.IsBoundaryCorrectLength(inputConfirmed.Trim());

                if (!correctInput || !Helpers.IsBoundaryIntArray(inputConfirmed))
                {
                    do
                    {
                        Console.WriteLine(Environment.NewLine);
                        Console.WriteLine(" Please enter two integers for plateau upper right coordinates.");
                        input = Helpers.ScrubPlateauBoundaryInput(Console.ReadLine());

                        correctInput = Helpers.IsBoundaryCorrectLength(input);

                    } while (!Helpers.IsBoundaryIntArray(input) || !correctInput);
                }
            }

            // get int grid
            var pGrid = Helpers.GetIntArrayFromInput(input);

            // are there two numbers in for the grid X and y?
            plateau.XOutterBoundary = pGrid[0];
            plateau.YOutterBoundary = pGrid[1];

            return plateau;

        }

        public static Rover CreateNewRover(string roverName)
        {
            Console.WriteLine(Environment.NewLine);
            Console.WriteLine(" Enter the coordinates of Rover " + roverName + ".");

            var input = string.Empty;

            do
            {
                Console.WriteLine(" You will need two integers and a 1 letter direction the rover is facing; each separated by a space.");
                Console.WriteLine(" Example: 1 2 N or 3 3 E");
                Console.WriteLine(Environment.NewLine);
                input = Console.ReadLine();

            } while (string.IsNullOrWhiteSpace(input) || !Helpers.IsRoverLocationPattern(input));

            var r1 = input.Split(" ");

            Rover rover = new Rover(r1[0] + " " + r1[1] + " " + r1[2])
            {
                Name = "Rover " + roverName
            };

            return rover;
        }

        public static string GetRoverInstructions()
        {
            Console.WriteLine(Environment.NewLine);
            Console.WriteLine(" Please enter the instructions for Rover. Type ? for help.");

            string input = Console.ReadLine();

            if (!Helpers.IsRoverInstrcutionsPattern(input.ToUpper()))
            {
                do
                {
                    Console.WriteLine(" Enter rover instructions as a single letter for each instrucion. ");
                    Console.WriteLine(" L = spin left, R = Spin right, and M = move forward. ");
                    Console.WriteLine(" Example: LMLMLMLMM or MMRMMRMRRM ");
                    Console.WriteLine(Environment.NewLine);
                    input = Console.ReadLine();
                    Console.WriteLine(Environment.NewLine);

                } while (!Helpers.IsRoverInstrcutionsPattern(input.ToUpper()));
            }

            return input;
        }

        public static List<Rover> BuildAndInstructRovers(int roverCount, Plateau plateau)
        {
            List<Rover> rovers = new List<Rover>();
            for (int i = 0; i < roverCount; i++)
            {
                // Create new rover object and set its coordinates
                rovers.Add(CommandCenter.CreateNewRover((i + 1).ToString()));

                // Get instructions and move rover
                IRoverActions iRoverActions = new RoverActions();
                rovers[i] = iRoverActions.MoveCommand(rovers[i], CommandCenter.GetRoverInstructions(), plateau);
            }

            return rovers;
        }

        public static void WriteRoverLocationOutput(List<Rover> rovers)
        {
            if (rovers.Count <= 0)
            {
                Console.WriteLine(" We are unable to locate and command the rovers. Please try again.", Environment.NewLine);
            }

            Console.WriteLine(Environment.NewLine);

            foreach (var rover in rovers)
            {
                Console.Write(" Expected Output:");
                Console.Write(" " + rover.Name + ": ");
                Console.WriteLine(rover.XPosition + " " + rover.YPosition + " " + Helpers.DirectionLetterOutPut(rover.FacingDirection));
                Console.WriteLine(Environment.NewLine);
            }

            Console.WriteLine(" Rovers are now in position.");
            Console.Write(Environment.NewLine);
        }

        public static bool QuitOrTryAgain()
        {
            var input = string.Empty;

            do
            {
                Console.WriteLine(" ================================================================================");
                Console.WriteLine(" To move them again, type \"Y\".");
                Console.WriteLine(" To quit the program, type \"N\".");
                Console.WriteLine(Environment.NewLine);
                input = Console.ReadLine();
                Console.WriteLine(Environment.NewLine);

            } while (!Helpers.QuitTryDecision(input.ToUpper()));

            if (Helpers.TryAgain(input.ToUpper()))
            {
                return true;
            }

            return false;
        }
    }
}
