using UnityEngine;
using UnityEngine.InputSystem;

// boost in driver
public class Driver : MonoBehaviour
{
    [Header("Movement Settings")]
    [SerializeField] float currentSpeed = 5f;
    [SerializeField] float regSpeed = 3f;
    [SerializeField] float slowSpeed = 2f;
    
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Game has started!");
    }

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

    // Collision Detection
    void OnCollisionEnter2D(Collision2D collision) 
    {
        currentSpeed = slowSpeed;
        if (collision.gameObject.name == "Customer")
            Debug.Log("Hit a customer!");
        else if (collision.gameObject.name == "Chair")
            Debug.Log("Hit a chair!");
    }
} 