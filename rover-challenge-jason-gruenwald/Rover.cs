using System;
using System.Collections.Generic;
using System.Text;

namespace rover_challenge_jason_gruenwald
{
    /// <summary>
    /// Representing the Rover object and its attributes
    /// </summary>
    public partial class Rover
    {
        private int _xPosition;
        private int _yPosition;
        private CardinalDirection _facingDirection;

        //========== PUBLIC GET/SETS =================

        /// <summary>
        /// Name is the identity property
        /// </summary>
        public string? Name { get; set; }

        public int XPosition { get { return _xPosition; } set { _xPosition = value; } }

        public int YPosition { get { return _yPosition; } set { _yPosition = value; } }

        public CardinalDirection FacingDirection { get { return _facingDirection; } set { _facingDirection = value; } }

        public string? Message { get; set; }

        public string? ErrorMessage { get; set; }



        /// <summary>
        /// Rover defaults are set to starting position.
        /// </summary>
        public Rover(string input ="")
        {
            string[] roverAttributes = input.Split(" ");

            this.Name = "Jason G's Rover : " + DateTime.Now;

            this._xPosition = Helpers.GetCoordinateFromInput(roverAttributes[0]);

            this._yPosition = Helpers.GetCoordinateFromInput(roverAttributes[1]);

            this._facingDirection = Helpers.DetermineDirectionFromInput(roverAttributes[2].ToString());
        }

        public void SetMessage(string message = "")
        {
            // reset error message
            ErrorMessage = string.Empty;

            // set success message
            Message = message;

        }

        public void SetErrorMessage(string message = "")
        {
            // reset success message
            Message = string.Empty;

            // set error message
            ErrorMessage = message;
        }


    }
}
