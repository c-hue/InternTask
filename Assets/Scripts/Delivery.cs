using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;

public class Delivery : MonoBehaviour
{
    private bool holdingItem;
    private bool inPickUpZone;
    private bool inDeliveryZone;
    private bool inTrashZone;
    string itemHeld;
    string requestItem;
    private GameObject itemHolder;
    private GameObject request;
    private SpriteRenderer itemRenderer;
    void Start()
    {
        itemRenderer = this.transform.GetChild(0).GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        if (inPickUpZone)
        {
            if (!holdingItem) {
                ItemType playerItem;
                if (Keyboard.current.spaceKey.wasPressedThisFrame)
                {
                    playerItem = itemHolder.GetComponent<ItemHolder>().item;
                    itemHeld = playerItem.itemName;
                    itemRenderer.sprite = playerItem.icon;
                    itemRenderer.enabled = true;
                    Debug.Log("Picked up " + playerItem.itemName);
                    holdingItem = true;
                }
            }
        }

        if (holdingItem)
        {
            if (inDeliveryZone)
            {
                if (Keyboard.current.spaceKey.wasPressedThisFrame)
                {
                    if (requestItem == itemHeld)
                    {
                        holdingItem = false;
                        itemHeld = "";
                        itemRenderer.sprite = null;
                        itemRenderer.enabled = true;
                        request.GetComponent<SpriteRenderer>().enabled = false;
                        request.transform.GetChild(0).GetComponent<SpriteRenderer>().sprite = null;
                        request.GetComponent<Request>().createRequestTimer = Random.Range(5f, 30f);
                        Debug.Log("Delivery Made");
                    }
                    
                }
            }
            if (inTrashZone)
            {
                if (Keyboard.current.spaceKey.wasPressedThisFrame)
                {
                    holdingItem = false;
                    itemHeld = "";
                    itemRenderer.sprite = null;
                    itemRenderer.enabled = true; ;
                }
            }
        }
    }
    
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "PickUpZone")
        {
            inPickUpZone = true;
            itemHolder = collision.gameObject;
        }

        if (collision.gameObject.tag == "DeliveryZone")
        {
            Debug.Log("In DeliveryZone");
            request = collision.gameObject;
            requestItem = request.GetComponent<ItemManager>().currentItem.itemName;
            inDeliveryZone = true;
        }

        if (collision.gameObject.tag == "TrashZone")
        {
            inTrashZone = true;
        }
    }

    void OnTriggerExit2D(Collider2D collision)
    {

        if (collision.gameObject.tag == "PickUpZone")
        {
            inPickUpZone = false;
        }

        if (collision.gameObject.tag == "DeliveryZone")
        {
            inDeliveryZone = false;
        }

        if (collision.gameObject.tag == "TrashZone")
        {
            inTrashZone = false;
        }
    }

}

