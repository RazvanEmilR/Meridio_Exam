using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Exam.AppConstants
{
    /// <summary>
    /// The constants for the application
    /// </summary>
    public static class Constants
    {
        public static readonly IList<string> VALID_DRAW_OBJECTS = new ReadOnlyCollection<string>
            (new List<string> {
                "circle", "rectangle", "ellipse", "line", "path"
            });

        public static readonly int MIN_NUMBER_PARAMS = 5;
    }
}
