using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using Exam.Validation;


/// <summary>
/// 
/// The Main form for the app
/// </summary>
namespace Exam
{
    public partial class frmCanvasTest : Form
    {
    
        public frmCanvasTest()
        {
            InitializeComponent();
        }


        private void frmCanvasTest_Load(object sender, EventArgs e)
        {        
            canvas.BackColor = Color.Gray;

            lblCheck.Text = string.Empty;

        }

        private void btnProcess_Click(object sender, EventArgs e)
        {
  
            var textCommand = tbxInput.Text;
            string labelText = string.Empty;

            var validationResponse = TextCommandValidation.ValidateCommand(textCommand);

            if (!validationResponse.isValid)
            {
                foreach (string line in validationResponse.ErrorMessages)
                {
                    labelText += (line + ';');
                }

                lblCheck.Text = labelText;
            }
            else
            {

                Graphics g = canvas.CreateGraphics();

                if (validationResponse.CommandParams.Color != null)
                {
                    Brush brush = new SolidBrush(Color.FromName(validationResponse.CommandParams.Color));
                    Pen pen = new Pen(brush, 3);

                    if ((validationResponse.CommandParams.Shape.Equals("circle")) || (validationResponse.CommandParams.Shape.Equals("ellipse")))
                    {
                        var x = validationResponse.CommandParams.XCoord;
                        var y = validationResponse.CommandParams.YCoord;
                        var width = validationResponse.CommandParams.Width;
                        var height = validationResponse.CommandParams.Height;

                        g.DrawEllipse(pen, x, y, width, height);
                    }
                    else if (validationResponse.CommandParams.Shape.Equals("rectangle"))
                    {
                        var x = validationResponse.CommandParams.XCoord;
                        var y = validationResponse.CommandParams.YCoord;
                        var width = validationResponse.CommandParams.Width;
                        var height = validationResponse.CommandParams.Height;

                        g.DrawRectangle(pen, x, y, width, height);
                    }
                    else if (validationResponse.CommandParams.Shape.Equals("line"))
                    {
                        var x1 = validationResponse.CommandParams.XCoord;
                        var y1 = validationResponse.CommandParams.YCoord;
                        var x2 = validationResponse.CommandParams.Width;
                        var y2 = validationResponse.CommandParams.Height;

                        g.DrawLine(pen, x1, y1, x2, y2);
                    }
                    else if (validationResponse.CommandParams.Shape.Equals("path"))
                    {
                        var x1 = validationResponse.CommandParams.XCoord;
                        var y1 = validationResponse.CommandParams.YCoord;
                        var x2 = validationResponse.CommandParams.Width;
                        var y2 = validationResponse.CommandParams.Height;
                        var x3 = validationResponse.CommandParams.X3Coord;
                        var y3 = validationResponse.CommandParams.Y3Coord;
                        var x4 = validationResponse.CommandParams.X4Coord;
                        var y4 = validationResponse.CommandParams.Y4Coord;
                        var x5 = validationResponse.CommandParams.X5Coord;
                        var y5 = validationResponse.CommandParams.Y5Coord;

                        GraphicsPath path = new GraphicsPath();


                        path.AddLine(x1, y1, x2, y2);
                        path.AddLine(x2, y2, x3, y3);
                        path.AddLine(x3, y3, x4, y4);
                        path.AddLine(x4, y4, x5, y5);

                        g.DrawPath(pen, path);
                    }
                }
            }

        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            tbxInput.Text = string.Empty;
            lblCheck.Text = string.Empty;
        }
    }
}
