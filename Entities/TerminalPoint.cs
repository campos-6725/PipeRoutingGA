namespace Entities
{
    public class TerminalPoint
    {
        public XYZ Coordinate { get; set; }  

        public TerminalPoint(XYZ coordinate)
        {
            Coordinate = coordinate;
        }
    }
}