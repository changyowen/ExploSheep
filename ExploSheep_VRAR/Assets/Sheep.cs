using UnityEngine;

public class Sheep : MonoBehaviour
{
    public float health = 10f;

    public void TakeDamge(float amount)
    {
        health -= amount;
        if (Sniper_Script.isHealthySheep)
        {
            if (health <= 0f)
            {
                HealthySheepDie();
            }
        }

        if (Sniper_Script.isInfectedSheep)
        {
            if (health <= 0f)
            {
                InfectedSheepDie();
            }
        }
    }

    void HealthySheepDie()
    {
        Player_Info.playerHealth--;
        Debug.Log("Player Lives: " + Player_Info.playerHealth);
        Destroy(gameObject);
        Sniper_Script.isInfectedSheep = false;
        Sniper_Script.isHealthySheep = false;
    }

    void InfectedSheepDie()
    {
        Destroy(gameObject);
        Sniper_Script.isInfectedSheep = false;
        Sniper_Script.isHealthySheep = false;
    }
}
