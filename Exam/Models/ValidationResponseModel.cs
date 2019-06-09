using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam.Models
{
    public class ValidationResponseModel
    {
        public bool isValid { get; set; }

        public List<string> ErrorMessages { get; set; }

        public CommandParamsModel CommandParams { get; set; }
    }
}
