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

    // Update is called once per frame
    void Update()
    {
        playerMovement();
        attackEnemy();
    }

    void LateUpdate()
    {
        cameraMovement();
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

    void playerIsAttacked()
    {
        
    }

    void cameraMovement()
    {
        Vector3 camera_offset = new Vector3(0.355670035f,21.1875229f,-20.8973522f);
        cam.transform.position = transform.position + camera_offset;
    }
    
    
}