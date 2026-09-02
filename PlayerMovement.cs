using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
// Controls player movement by applying forces to the attached Rigidbody.
// Uses Unity's default "Horizontal" and "Vertical" input axes (WASD or arrow keys).
public class PlayerMovement : MonoBehaviour
{
    // Force applied each FixedUpdate based on player input (tweak in Inspector)
    [SerializeField] private float moveForce = 10f;
    // Maximum horizontal speed; vertical velocity (gravity/jumps) is preserved
    [SerializeField] private float maxSpeed = 5f;

    // Cached reference to the Rigidbody component used for physics
    private Rigidbody rb;

    // Player health, can be modified by other scripts (e.g., damage system)
    private int health = 100;

    // Cache the Rigidbody reference on Start and warn if missing
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        if (rb == null)
            Debug.LogError("PlayerMovement requires a Rigidbody component.");
    }

    // Use FixedUpdate for physics-driven movement (called at fixed timestep)
    void FixedUpdate()
    {
        // Read input axes: Horizontal = A/D or Left/Right, Vertical = W/S or Up/Down
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");

        // Create movement vector in the XZ plane
        Vector3 input = new Vector3(h, 0f, v);
        // Normalize when magnitude > 1 to prevent faster diagonal movement
        if (input.sqrMagnitude > 1f) input.Normalize();

        // Convert input to a force vector and apply it to the Rigidbody
        Vector3 force = input * moveForce;
        rb.AddForce(force, ForceMode.Force);

        // Clamp horizontal speed to avoid runaway velocity while keeping vertical velocity untouched
        Vector3 horizontalVel = rb.linearVelocity; // get current linear velocity
        horizontalVel.y = 0f; // ignore vertical component for clamping
        if (horizontalVel.magnitude > maxSpeed)
        {
            Vector3 clamped = horizontalVel.normalized * maxSpeed;
            // Apply the clamped horizontal velocity back, preserving the original vertical velocity
            rb.linearVelocity = new Vector3(clamped.x, rb.linearVelocity.y, clamped.z);
        }
    }

    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            // Reduce health by 10 when colliding with an enemy
            health -= 10;
            Debug.Log("Player hit by enemy! Health: " + health);
        }
    }

    void OnTriggerEnter(Collider other)
    {
      if (other.CompareTag("Collectible"))
      {
        Destroy(other.gameObject); // Destroy the collectible object    
      }
    }
}
