using Newtonsoft.Json;
using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Speech.Synthesis;
using System.Windows.Forms;
using System.IO;
using Translao.Clases.Gradient;

namespace Translao
{
    internal class Gradient
    {
        private Brush gradientBrush;
        private Form form;
        private Color startColor;
        private Color endColor;
        private GradientType gradientType;
        private int MaxShapes;

        public Gradient(Form form, Color startColor, Color endColor, GradientType gradientType,int MaxShapes)
        {
            this.form = form;
            this.startColor = startColor;
            this.endColor = endColor;
            this.gradientType = gradientType;
            this.MaxShapes = MaxShapes;
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
                case GradientType.Horizontal:
                    gradientBrush = new LinearGradientBrush(rectangle, startColor, endColor, LinearGradientMode.Horizontal);
                    break;
                case GradientType.Diagonal:
                    gradientBrush = new LinearGradientBrush(rectangle, startColor, endColor, LinearGradientMode.BackwardDiagonal);
                    break;
                case GradientType.Circle:
                    Bitmap circleGradient = CreateCircleGradient(startColor, endColor,  rectangle.Width, rectangle.Height);
                    gradientBrush = new TextureBrush(circleGradient);
                    break;
                case GradientType.SquaresIn:
                    Bitmap diamondGradient = CreateDiamondGradient(startColor, endColor, rectangle.Width, rectangle.Height,MaxShapes);
                    gradientBrush = new TextureBrush(diamondGradient);
                    break;
                case GradientType.CirclesCrazy:
                    Bitmap CirclesCrazyGradient = CreateCirclesCrazyGradient(startColor, endColor, rectangle.Width, rectangle.Height, MaxShapes);
                    gradientBrush = new TextureBrush(CirclesCrazyGradient);
                    break;
                case GradientType.SquaresOut:
                    Bitmap SquaresGradient = CreateSquaresGradient(startColor, endColor, rectangle.Width, rectangle.Height, MaxShapes);
                    gradientBrush = new TextureBrush(SquaresGradient);
                    break;
                case GradientType.Lines:
                    Bitmap LinesGradient = CreateLinesGradient(startColor, endColor, rectangle.Width, rectangle.Height, MaxShapes);
                    gradientBrush = new TextureBrush(LinesGradient);
                    break;
                case GradientType.Square90:
                    Bitmap Square90Gradient = CreateSquare90Gradient(startColor, endColor, rectangle.Width, rectangle.Height, MaxShapes);
                    gradientBrush = new TextureBrush(Square90Gradient);
                    break;
                case GradientType.Circle2:
                    Bitmap Circle2Gradient = CreateCircle2Gradient(startColor, endColor, rectangle.Width, rectangle.Height, MaxShapes);
                    gradientBrush = new TextureBrush(Circle2Gradient);
                    break;
            }
        }

        public static Bitmap CreateCircle2Gradient(Color color1, Color color2, int width, int height, int maxCircles)
        {
            Bitmap gradientBitmap = new Bitmap(width, height);

            int centerX = width / 2;
            int centerY = height / 2;

            double maxDistance = Math.Sqrt(Math.Pow(centerX, 2) + Math.Pow(centerY, 2));
            double stepSize = maxDistance / maxCircles;

            using (Graphics g = Graphics.FromImage(gradientBitmap))
            {
                g.Clear(Color.White);

                for (int i = maxCircles; i > 0; i--)
                {
                    double radius = stepSize * i;
                    double ratio = (double)i / maxCircles;
                    Color circleColor = InterpolateColor(color1, color2, ratio);

                    int diameter = (int)(radius * 2);
                    int topLeftX = centerX - (int)radius;
                    int topLeftY = centerY - (int)radius;

                    using (Brush brush = new SolidBrush(circleColor))
                    {
                        g.FillEllipse(brush, topLeftX, topLeftY, diameter, diameter);
                    }
                }
            }

            return gradientBitmap;
        }

        public static Bitmap CreateCirclesCrazyGradient(Color color1, Color color2, int width, int height, int maxSquares)
        {
            Bitmap gradientBitmap = new Bitmap(width, height);

            int centerX = width / 2;
            int centerY = height / 2;

            double maxDistance = Math.Sqrt(Math.Pow(centerX, 2) + Math.Pow(centerY, 2));

            double stepSize = maxDistance / (maxSquares * 2);

            for (int x = 0; x < width; x++)
            {
                for (int y = 0; y < height; y++)
                {
                    double distance = Math.Sqrt(Math.Pow(x - centerX, 2) + Math.Pow(y - centerY, 2));
                    int rectangleIndex = (int)(distance / stepSize);
                    double adjustedDistance = distance - (rectangleIndex * stepSize);
                    double ratio = adjustedDistance / stepSize;
                    Color interpolatedColor = InterpolateColor(color1, color2, ratio);
                    gradientBitmap.SetPixel(x, y, interpolatedColor);
                }
            }

            return gradientBitmap;
        }

        public static Bitmap CreateSquaresGradient(Color color1, Color color2, int width, int height,int maxSquares)
        {
            Bitmap gradientBitmap = new Bitmap(width, height);

            int centerX = width / 2;
            int centerY = height / 2;

            double maxDistance = Math.Max(centerX, centerY);

            double stepSize = maxDistance / (maxSquares * 2);

            for (int x = 0; x < width; x++)
            {
                for (int y = 0; y < height; y++)
                {
                    int distanceX = Math.Abs(x - centerX);
                    int distanceY = Math.Abs(y - centerY);
                    int rectangleIndex = (int)(Math.Max(distanceX, distanceY) / stepSize);
                    double adjustedDistance = Math.Max(distanceX, distanceY) - (rectangleIndex * stepSize);
                    double ratio = adjustedDistance / stepSize;
                    Color interpolatedColor = InterpolateColor(color1, color2, ratio);
                    gradientBitmap.SetPixel(x, y, interpolatedColor);
                }
            }

            return gradientBitmap;
        }
   
        public static Bitmap CreateSquare90Gradient(Color color1, Color color2, int width, int height,int maxSquares)
        {
            Bitmap gradientBitmap = new Bitmap(width, height);

            int centerX = width / 2;
            int centerY = height / 2;

            double maxDistance = Math.Max(centerX, centerY);

            double stepSize = maxDistance / (maxSquares * 2);

            for (int x = 0; x < width; x++)
            {
                for (int y = 0; y < height; y++)
                {
                    int distanceX = Math.Abs(x - centerX);
                    int distanceY = Math.Abs(y - centerY);
                    int rectangleIndex = (int)(Math.Min(distanceX, distanceY) / stepSize);
                    double adjustedDistance = Math.Min(distanceX, distanceY) - (rectangleIndex * stepSize);
                    double ratio = adjustedDistance / stepSize;
                    Color interpolatedColor = InterpolateColor(color1, color2, ratio);
                    gradientBitmap.SetPixel(x, y, interpolatedColor);
                }
            }

            return gradientBitmap;
        }
       
        public static Bitmap CreateLinesGradient(Color color1, Color color2, int width, int height,int maxSquares)
        {
            Bitmap gradientBitmap = new Bitmap(width, height);

            int centerX = width / 2;
            int centerY = height / 2;

            double maxDistance = Math.Max(centerX, centerY);

            double stepSize = maxDistance / (maxSquares * 2);

            for (int x = 0; x < width; x++)
            {
                for (int y = 0; y < height; y++)
                {
                    int distanceX = Math.Abs(x - centerX);
                    int distanceY = Math.Abs(y - centerY);
                    distanceX = width - distanceX;
                    distanceY = height - distanceY;
                    
                    int rectangleIndex = (int)(Math.Max(distanceX, distanceY) / stepSize);
                    double adjustedDistance = Math.Max(distanceX, distanceY) - (rectangleIndex * stepSize);
                    double ratio = adjustedDistance / stepSize;
                    Color interpolatedColor = InterpolateColor(color1, color2, ratio);
                    gradientBitmap.SetPixel(x, y, interpolatedColor);
                }
            }

            return gradientBitmap;
        }
       

        public static Bitmap CreateDiamondGradient(Color color1, Color color2, int width, int height, int maxSquares)
        {
            Bitmap gradientBitmap = new Bitmap(width, height);

            int centerX = width / 2;
            int centerY = height / 2;

            double maxDistance = Math.Max(centerX, centerY);

            double stepSize = maxDistance / (maxSquares * 2); 

            for (int x = 0; x < width; x++)
            {
                for (int y = 0; y < height; y++)
                {
                    int distanceX = Math.Abs(x - centerX);
                    int distanceY = Math.Abs(y - centerY);

                    int rectangleIndex = (int)(Math.Max(distanceX, distanceY) / stepSize);

                    double adjustedDistance = Math.Max(distanceX, distanceY) - (rectangleIndex * stepSize);

                    double ratio = adjustedDistance / stepSize;

                    bool isUp = (x + y < width / 2 + centerX) && (x - y < width / 2 - centerX) && (y - x < height / 2 - centerY) && (x + y > height / 2 + centerY);

                    if (!isUp)
                        ratio = 1 - ratio;

                    Color interpolatedColor = InterpolateColor(color1, color2, ratio);

                    gradientBitmap.SetPixel(x, y, interpolatedColor);
                }
            }

            return gradientBitmap;
        }



        public static Bitmap CreateCircleGradient(Color color1, Color color2, int width, int height)
        {
            Bitmap gradientBitmap = new Bitmap(width, height);

            double centerX = width / 2.0;
            double centerY = height / 2.0;

            double maxDistance = Math.Sqrt(centerX * centerX + centerY * centerY);

            for (int y = 0; y < height; y++)
            {
                for (int x = 0; x < width; x++)
                {
                    double distanceToCenter = Math.Sqrt((x - centerX) * (x - centerX) + (y - centerY) * (y - centerY));
                    double ratio = Math.Min(distanceToCenter / maxDistance, 1.0); // Ensure ratio does not exceed 1
                    ratio = Math.Pow(ratio, 0.5); // Apply power to make color transition more abrupt near the edges
                    Color blendedColor = InterpolateColor(color1, color2, ratio);

                    gradientBitmap.SetPixel(x, y, blendedColor);
                }
            }

            return gradientBitmap;
        }

        private static Color InterpolateColor(Color color1, Color color2, double ratio)
        {
            int r = Clamp(Interpolate(color1.R, color2.R, ratio), 0, 255);
            int g = Clamp(Interpolate(color1.G, color2.G, ratio), 0, 255);
            int b = Clamp(Interpolate(color1.B, color2.B, ratio), 0, 255);

            return Color.FromArgb(r, g, b);
        }

        private static int Clamp(int value, int min, int max)
        {
            return Math.Min(Math.Max(value, min), max);
        }


        private static int Interpolate(int color1, int color2, double ratio)
        {
            return (int)(color1 * (1 - ratio) + color2 * ratio);
        }


        private void Form_Paint(object sender, PaintEventArgs e)
        {
            FillRectangle(e.Graphics, form.ClientRectangle);
        }

        private void Form_Resize(object sender, EventArgs e)
        {
            UpdateGradient(form.ClientRectangle, startColor, endColor, gradientType, MaxShapes);
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

        public void UpdateGradient(Rectangle rectangle, Color startColor, Color endColor, GradientType gradientType,int MaxShapes)
        {
            this.startColor = startColor;
            this.endColor = endColor;
            this.gradientType = gradientType;
            this.MaxShapes = MaxShapes;

            InitializeGradient(rectangle);
        }
    }
}
