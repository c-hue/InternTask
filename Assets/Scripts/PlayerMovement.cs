using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    [Header("Sprites")]
    [SerializeField] Sprite frontSprite;
    [SerializeField] Sprite backSprite;
    [SerializeField] Sprite leftSprite;
    [SerializeField] Sprite rightSprite;

    private SpriteRenderer sr;
    void Awake()
    {
        sr = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        if (Keyboard.current.wKey.isPressed)
            sr.sprite = backSprite;
        else if (Keyboard.current.aKey.isPressed)
            sr.sprite = leftSprite;
        else if (Keyboard.current.sKey.isPressed)
            sr.sprite = frontSprite;
        else if (Keyboard.current.dKey.isPressed)
            sr.sprite = rightSprite;
    }
}
