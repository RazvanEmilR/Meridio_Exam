using Exam.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using Exam.AppConstants;

/// <summary>
/// Validation for the user input
/// </summary>
namespace Exam.Validation
{
    public static class TextCommandValidation
    {
        /// <summary>
        /// Validate user command
        /// </summary>
        /// <param name="command"></param>
        /// <returns>Validated params</returns>
        public static ValidationResponseModel ValidateCommand(string command)
        {
            ValidationResponseModel response = new ValidationResponseModel();

            response.ErrorMessages = new List<string>();
            response.CommandParams = new CommandParamsModel();

            response.isValid = true;

            string[] array = command.Split(' ');

            if (array.Length >= Constants.MIN_NUMBER_PARAMS) // 5 is minimum number of params we can have for a valid command in this exam
            {
                if (!array[0].ToLower().Equals("draw"))
                {
                    response.isValid = false;
                    response.ErrorMessages.Add("unrecognized command: " + array[0]);
                }

                if (!string.IsNullOrEmpty(array[1]))
                {
                    var shapeMatch = Constants.VALID_DRAW_OBJECTS.FirstOrDefault(s => s.Equals(array[1].ToLower()));
                    if (shapeMatch == null)
                    {
                        response.isValid = false;
                        response.ErrorMessages.Add("invalid shape type: " + array[1]);
                    }
                    else 
                    {
                        response.CommandParams.Shape = array[1];

                        if (!string.IsNullOrEmpty(array[2]))
                        {
                            int output;
                            bool success = Int32.TryParse(array[2], out output);
                            if (success)
                            {
                                response.CommandParams.XCoord = output;
                            }
                            else
                            {
                                response.isValid = false;
                                response.ErrorMessages.Add(array[2] + "is not a valid integer!");
                            }
                        }
  
                        if (!string.IsNullOrEmpty(array[3]))
                        {
                            int output;
                            bool success = Int32.TryParse(array[3], out output);

                            if (success)
                            {
                                response.CommandParams.YCoord = output;
                            }
                            else
                            {
                                response.isValid = false;
                                response.ErrorMessages.Add(array[3] + "is not valid integer!");
                            }
                        }
      

                        if (!string.IsNullOrEmpty(array[4]))
                        {
                            int output;
                            bool success = Int32.TryParse(array[4], out output);

                            if (success)
                            {
                                if (response.CommandParams.Shape.Equals("circle"))
                                {
                                    response.CommandParams.Width = response.CommandParams.Height = 2 * output;
                                }
                                else
                                {
                                    response.CommandParams.Width = output;
                                }
                            }
                            else
                            {
                                response.isValid = false;
                                response.ErrorMessages.Add(array[4] + " is not a valid integer!");
                            }
                        }
      


                        if (!string.IsNullOrEmpty(array[5]))
                        {
                            if (response.CommandParams.Shape.Equals("circle"))
                            {
                                response.CommandParams.Color = char.ToUpper(array[5].First()) + array[5].Substring(1).ToLower();
                            }
                            else
                            {
                                int output;
                                bool success = Int32.TryParse(array[5], out output);

                                if (success)
                                {
                                    response.CommandParams.Height = output;
                                }
                                else
                                {
                                    response.isValid = false;
                                    response.ErrorMessages.Add(array[5] + " is not a valid integer!");
                                }
                            }
                        }

                        // if the number of params is charateristic to rectangle, ellipse or a line
                        if (array.Length == 7)
                        {
                            if (!string.IsNullOrEmpty(array[6]))
                            {
                                response.CommandParams.Color = char.ToUpper(array[6].First()) + array[6].Substring(1).ToLower();
                            }
                        }
                        else if (array.Length == 13)  // if the number of params denotes user wants to draw a path
                        {
                            int tempValue = 0;

                            if ((ConvertToInt(array[6], ref tempValue)))   // to avoid writing too much code, pass a temp by ref and return the result
                            {
                                response.CommandParams.X3Coord = tempValue;
                                
                            }
                            else
                            {
                                response.ErrorMessages.Add(array[6] + " is not a valid integer!");
                            }

                            if ((ConvertToInt(array[7], ref tempValue)))
                            {
                                response.CommandParams.Y3Coord = tempValue;
                                
                            }
                            else
                            {
                                response.ErrorMessages.Add(array[7] + " is not a valid integer!");
                            }



                            if ((ConvertToInt(array[8], ref tempValue)))
                            {
                                response.CommandParams.X4Coord = tempValue; 
                                
                            }
                            else
                            {
                                response.ErrorMessages.Add(array[8] + " is not a valid integer!");
                            }

                            if ((ConvertToInt(array[9], ref tempValue)))
                            {
                                response.CommandParams.Y4Coord = tempValue;
                                
                            }
                            else
                            {
                                response.ErrorMessages.Add(array[9] + " is not a valid integer!");
                            }

                            if ((ConvertToInt(array[10], ref tempValue)))
                            {
                                response.CommandParams.X5Coord = tempValue;                             
                            }
                            else
                            {
                                response.ErrorMessages.Add(array[10] + " is not a valid integer!");
                            }

                            if ((ConvertToInt(array[11], ref tempValue)))
                            {
                                response.CommandParams.Y5Coord = tempValue;                               
                            }
                            else
                            {
                                response.ErrorMessages.Add(array[11] + " is not a valid integer!");
                            }

                            response.CommandParams.Color = char.ToUpper(array[12].First()) + array[12].Substring(1).ToLower();
                        }

                    }
       
                }

            }
            else
            {
                response.ErrorMessages.Add("Bad input!Not Enough parameters");
                response.isValid = false;
            }

            return response;
        }

        /// <summary>
        /// Helper method to convert to int
        /// </summary>
        /// <param name="input"></param>
        /// <param name="assigned"></param>
        /// <returns></returns>
        private static bool ConvertToInt(string input, ref int assigned)
        {
            int output;
            bool success = Int32.TryParse(input, out output);

            if (success)
            {
                assigned = output;
            }

            return success;
        }

    }
}
