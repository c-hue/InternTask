using UnityEngine;
using UnityEngine.InputSystem;

// keep track of packages
public class Delivery : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "WaterCooler")
        {
            Debug.Log("Picked up plate!");
        }
    }
}