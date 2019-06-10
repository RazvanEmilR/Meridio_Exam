namespace Exam.Models
{
    /// <summary>
    /// A model for returned params from user input after validation
    /// </summary>
    public class CommandParamsModel
    {
        public string Shape { get; set; }

        public int XCoord { get; set; }

        public int YCoord { get; set; }

        public int Width { get; set; }

        public int Height { get; set; }

        public int Radius { get; set; }

        public int X3Coord { get; set; }

        public int Y3Coord { get; set; }

        public int X4Coord { get; set; }

        public int Y4Coord { get; set; }

        public int X5Coord { get; set; }

        public int Y5Coord { get; set; }

        public string Color { get; set; }
    }
}
