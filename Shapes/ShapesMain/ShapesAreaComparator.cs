using System.Collections.Generic;
using Shapes.Shapes;

namespace Shapes.ShapesMain
{
    class ShapesAreaComparator : IComparer<IShape>
    {
        public int Compare(IShape x, IShape y)
        {
            return y.GetArea().CompareTo(x.GetArea());
        }
    }
}