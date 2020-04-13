namespace MarsRover
{
    public interface IInterpreter
    {
        int ChangeDirection(int dir, char code);
        (int, int) ChangePosition((int, int) pos, int dir);
        int CorrectX(int x);
        int CorrectY(int y);
        int GetDirection(char dir);
        char GetDirection(int deg);
    }
}
