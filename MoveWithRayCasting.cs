using UnityEngine;

public class MoveWithRayCasting : MonoBehaviour
{    
    private Vector3 point; // The point to move towards
    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0)) // Check if the left mouse button is clicked
        {            
            Ray shootingRay = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hitPoint;
            Physics.Raycast(shootingRay, out hitPoint);
            point = hitPoint.point; // Store the point where the raycast hit
        }

        if (point != Vector3.zero) // Check if the point is not zero    
        {
            MoveToPoint(point); // Move the object towards the 
            Debug.Log("Moving towards point: " + point); // Log the point position for debugging
        }
    }

    private void MoveToPoint(Vector3 point)
    {
        transform.position = Vector3.Lerp(transform.position, new Vector3(point.x, transform.position.y, point.z), 0.5f * Time.deltaTime); // Move the object towards the point using Lerp
    }
}
