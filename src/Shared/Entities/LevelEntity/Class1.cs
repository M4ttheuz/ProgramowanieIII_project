namespace LevelEntity;

public class Level
{
    public string levelName { get; set; }
    public string difficulty { get; set; }

    public bool isCompleted;

    public Level(string name, string difficulty)
    {
        this.levelName = name;
        this.difficulty = difficulty;
    }

    public void CompleteLevel()
    {
        isCompleted = true;
        Console.WriteLine($"Level {levelName} has been completed!");
    }

}
