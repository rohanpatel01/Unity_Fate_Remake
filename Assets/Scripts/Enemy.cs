using UnityEngine;

public abstract class Enemy : MonoBehaviour
{

    public string enemyName;
    private int health = 100;

    // Add more enemy traits later on
    
    // public abstract void attack();

    public void setHealth(int health)
    {
        this.health = health; 
    }

    public void takeDamage(int damage)
    {
        health -= damage;
        Debug.Log("Health: " + health);
    }

}
