using System;
using System.Collections.Generic;
using System.Text;

namespace rover_challenge_jason_gruenwald
{
    public partial interface IRoverActions 
    {
        Rover SpinLeft(Rover rover);

        Rover SpinRight(Rover rover);

        Rover RollForward(Rover rover, Plateau plateau);

        Rover MoveCommand(Rover rover, string commands, Plateau plateau);

        CardinalDirection DetermineDirectionFromInput(string input);
    }
}

