using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    // Target to follow
    public Transform target;

    // Distance between the camera and the target
    public float distance = 5.0f;

    // Height of the camera above the target
    public float height = 3.0f;

 
    public float followSpeed = 5.0f;


    public float rotationDamping = 2.0f;

    void LateUpdate()
    {
        if (!target)
        {
            Debug.LogWarning("Target not set for CameraFollow.");
            return;
        }

        
        Vector3 desiredPosition = target.position - target.forward * distance + Vector3.up * height;

        
        transform.position = Vector3.Lerp(transform.position, desiredPosition, Time.deltaTime * followSpeed);
  


        transform.LookAt(target);


   
       

        

    }
}
