using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam.AppConstants
{
    public static class Constants
    {
        public static readonly IList<string> VALID_DRAW_OBJECTS = new ReadOnlyCollection<string>
            (new List<string> {
                "circle", "rectangle", "ellipse", "line", "path"
            });
    }
}
