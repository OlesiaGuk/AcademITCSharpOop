using System.Collections.Generic;
using Shapes.Shapes;

namespace Shapes.ShapesMain
{
    class ShapesPerimeterComparator : IComparer<IShape>
    {
        public int Compare(IShape x, IShape y)
        {
            return y.GetPerimeter().CompareTo(x.GetPerimeter());
        }
    }
}