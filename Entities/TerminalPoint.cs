using Definitions;

namespace Entities
{
    public class TerminalPoint
    {
        public XYZ Coordinate { get; set; }  
        public PointType Type { get; set; }
        public TerminalPoint(XYZ coordinate, PointType pointType)
        {
            Coordinate = coordinate;
            Type = pointType;
        }
    }
}