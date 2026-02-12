// Dictates door animation when player walks through them and locked/unlocked feature
using UnityEngine;

public class Door : MonoBehaviour
{
    [Header("Sprites")]
    [SerializeField] private Sprite closedDoor; // horizontal flat-faced door
    [SerializeField] private Sprite openedDoor; // vertical line door

    [Header("Lock")]
    [SerializeField] private bool isLocked = false;
    [SerializeField] private GameObject doorLock; // lock visual when door is locked

    [Header("Settings")]
    [SerializeField] private int requestsRequired = 0; // unlock door after # requests met

    private SpriteRenderer sr;
    private BoxCollider2D col;
    private float closeDelay = 0.01f; // delay after player exits door to close
    private float closeTimer = 0f; // timer before door closes

    private void Awake() 
    {
        sr = GetComponent<SpriteRenderer>();
        col = GetComponent<BoxCollider2D>();

        // all doors are closed and locked
        ApplyLock(); 
    }

    // Update is called once per frame
    void Update()
    {
        if (!isLocked && closeTimer > 0f)
        {
            closeTimer -= Time.deltaTime;
            if (closeTimer <= 0f)
            {
                sr.sprite = closedDoor; // close door
            }
        }
    }

    // when player walks through door
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!isLocked) // Do not open door if locked
            sr.sprite = openedDoor; // open door
    }

    // when player leaves door
    private void OnTriggerExit2D(Collider2D other)
    {
        if (isLocked) return;

        // schedule close delay
        closeTimer = closeDelay;
    }

    public void Unlock()
    {
        isLocked = false;
        ApplyLock();
    }

    public void Lock()
    {
        isLocked = true;
        ApplyLock();
    }

    private void ApplyLock()
    {
        doorLock.SetActive(isLocked);
        col.isTrigger = !isLocked; // enable/disable collision
    }
}
