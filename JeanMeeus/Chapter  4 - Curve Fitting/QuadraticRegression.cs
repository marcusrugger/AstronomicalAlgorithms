using System;

namespace JeanMeeus
{
    public class QuadraticRegression
    {
        public readonly double N;
        public readonly double Ex;
        public readonly double Ex2;
        public readonly double Ex3;
        public readonly double Ex4;
        public readonly double Ey;
        public readonly double Exy;
        public readonly double Ex2y;

        private double P => Ex;
        private double Q => Ex2;
        private double R => Ex3;
        private double S => Ex4;
        private double T => Ey;
        private double U => Exy;
        private double V => Ex2y;

        private double D => N*Q*S + 2*P*Q*R - P*P*S - N*R*R;

        public QuadraticRegression(Point[] points)
        {
            N = points.Length;

            foreach (var p in points)
            {
                Ex   += p.x;
                Ex2  += p.x * p.x;
                Ex3  += p.x * p.x * p.x;
                Ex4  += p.x * p.x * p.x * p.x;
                Ey   += p.y;
                Exy  += p.x * p.y;
                Ex2y += p.x * p.x * p.y;
            }
        }

        public double a => (N*Q*V + P*R*T + P*Q*U - Q*Q*T - P*P*V - N*R*U) / D;
        public double b => (N*S*U + P*Q*V + Q*R*T - Q*Q*U - P*S*T - N*R*V) / D;
        public double c => (Q*S*T + Q*R*U + P*R*V - Q*Q*V - P*S*U - R*R*T) / D;

        public double fn(double x) => a*x*x + b*x + c;
    }
}
