using UnityEngine;

// keep track of packages
public class Delivery : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Plate")
        {
            Debug.Log("Picked up plate!");
            Destroy(collision.gameObject);
        }
    }
}