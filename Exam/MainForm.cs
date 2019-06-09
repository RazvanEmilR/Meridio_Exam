using System;
using System.Drawing;
using System.Windows.Forms;
using Exam.DrawHelpers;
using Exam.Validation;

namespace Exam
{
    public partial class frmCanvasTest : Form
    {
        //private Graphics graphicsCanvas;

        public frmCanvasTest()
        {
            InitializeComponent();
        }


        //private void Canvas_Paint(object sender, PaintEventArgs e)
        //{

        //    Graphics gObject = canvas.CreateGraphics();
        //    Brush red = new SolidBrush(Color.White);

        //    Pen redPen = new Pen(red, 8);

        //    gObject.DrawLine(redPen, 10, 10, 400, 376);

        //    btnProcess.Enabled = true;
        //}

        private void frmCanvasTest_Load(object sender, EventArgs e)
        {        
            canvas.BackColor = Color.Gray;

            lblCheck.Text = string.Empty;

            //canvas.Paint += Canvas_Paint;
        }

        private void btnProcess_Click(object sender, EventArgs e)
        {
            //btnProcess.Paint += new PaintEventHandler(Canvas_Paint);


            //Graphics gObject = canvas.CreateGraphics();
            //Brush red = new SolidBrush(Color.White);

            //Pen redPen = new Pen(red, 3);

            //gObject.DrawLine(redPen, 10, 10, 400, 376);

            //btnProcess.Enabled = true;

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
                if (validationResponse.CommandParams.Shape.Equals("circle"))
                {
                    Graphics g = canvas.CreateGraphics();
                    Brush brush = new SolidBrush(Color.FromName(validationResponse.CommandParams.Color));

                    var x = validationResponse.CommandParams.XCoord;
                    var y = validationResponse.CommandParams.YCoord;
                    var w = validationResponse.CommandParams.Width;
                    var h = validationResponse.CommandParams.Height;

                    Pen pen = new Pen(brush, 3);
                    g.DrawEllipse(pen, x, y, w, h);

                }
            }

            //this.Invalidate();
            //btnProcess.Enabled = false;
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            tbxInput.Text = string.Empty;
            lblCheck.Text = string.Empty;
        }
    }
}
