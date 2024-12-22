using System;
using UnityEngine;
using UnityEngine.AI;
public class PlayerBehavior : MonoBehaviour
{
    public Camera cam;
    // public NavMeshAgent player;
    public GameObject targetDest;
    private NavMeshAgent playerNavMeshAgent;
    public int health = 100;
    public float attackRange = 2.5f;
    private float previousTime = 0;
    private float attackSpeed = 0.5f;
    private int attackDamage = 10;
    private bool inRangeOfEnemy = false;

    void Start()
    {
        playerNavMeshAgent = GetComponent<NavMeshAgent>();
        GetComponent<SphereCollider>().radius = attackRange;
    }

    void Update()
    {
        playerMovement();
        attack();
    }

    void LateUpdate()
    {
        Vector3 camera_offset = new Vector3(0.355670035f,21.1875229f,-20.8973522f);
        cam.transform.position = transform.position + camera_offset;
    }

    void playerMovement()
    {
        if (Input.GetMouseButtonDown(0)) 
        {
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);
            RaycastHit hitPoint;

            if(Physics.Raycast(ray, out hitPoint))
            {
                if (hitPoint.collider.tag != "Enemy")
                {
                    targetDest.transform.position = hitPoint.point;
                    playerNavMeshAgent.SetDestination(hitPoint.point);

                } 
                
            }
        } 
        
        Vector3 offsetVector = Vector3.zero;
        float XOffset = 1f;
        float ZOffset = 1f;

        if (Input.GetKey(KeyCode.W)) offsetVector.z += ZOffset;
        if (Input.GetKey(KeyCode.S)) offsetVector.z += -ZOffset;
        if (Input.GetKey(KeyCode.D)) offsetVector.x += XOffset;
        if (Input.GetKey(KeyCode.A)) offsetVector.x += -XOffset;

        if (offsetVector != Vector3.zero)
        {
            targetDest.transform.position = gameObject.transform.position + offsetVector;
            playerNavMeshAgent.SetDestination(targetDest.transform.position);
        }
    }


    void attack()
    {
        if (inRangeOfEnemy)
        {
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);
            RaycastHit rayInfo;

            if(Physics.Raycast(ray, out rayInfo))
            {
                if (rayInfo.collider.tag == "Enemy" && Input.GetMouseButtonDown(0))
                {
                    GameObject enemy = rayInfo.collider.gameObject;

                    if (Time.time - previousTime > attackSpeed)
                    {
                        enemy.gameObject.GetComponent<Enemy>().health -= attackDamage;
                        Debug.Log("Attack enemy: Enemy Health: " + enemy.gameObject.GetComponent<Enemy>().health);

                        previousTime = Time.time;
                    }
                } 
            }
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            inRangeOfEnemy = true;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            inRangeOfEnemy = false;
        }
    }
    
}
