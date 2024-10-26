namespace NewWoT;
using TankEntity;
using LevelEntity;

internal class Program
{
    static void Main(string[] args)
    {
        Tank tank = new("T-103", 200, 100, 300);
        tank.DisplayStatus();
        Level level = new("Malinowka", "Hard");
        level.CompleteLevel();
        
    }
}

