using System.Collections.Generic;
using Shapes.Shapes;

namespace Shapes.ShapesComparers
{
    class ShapesPerimeterComparer : IComparer<IShape>
    {
        public int Compare(IShape shape1, IShape shape2)
        {
            return shape1.GetPerimeter().CompareTo(shape2.GetPerimeter());
        }
    }
}