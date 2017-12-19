using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Math;

namespace Ch12Ex03
{
    public class Vector
    {
        public double? R = null;
        public double? Theta = null;
        public double? ThetaRadians
        {
            // Convert degrees to radians.
            get { return (Theta * Math.PI / 180.0); }
        }
        public Vector(double? r, double? theta)
        {
            // Normalize.
            if (r < 0)
            {
                r = -r;
                theta += 180;
            }
            theta = theta % 360;
            // Assign fields.
            R = r;
            Theta = theta;
        }
        public static Vector operator +(Vector op1, Vector op2)
        {
            try
            {
                // Get (x, y) coordinates for new vector.
                double newX = op1.R.Value * Sin(op1.ThetaRadians.Value)
                   + op2.R.Value * Sin(op2.ThetaRadians.Value);
                double newY = op1.R.Value * Cos(op1.ThetaRadians.Value)
                   + op2.R.Value * Cos(op2.ThetaRadians.Value);
                // Convert to (r, theta).
                double newR = Sqrt(newX * newX + newY * newY);
                double newTheta = Atan2(newX, newY) * 180.0 / PI;
                // Return result.
                return new Vector(newR, newTheta);
            }
            catch
            {
                // Return "null" vector.
                return new Vector(null, null);
            }
        }
        public static Vector operator -(Vector op1) => new Vector(-op1.R, op1.Theta);
        public static Vector operator -(Vector op1, Vector op2) => op1 + (-op2);
        public override string ToString()
        {
            // Get string representation of coordinates.
            string rString = R.HasValue ? R.ToString() : "null";
            string thetaString = Theta.HasValue ? Theta.ToString() : "null";
            // Return (r, theta) string.
            return string.Format($"({rString}, {thetaString})");
        }
    }

}
