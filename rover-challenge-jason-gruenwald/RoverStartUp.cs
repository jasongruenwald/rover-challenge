using System;
using System.Collections.Generic;

/// <summary>
/// Jason Gruenwald | July 22nd, 2020 | jasongruenwald@yahoo.com | 206.715.8104
/// This is a program should meet the Mars Rover Challenge in a C# Visual Studio console .NET Core environment.
/// There are few things that could use refactoring, and maybe it is way over kill, but, 
/// I tried to use different techniques that could show ability and the deadline is here.
/// Thank you for your time!
/// </summary>
namespace rover_challenge_jason_gruenwald
{
    class RoverStartUp
    {
        static void Main()
        {
            bool reprogramRovers = true;
            do
            {
                CommandCenter.BeginRoverInstructions();

                CommandCenter.PlateauBoundaryInstructions();

                Plateau plateau = CommandCenter.GetPlateauBoundariesFromInput();

                // We could ask for input but we are told we have two rovers
                List<Rover> rovers = CommandCenter.BuildAndInstructRovers(2, plateau);

                CommandCenter.WriteRoverLocationOutput(rovers);

                reprogramRovers = CommandCenter.QuitOrTryAgain();

            } while (reprogramRovers);
        }
    }
}
