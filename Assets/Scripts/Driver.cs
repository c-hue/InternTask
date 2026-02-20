// Player Movement and speed
using UnityEngine;
using UnityEngine.InputSystem;

// boost in driver
public class Driver : MonoBehaviour
{
    [Header("Movement Settings")]
    [SerializeField] float baseSpeed = 7f;
    [SerializeField] float currentSpeed = 7f;
    [SerializeField] float slowSpeed = 3f;
    [SerializeField]  float boostSpeed = 10f;

    [Header("Sprites")]
    [SerializeField] Sprite frontSprite;
    [SerializeField] Sprite backSprite;
    [SerializeField] Sprite leftSprite;
    [SerializeField] Sprite rightSprite;
    private SpriteRenderer sr;
    private LogicScript logic;

    private bool isMoving;
    private bool onHazard;

    void Awake()
    {
        sr = GetComponent<SpriteRenderer>();
    }
    void Start()
    {
        logic = GameObject.FindGameObjectWithTag("Logic").GetComponent<LogicScript>();
    }

    // Update is called once per frame
    void Update()
    {
        if (logic.gameStarted)
        {
            bool isMoving = true;

            // Movement
            if (Keyboard.current.wKey.isPressed)
            {
                transform.Translate(0, currentSpeed * Time.deltaTime, 0);
                sr.sprite = backSprite;
            }
            else if (Keyboard.current.sKey.isPressed)
            {
                transform.Translate(0, -currentSpeed * Time.deltaTime, 0);
                sr.sprite = frontSprite;
            }
            else if (Keyboard.current.aKey.isPressed)
            {
                transform.Translate(-currentSpeed * Time.deltaTime, 0, 0);
                sr.sprite = leftSprite;
            }
            else if (Keyboard.current.dKey.isPressed)
            {
                transform.Translate(currentSpeed * Time.deltaTime, 0,0);
                sr.sprite = rightSprite;
            }
            else
            {
                isMoving = false;
            }

            if (isMoving)
            {
                if (onHazard)
                    AudioManager.instance.PlayLoopSFX("PuddleWalking");
                else
                    AudioManager.instance.PlayLoopSFX("NormalWalking");
            }
            else
            {
                AudioManager.instance.StopSound();
            }
        }
        
    }

    // Hazard Slow / Boost Fast Logic
    void OnTriggerEnter2D(Collider2D collision) 
    {
        if (collision.CompareTag("Hazard"))
        {
            onHazard = true;
            currentSpeed = slowSpeed;
        }

        else if (collision.CompareTag("Boost")) // remove boost after use
        {
            AudioManager.instance.PlaySFX("Boost");
            currentSpeed = boostSpeed;
            Destroy(collision.gameObject);
        }
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Hazard")) // only return to base speed after leaving hazard
        {
            onHazard = false;
            currentSpeed = baseSpeed;
        }
    }

    void OnCollisionEnter2D(Collision2D collision) // only return to base speed after collision
    {
        currentSpeed = baseSpeed;
    }
} 