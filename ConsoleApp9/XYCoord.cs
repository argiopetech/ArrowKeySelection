using System;

namespace ConsoleApp9
{
    internal class XYCoord
    {
        private int x;
        private int y;

        public XYCoord(int x, int y)
        {
            this.x = x;
            this.y = y;
        }

        internal double DistanceTo(XYCoord dest)
        {
            var left = Math.Pow(this.x - dest.x, 2);
            var right = Math.Pow(this.y - dest.y, 2);

            return Math.Sqrt(left + right);
        }
    }
}