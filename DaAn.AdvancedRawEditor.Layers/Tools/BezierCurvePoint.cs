using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DaAn.AdvancedRawEditor.Layers.Tools
{
    public class BezierCurvePoint
    {
        public Point P { get; set; }
        public Point PL { get; set; }
        public Point PP { get; set; }

        public double PLPower { get; set; }
        public double PPPower { get; set; }

        public BezierCurvePoint(Point p, Point pL, Point pP, double pLPower, double pPPower)
        {
            this.P = p;
            this.PL = pL;
            this.PP = pP;
            this.PLPower = pLPower;
            this.PPPower = pPPower;
        }

        public static BezierCurvePoint CreateFull(Point p, Point pL, Point pP, double pLPower, double pPPower)
        {
            return new BezierCurvePoint(p, pL, pP, pLPower, pPPower);
        }
    }
}
