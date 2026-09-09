using UnityEngine;

public class EnumObject : MonoBehaviour
{
    public enum State
    {
        Idle,
        Moving,
        Attacking,
        Escaping, 
        Jumping,
    }

    private State currentState;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        currentState = State.Idle; // Set the initial state to Idle
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            currentState = State.Idle;
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            currentState = State.Moving;
        }
        else if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            currentState = State.Attacking;
        }
        else if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            currentState = State.Escaping;
        }
        else if (Input.GetKeyDown(KeyCode.Alpha5))
        {
            currentState = State.Jumping;
        }

        switch (currentState)
        {
            case State.Idle:
                Debug.Log("State: Idle");
                break;
            case State.Moving:
                Debug.Log("State: Moving");
                break;
            case State.Attacking:
                Debug.Log("State: Attacking");
                break;
            case State.Escaping:
                Debug.Log("State: Escaping");
                break;
            case State.Jumping:
                Debug.Log("State: Jumping");
                break;
        }
    }
}
