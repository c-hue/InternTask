// Player Movement and speed
using UnityEngine;
using UnityEngine.InputSystem;

// boost in driver
public class Driver : MonoBehaviour
{
    [Header("Movement Settings")]
    [SerializeField] public float baseSpeed = 7f;
    [SerializeField] public float currentSpeed = 7f;
    [SerializeField] public float slowSpeed = 3f;
    [SerializeField] public float boostSpeed = 10f;

    // Update is called once per frame
    void Update()
    {
        // Movement
        if (Keyboard.current.wKey.isPressed)
            transform.Translate(0, currentSpeed * Time.deltaTime, 0);

        else if (Keyboard.current.sKey.isPressed)
            transform.Translate(0, -currentSpeed * Time.deltaTime, 0);

        else if (Keyboard.current.aKey.isPressed)
            transform.Translate(-currentSpeed * Time.deltaTime, 0, 0);

        else if (Keyboard.current.dKey.isPressed)
            transform.Translate(currentSpeed * Time.deltaTime, 0,0);
    }

    // Hazard Slow / Boost Fast Logic
    void OnTriggerEnter2D(Collider2D collision) 
    {
        if (collision.CompareTag("Hazard"))
            currentSpeed = slowSpeed;

        else if (collision.CompareTag("Boost")) // remove boost after use
        {
            currentSpeed = boostSpeed;
            Destroy(collision.gameObject);
        }
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Hazard")) // only return to base speed after leaving hazard
            currentSpeed = baseSpeed;
    }

    void OnCollisionEnter2D(Collision2D collision) // only return to base speed after collision
    {
        currentSpeed = baseSpeed;
    }
} 