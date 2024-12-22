using UnityEngine;

public abstract class Enemy : MonoBehaviour
{

    public string enemyName;
    public int health;

    // Add more enemy traits later on
    
    // public abstract void attack();

    // public virtual void takeDamage(int damage)
    // {
    //     health -= damage;
    //     Debug.Log("Health: " + health);
    // }

}
