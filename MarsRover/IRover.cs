namespace MarsRover
{
    public interface IRover
    {
        void Move();
        void Turn(char code);
        string Report();
    }
}
