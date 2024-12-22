using UnityEngine;
using System.Collections;


public class Slime : Enemy
{
    private float previousTime = 0;

    private float attackSpeed = 1f;
    private int attackDamage = 10;
    
    void Start()
    {
        Debug.Log("Slime start");
        health = 200;
    }
    void Update()
    {
        
    }

    void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (Time.time - previousTime > attackSpeed)
            {

                other.gameObject.GetComponent<PlayerBehavior>().health -= attackDamage;
                // Debug.Log("Player health: " + other.gameObject.GetComponent<PlayerBehavior>().health);
                previousTime = Time.time;
            }
        }
    }

}
