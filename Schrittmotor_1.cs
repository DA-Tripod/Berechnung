using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Berechnung
{
    class Schrittmotor_1
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
        public int ux { get; set; }
        public int uy { get; set; }

        public double c3 { get; set; }
        public double d { get; set; }
        public double dy { get; set; }
        public double up { get; set; }
        public double alpha { get; set; }
        public double alpha1 { get; set; }
        public double alphaMotor { get; set; }

        private void initialize()
        {
            ox = 0;
            oy = 0;
            ux = 0;
            uy = 0;

            c3 = 0;
            d = 170;
            dy = 0;
            up = 0;
            alpha = 0;
            alpha1 = 0;
            alphaMotor = 0;
        }

        public double S1(double x, double y, double z)
        {

            initialize();

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
    }
}
