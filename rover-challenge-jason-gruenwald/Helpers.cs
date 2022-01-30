using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace rover_challenge_jason_gruenwald
{
    public static class Helpers
    {
        public static string ScrubCoordinateInput(String input)
        {
            var sb = new StringBuilder();

            foreach (char c in input)
            {
                if (!char.IsPunctuation(c))
                {
                    sb.Append(c + " ");
                }

            }

            input = sb.ToString();
            return input.Replace("  ", " ");
        }

        public static int GetCoordinateFromInput(string input)
        {
            int.TryParse(input, out int c);
            return c;
        }

        public static CardinalDirection DetermineDirectionFromInput(string input)
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

            // Available in C# 7.3 or higher
            //return (input.ToUpper()) switch
            //{
            //    "N" => CardinalDirection.north,
            //    "S" => CardinalDirection.south,
            //    "E" => CardinalDirection.east,
            //    "W" => CardinalDirection.west,
            //    _ => throw new ArgumentException("No direction of " + input + " is available."),
            //};
        }

        public static string DirectionLetterOutPut(CardinalDirection input)
        {
            switch (input)
            {
                case CardinalDirection.north:
                    return "N";
                case CardinalDirection.south:
                    return "S";
                case CardinalDirection.east:
                    return "E";
                case CardinalDirection.west:
                    return "W";
                default:
                    return "";
            }

            // Available in C# 7.3 or higher
            //return (input) switch
            //{
            //    CardinalDirection.north => "N",
            //    CardinalDirection.south => "S",
            //    CardinalDirection.east => "E",
            //    CardinalDirection.west => "W"
            //};
        }

        public static string ScrubPlateauBoundaryInput(string input)
        {
            while (input.Contains("  ")){
                input = input.Replace("  ", " ");
            }

            MatchCollection newMatch = Regex.Matches(input, "[0-9\\s]");

            if (newMatch.Count > 0)
            {
                var sb = new StringBuilder();

                foreach (char c in input)
                {
                    if (!char.IsPunctuation(c))
                    {
                        if (int.TryParse(c.ToString(), out int num) || c == ' ')
                        {
                            sb.Append(c);
                        }
                    }
                }

                return input = sb.ToString() != " " ? sb.ToString() : "0";
            }
            else
            {
                return "0";
            }
        }

        public static bool IsBoundaryCorrectLength(string input)
        {
            return (input != " " || !string.IsNullOrEmpty(input) || input != "0") ? GetIntArrayFromInput(input).Length == 2 : true;
        }

        public static bool IsBoundaryIntArray(string input)
        {
            if (string.IsNullOrEmpty(input) || input == "0")
            {
                return false;
            }

            MatchCollection newMatch = Regex.Matches(input, "[0-9]");

            if (newMatch.Count > 0)
            {
                var nums = input.Split(" ");
                for (int i = 0; i < 2; i++)
                {
                    if (!int.TryParse(nums[i].ToString(), out int num))
                    {
                        return false;
                    }
                }
                return true; ;
            }
            else
            {
                return false;
            }
        }

        public static int[] GetIntArrayFromInput(string input)
        {
            if (string.IsNullOrEmpty(input) || input == "0")
            {
                return new int[0];
            }

            string[] numbers = input.Trim().Split(" ");

            if (numbers.Length > 0 && numbers.Length == 2)
            {
                int[] array = new int[numbers.Length];

                for (int i = 0; i < numbers.Length; i++)
                {
                    array[i] = Convert.ToInt32(numbers[i]);
                }
                return array;
            }
            else
            {
                throw new ArgumentException("Only integers are allowed for coordinates and boundaries.");
            }
        }

        public static bool IsRoverLocationPattern(string input)
        {
            string[] location = input.Split(" ");

            // we know that the instructions have 3 inputs, the first two must be integers
            if (location.Length == 3)
            {
                for (int i = 0; i < location.Length; i++)
                {
                    if (i < 2)
                    {
                        if (!int.TryParse(location[i].ToString(), out int num))
                        {
                            return false;
                        }
                    }
                }
                return true;
            }
            else
            {
                return false;
            }
        }

        public static bool IsRoverInstrcutionsPattern(string input)
        {
            bool IsRoverCommand = true;

            foreach (char c in input)
            {
                switch (c)
                {
                    case 'R':
                        break;
                    case 'L':
                        break;
                    case 'M':
                        break;
                    default:
                        return false;
                }
            }

            return IsRoverCommand;
        }

        public static bool TryAgain(string input)
        {
            if (input == "Y")
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public static bool QuitProgram(string input)
        {
            if (input == "N")
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public static bool QuitTryDecision(string input)
        {
            if (input == "N" || input == "Y")
            {
                return true;
            }
            else
            {
                return false;
            }
        }

    }
}
