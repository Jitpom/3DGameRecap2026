using UnityEngine;

public class SpawnPoint : MonoBehaviour
{
    void OnDrawGizmos()
    {
        // Draw a small blue sphere at the spawn point for visualization in the editor
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(transform.position, 0.5f);
    }
}
