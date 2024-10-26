namespace TankEntity;

public class Tank
{
    public string name { get; set; }
    public int healthPoints { get; set; }
    public int tier { get; set; }
    public int armorFront { get; set; }
    public int firepower { get; set; }


    public Tank(string name, int health, int armor, int firepower)
    {
        this.name = name;
        this.healthPoints = health;
        this.armorFront = armor;
        this.firepower = firepower;
    }

    public void Attack(Tank target)
    {
        if(target.healthPoints > 0)
        {
            Random rand = new Random();

            int baseDamage = (int)(firepower * (rand.Next(70, 101) / 100.0));

            int damage = baseDamage - target.armorFront;
            if (damage < 0) damage = 0;

            target.healthPoints -= damage;
        }
    }

    public void DisplayStatus()
    {
        Console.WriteLine($"Tank: {name}, Health: {healthPoints}, Armor: {armorFront}, Firepower: {firepower}");
    }


}
