using System.Collections.Generic;

namespace Exam.Models
{
    /// <summary>
    /// A return validation object
    /// </summary>
    public class ValidationResponseModel
    {
        public bool isValid { get; set; }

        public List<string> ErrorMessages { get; set; }

        public CommandParamsModel CommandParams { get; set; }
    }
}
