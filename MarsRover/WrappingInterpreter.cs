namespace MarsRover
{
    /// <summary>
    /// Rover position Interpreter that changes behaviour of BasicInterpreter so
    /// that when Rover reaches the end of Area it appears from the other side
    /// </summary>
    public class WrappingInterpreter : BasicInterpreter
    {
        public WrappingInterpreter(IArea area) : base(area)
        {
        }

        public override int CorrectX(int x)
        {
            return x < _area.MinX ? _area.MaxX : (x > _area.MaxX ? _area.MinX : x);
        }

        public override int CorrectY(int y)
        {
            return y < _area.MinY ? _area.MaxY : (y > _area.MaxY ? _area.MinY : y);
        }
    }
}
