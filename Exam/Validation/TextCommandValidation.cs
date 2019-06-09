using Exam.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Exam.AppConstants;

namespace Exam.Validation
{
    public static class TextCommandValidation
    {
        public static ValidationResponseModel ValidateCommand(string command)
        {
            ValidationResponseModel response = new ValidationResponseModel();
 
            response.ErrorMessages = new List<string>();
            response.CommandParams = new CommandParamsModel();

            response.isValid = true;

            string[] array = command.Split(' ');

            if (array.Length >= 5)
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
                    else if( shapeMatch.Equals("circle") || (shapeMatch.Equals("ellipse")) || (shapeMatch.Equals("rectangle")) )
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
                        else
                        {
                            response.isValid = false;
                            response.ErrorMessages.Add("Not enough params!");
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
                        else
                        {
                            response.isValid = false;
                            response.ErrorMessages.Add("Not enough params!");
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
                        else
                        {
                            response.isValid = false;
                            response.ErrorMessages.Add("Not enough params!");
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



    }
}
