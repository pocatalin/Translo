using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace Translao
{
    internal class Gradient
    {
        private Brush gradientBrush;
        private Form form;
        private Color startColor;
        private Color endColor;
        private GradientType gradientType;

        public enum GradientType
        {
            Linear,
            Angular,
        }

        public Gradient(Form form, Color startColor, Color endColor, GradientType gradientType)
        {
            this.form = form;
            this.startColor = startColor;
            this.endColor = endColor;
            this.gradientType = gradientType;
            InitializeGradient(form.ClientRectangle);

            form.Paint += Form_Paint;
            form.Resize += Form_Resize;
            form.SizeChanged += MainForm_SizeChanged;
        }

        private void InitializeGradient(Rectangle rectangle)
        {
            switch (gradientType)
            {
                case GradientType.Linear:
                    gradientBrush = new LinearGradientBrush(rectangle, startColor, endColor, LinearGradientMode.Vertical);
                    break;
                case GradientType.Angular:
                    gradientBrush = new LinearGradientBrush(rectangle, startColor, endColor, LinearGradientMode.ForwardDiagonal);
                    break;
                default:
                    gradientBrush = new LinearGradientBrush(rectangle, startColor, endColor, LinearGradientMode.Vertical);
                    break;
            }
        }

        private void Form_Paint(object sender, PaintEventArgs e)
        {
            FillRectangle(e.Graphics, form.ClientRectangle);
        }

        private void Form_Resize(object sender, EventArgs e)
        {
            UpdateGradient(form.ClientRectangle);
            form.Invalidate();
        }

        private void MainForm_SizeChanged(object sender, EventArgs e)
        {
            const int minFormWidth = 1100;
            const int minFormHeight = 600;

            if (form.Width < minFormWidth)
            {
                form.Width = minFormWidth;
            }

            if (form.Height < minFormHeight)
            {
                form.Height = minFormHeight;
            }
        }

        public void FillRectangle(Graphics graphics, Rectangle rectangle)
        {
            graphics.FillRectangle(gradientBrush, rectangle);
        }

        public void UpdateGradient(Rectangle rectangle)
        {
            InitializeGradient(rectangle);
        }
    }
}
