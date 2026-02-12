// Player Movement and speed
using UnityEngine;
using UnityEngine.InputSystem;

// boost in driver
public class Driver : MonoBehaviour
{
    [Header("Movement Settings")]
    [SerializeField] public float baseSpeed = 7f;
    [SerializeField] public float slowMultiplier = 0.4f;
    [SerializeField] public float boostMultiplier = 1.5f;

    // Update is called once per frame
    void Update()
    {
        // Movement
        if (Keyboard.current.wKey.isPressed)
            transform.Translate(0, baseSpeed * Time.deltaTime, 0);

        else if (Keyboard.current.sKey.isPressed)
            transform.Translate(0, -baseSpeed * Time.deltaTime, 0);

        else if (Keyboard.current.aKey.isPressed)
            transform.Translate(-baseSpeed * Time.deltaTime, 0, 0);

        else if (Keyboard.current.dKey.isPressed)
            transform.Translate(baseSpeed * Time.deltaTime, 0,0);
    }

    // Hazard Slow Logic
    void OnTriggerEnter2D(Collider2D hazard) 
    {
        if (!hazard.CompareTag("Hazard")) return;
        baseSpeed *= slowMultiplier;
    }

    void OnTriggerExit2D(Collider2D hazard)
    {
        if (!hazard.CompareTag("Hazard")) return;
        baseSpeed /= slowMultiplier;
    }
} 