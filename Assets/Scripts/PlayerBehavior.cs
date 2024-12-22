using System;
using UnityEngine;
using UnityEngine.AI;
public class PlayerBehavior : MonoBehaviour
{
    public Camera cam;
    // public NavMeshAgent player;
    public GameObject targetDest;
    private NavMeshAgent playerNavMeshAgent;
    public int health;

    void Start()
    {
        playerNavMeshAgent = GetComponent<NavMeshAgent>();
        health = 100;
    }
    
    void Update()
    {
        playerMovement();
        attackEnemy();
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

                } else 
                {
                    playerNavMeshAgent.SetDestination(transform.position);
                }
                
            }
        } 
        
        Vector3 offsetVector = Vector3.zero;
        float XOffset = 5f;
        float ZOffset = 5f;

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

    void attackEnemy()
    {
        Ray ray = cam.ScreenPointToRay(Input.mousePosition);
        RaycastHit rayInfo;

        if(Physics.Raycast(ray, out rayInfo) && Input.GetMouseButtonDown(0))
        {
            if (rayInfo.collider.tag == "Enemy")
            {
                Debug.Log("Enemy");
            }
        }
    }
    
}
