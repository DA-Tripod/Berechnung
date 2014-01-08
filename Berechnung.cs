using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Berechnung
{
    class Berechnung
    {
        private const double kp = 250;
        private const double ap = 80;
        private const double o = 250;
        private const double u = 400;

        public double S1(double x, double y, double z)
        {

            double c3 = 0;
            double d = 170;
            double dy = 0;
            double up = 0;
            double alpha = 0;
            double alpha1 = 0;
            double alphaMotor = 0;

            if (x < 0)
            {
                x -= 2 * x;
            }

            dy = y;
            d -= dy;

            up = Math.Sqrt(Math.Pow(u, 2) - Math.Pow(x, 2));
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
            //Console.WriteLine("up " + up + " d " + d + " c3 " + c3 + " o " + o + " u " + u + " z " + z + " alpha " + alpha * ( 180/Math.PI) + " alpha1 " + alpha1*(180/Math.PI));
            return alphaMotor * (180 / Math.PI);

        }
        public double S2(double x, double yy, double z)
        {
            double c3 = 0;
            double yx = 0;
            double y = 0;
            double d = 170;
            double dx = 0;
            double up = 0;
            double alpha = 0;
            double alpha1 = 0;
            double beta = 0;
            double gamma = 0;
            double alphaMotor = 0;

            dx = (x / Math.Sin(60 * (Math.PI / 180)));
            d += dx;

            yx = -(x * Math.Sin(30 * (Math.PI / 180))) / Math.Sin(60 * (Math.PI / 180));
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
            return alphaMotor * (180 / Math.PI);
        }
        public double S3(double x, double yy, double z)
        {

            double c3 = 0;
            double yx = 0;
            double y = 0;
            double d = 170;
            double dx = 0;
            double up = 0;
            double alpha = 0;
            double alpha1 = 0;
            double beta = 0;
            double gamma = 0;
            double alphaMotor = 0;

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
            return alphaMotor * (180 / Math.PI);
        }
    }
}
