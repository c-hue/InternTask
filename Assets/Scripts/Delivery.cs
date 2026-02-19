using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;

public class Delivery : MonoBehaviour
{
    private bool inPickUpZone;
    private bool inDeliveryZone;
    private bool inTrashZone;
    private bool holdingItem;
    private Item itemType;
    private Item requestType;
    private GameObject request;
    [SerializeField] GameObject item;
    [SerializeField] Sprite coffee;
    [SerializeField] Sprite water;
    [SerializeField] Sprite paper;
    [SerializeField] Sprite clipboard;
    [SerializeField] Sprite stapler;
    [SerializeField] Sprite pencilHolder;
    [SerializeField] Sprite paperclip;
    [SerializeField] Sprite scissor;
    [SerializeField] Sprite eraser;
    

    void Start()
    {
        holdingItem = false;
    }

    void Update()
    {
        if (inPickUpZone)
        {
            if (!holdingItem)
            {
                if (Keyboard.current.spaceKey.wasPressedThisFrame)
                {   
                    holdingItem = true;
                    switch (itemType.type)
                    {
                        case ItemType.Water:
                            item.GetComponent<SpriteRenderer>().sprite = water;
                            break;
                        case ItemType.Paper:
                            item.GetComponent<SpriteRenderer>().sprite = paper;
                            break;
                        case ItemType.Coffee:
                            item.GetComponent<SpriteRenderer>().sprite = coffee;
                            break;
                        case ItemType.Clipboard:
                            item.GetComponent<SpriteRenderer>().sprite = clipboard;
                            break;
                        case ItemType.Stapler:
                            item.GetComponent<SpriteRenderer>().sprite = stapler;
                            break;
                        case ItemType.PencilHolder:
                            item.GetComponent<SpriteRenderer>().sprite = pencilHolder;
                            break;
                        case ItemType.PaperClip:
                            item.GetComponent<SpriteRenderer>().sprite = paperclip;
                            break;
                        case ItemType.Scissor:
                            item.GetComponent<SpriteRenderer>().sprite = scissor;
                            break;
                        case ItemType.Eraser:
                            item.GetComponent<SpriteRenderer>().sprite = eraser;
                            break;
                    }
                    Debug.Log(itemType.type);
                    this.item.SetActive(true);
                }
            }
        } 
        if (inDeliveryZone)
        {
            if (holdingItem)
            {
                if (Keyboard.current.spaceKey.wasPressedThisFrame)
                {
                    if (itemType.type == requestType.type)
                    {
                        Debug.Log("drop item");
                        holdingItem = false;
                        itemType = null;
                        this.item.SetActive(false);
                        requestType.type = ItemType.Null;
                        this.request.SetActive(false);
                        Debug.Log("Delivery Made");
                    }
                    
                }
            }
            
        }
        if (inTrashZone)
        {
            if(holdingItem)
            {
                if (Keyboard.current.spaceKey.wasPressedThisFrame)
                {
                    Debug.Log("trash item");
                    holdingItem = false;
                    itemType = null;
                    this.item.SetActive(false);
                }
            }
        }
    }
    
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "PickUpZone")
        {
            Debug.Log("In PickUpZone");
            inPickUpZone = true;
            if (!holdingItem)
            {
                itemType = collision.gameObject.GetComponent<Item>();
            }
        }

        if (collision.gameObject.tag == "DeliveryZone")
        {
            Debug.Log("In DeliveryZone");
            inDeliveryZone = true;
            requestType = collision.gameObject.GetComponent<Item>();
            request = collision.gameObject;
            Debug.Log("Requesting: " + requestType.type);
        }

        if (collision.gameObject.tag == "TrashZone")
        {
            Debug.Log("In TrashZone");
            inTrashZone = true;
        }
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "PickUpZone")
        {
            Debug.Log("Not in PickUpZone");
            inPickUpZone = false;
        }

        if (collision.gameObject.tag == "DeliveryZone")
        {
            Debug.Log("Not in Delivery");
            inDeliveryZone = false;
            request = null;
        }

        if (collision.gameObject.tag == "TrashZone")
        {
            inTrashZone = false;
        }
            
    }
}

