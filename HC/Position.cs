using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HC
{
    public class Position
    {
        public Int64 X { get; set; }
        public Int64 Y { get; set; }


        public Int64 Dist(Position point)
        {
            return Math.Abs(X - point.X) + Math.Abs(Y - point.Y);
        }
    }
}
