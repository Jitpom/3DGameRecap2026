using UnityEngine;

public class MoveObjectWithLerp : MonoBehaviour
{
    public GameObject target; // The target GameObject to move towards
    // Start is called once before the first execution of Update after the MonoBehaviour is created


    // Update is called once per frame
    void Update()
    {
        if (target != null) //Check if the target is not null to avoid errors
        {
            transform.position = Vector3.Lerp(transform.position, target.transform.position, 0.5f);
        }
    }
}
