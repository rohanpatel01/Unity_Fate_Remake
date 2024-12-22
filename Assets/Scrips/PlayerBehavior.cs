using UnityEngine;
using UnityEngine.AI;
public class PlayerBehavior : MonoBehaviour
{
    public Camera cam;
    // public NavMeshAgent player;
    public GameObject targetDest;

    
    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0)) 
        {
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);
            RaycastHit hitPoint;

            if(Physics.Raycast(ray, out hitPoint))
            {
                targetDest.transform.position = hitPoint.point;
                NavMeshAgent player = GetComponent<NavMeshAgent>();
                player.SetDestination(hitPoint.point);
            }
        }
    }

    void LateUpdate()
    {
        CameraMovement();
    }

    void CameraMovement()
    {
        Vector3 camera_offset = new Vector3(0.355670035f,21.1875229f,-20.8973522f);

        cam.transform.position = transform.position + camera_offset;

    }
}
