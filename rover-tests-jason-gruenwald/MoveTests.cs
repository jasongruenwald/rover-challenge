using rover_challenge_jason_gruenwald;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace rover_tests_jason_gruenwald
{
    public class MoveTests
    {
        #region Fields
        // this class is only reposible to call functions without using MOCK (moq) to instansiate the IRoverActions for testing
        private readonly RoverActions _roverActions;
        #endregion

        #region Constructors
        public MoveTests()
        {
            this._roverActions = new RoverActions();
        }
        #endregion

        #region Tests
        [Fact]
        public void SpinRight()
        {

            Rover roverSR = new Rover("1 2 N");

            roverSR = _roverActions.SpinRight(roverSR);

            Assert.True(roverSR.FacingDirection == CardinalDirection.east);
        }

        [Fact]
        public void SpinLeft()
        {

            Rover roverSL = new Rover("1 2 N");

            roverSL = _roverActions.SpinLeft(roverSL);

            Assert.True(roverSL.FacingDirection == CardinalDirection.west);
        }

        [Fact]
        public void MoveForward()
        {
            Rover roverMF = new Rover("1 2 N");
            Plateau plateau = new Plateau { XStartingBoundary = 0, XOutterBoundary = 5, YStartingBoundary = 0, YOutterBoundary = 5 };

            roverMF = _roverActions.RollForward(roverMF, plateau);

            Assert.True(roverMF.XPosition == 1 && roverMF.YPosition == 3 && roverMF.FacingDirection == CardinalDirection.north && roverMF.ErrorMessage == null);
        }

        [Fact]
        public void MoveFirstRover()
        {

            Rover roverMFR = new Rover("1 2 N");
            Plateau plateau = new Plateau { XStartingBoundary = 0, XOutterBoundary = 5, YStartingBoundary = 0, YOutterBoundary = 5 };
            string commands = "LMLMLMLMM";

            roverMFR = _roverActions.MoveCommand(roverMFR, commands, plateau);

            Assert.True(roverMFR.XPosition == 1 && roverMFR.YPosition == 3 && roverMFR.FacingDirection == CardinalDirection.north && roverMFR.ErrorMessage == null);
        }

        [Fact]
        public void MoveSecondRover()
        {

            Rover roverMSR = new Rover("3 3 E");
            Plateau plateau = new Plateau { XStartingBoundary = 0, XOutterBoundary = 5, YStartingBoundary = 0, YOutterBoundary = 5 };
            string commands = "MMRMMRMRRM";

            roverMSR = _roverActions.MoveCommand(roverMSR, commands, plateau);

            Assert.True(roverMSR.XPosition == 5 && roverMSR.YPosition == 1 && roverMSR.FacingDirection == CardinalDirection.east && roverMSR.ErrorMessage == null);
        }
        #endregion

    }
}