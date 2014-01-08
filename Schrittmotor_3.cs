using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Berechnung
{
    class Schrittmotor_3
    {

        public const double kp = 250;
        public double kp_l { get { return kp; } }
        public const double ap = 80;
        public double ap_l { get { return ap; } }
        public const double o = 250;
        public double o_l { get { return o; } }
        public const double u = 400;
        public double u_l { get { return u; } }

        public int ox { get; set; }
        public int oy { get; set; }

        public int zdraw { get; set; }
        public int dxdraw { get; set; }

        public double c3 { get; set; }
        public double yx { get; set; }
        public double y { get; set; }
        public double d { get; set; }
        public double dx { get; set; }
        public double up { get; set; }
        public double alpha { get; set; }
        public double alpha1 { get; set; }
        public double beta { get; set; }
        public double gamma { get; set; }
        public double alphaMotor { get; set; }

        private void initialize() {

            ox = 0;
            oy = 0;

            c3 = 0;
            yx = 0;
            y = 0;
            d = 170;
            dx = 0;
            up = 0;
            alpha = 0;
            alpha1 = 0;
            beta = 0;
            gamma = 0;
            alphaMotor = 0;
        }
        public double S3(double x, double yy, double z)
        {

            initialize();

            dx = (x / Math.Sin(60 * (Math.PI / 180)));
            d -= dx;

            yx = (x * Math.Sin(30 * (Math.PI / 180))) / Math.Sin(60 * (Math.PI / 180));
            y = yy + yx;
            // Console.WriteLine(" y: " + y + " yx: " + yx + " yy: " + yy);

            beta = Math.Asin((y * Math.Sin(120 * (Math.PI / 180))) / u);
            if (yy >= 0)
            {
                gamma = 60 * (Math.PI / 180) - beta;
            }
            else if (yy < 0)
            {
                gamma = 180 * (Math.PI / 180) - (60 * (Math.PI / 180) - beta);
            }
            if (y >= 0)
            {
                up = (u * Math.Sin(gamma)) / Math.Sin(120 * (Math.PI / 180));
                // Console.WriteLine(" up>0: " + up);
            }
            else if (y < 0)
            {
                up = (u * Math.Sin(120 * (Math.PI / 180)) / Math.Sin(gamma));
                // Console.WriteLine("beta: " + beta * (180 / Math.PI));
                // Console.WriteLine("gamma: " + gamma * (180/Math.PI));
                // Console.WriteLine(" up<0: " + up);
            }

            c3 = Math.Sqrt(Math.Pow(d, 2) + Math.Pow(z, 2));
            alpha = Math.Asin((z / c3));

            if ((d < 0) && (c3 != 0 + up))
            {
                alpha1 = Math.Acos((Math.Pow(o, 2) + Math.Pow(c3, 2) - Math.Pow(up, 2)) / (2 * o * c3));
                alphaMotor = (180 * (Math.PI / 180) - alpha) + alpha1;
            }
            else if ((d < 0) && (c3 == 0 + up))
            {
                alphaMotor = (180 * (Math.PI / 180) - alpha);
            }
            else if ((d > 0) && (c3 != 0 + up))
            {
                alpha1 = Math.Acos((Math.Pow(o, 2) + Math.Pow(c3, 2) - Math.Pow(up, 2)) / (2 * o * c3));
                alphaMotor = alpha + alpha1;
            }
            else if ((d > 0) && (c3 == 0 + up))
            {
                alphaMotor = alpha;
            }
            else if ((d == 0) && (c3 != 0 + up))
            {
                alpha1 = Math.Acos((Math.Pow(o, 2) + Math.Pow(c3, 2) - Math.Pow(up, 2)) / (2 * o * c3));
                alphaMotor = 90 * (Math.PI / 180) + alpha1;
            }
            else if ((d == 0) && (c3 == 0 + up))
            {
                alphaMotor = 90 * (Math.PI / 180);
            }
            // Console.WriteLine("u " + u + " d " + d + " c3 " + c3 + " o " + o + " up " + up + " z " + z + " alpha " + alpha * (180 / Math.PI) + " alpha1 " + alpha1 * (180 / Math.PI) + " gamma " + gamma * (180 / Math.PI) + " beta " + beta * (180 / Math.PI));
            drawValues(z, d);
            return alphaMotor * (180 / Math.PI);
        }

        public void drawValues(double z, double dx)
        {

            if (alphaMotor <= 180 * (Math.PI / 180) && alphaMotor >= 90 * (Math.PI / 180))
            {
                ox = (int)(Math.Sin(alphaMotor - 90 * (Math.PI / 180)) * o / 2);
                oy = (int)(Math.Cos(alphaMotor - 90 * (Math.PI / 180)) * o / 2);
            }
            else if (alphaMotor <= 90 * (Math.PI / 180) && alphaMotor >= 0 * (Math.PI / 180))
            {
                ox = (int)(Math.Sin(alphaMotor) * o / 2);
                oy = -(int)(Math.Cos(alphaMotor) * o / 2);
            }
            else if (alphaMotor <= 270 * (Math.PI / 180) && alphaMotor >= 180 * (Math.PI / 180))
            {
                ox = -(int)(Math.Sin(alphaMotor - 180 * (Math.PI / 180)) * o / 2);
                oy = (int)(Math.Cos(alphaMotor - 180 * (Math.PI / 180)) * o / 2);
            }
            this.zdraw = (int)z / 2;
            this.dxdraw = (int)dx / 2;
        }
    }
}
