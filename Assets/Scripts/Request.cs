using UnityEngine;
using UnityEngine.InputSystem;
public class Request : MonoBehaviour
{
    [SerializeField] GameObject request;
    [SerializeField] Sprite coffee;
    [SerializeField] Sprite water;
    [SerializeField] Sprite paper;
    [SerializeField] Sprite clipboard;
    [SerializeField] Sprite stapler;
    [SerializeField] Sprite pencilHolder;
    [SerializeField] Sprite paperclip;
    [SerializeField] Sprite scissor;
    [SerializeField] Sprite eraser;
    private int item;
    private int delivery;
    private float requestTimer = 10f;
    
    string[] items = {
        "Water", "Coffee", "Paper", "Clipboard", "Stapler", "PencilHolder", "Paperclip", "Scissor"
        , "Eraser"
    };

    void Start()
    {
        
    }

    void Update()
    {
        if (requestTimer > 0)
        {
            requestTimer -= Time.deltaTime;
        } else
        {
            CreateRequest();
            requestTimer = 10f;
        }
    }
    
    void CreateRequest()
    {
        item = Random.Range(0, items.Length);
        delivery = Random.Range(0, 13);
        Debug.Log(item);
        Debug.Log(delivery);
        if (request.transform.GetChild(delivery).gameObject.activeSelf == true)
        {
            CreateRequest();
        } else
        {
            request.transform.GetChild(delivery).gameObject.SetActive(true);
            Debug.Log(request.transform.GetChild(delivery).GetComponent<Item>().type);
            switch (items[item])
            {
                case "Water":
                    request.transform.GetChild(delivery).transform.GetChild(0).GetComponent<SpriteRenderer>().sprite = water;
                    request.transform.GetChild(delivery).GetComponent<Item>().type = ItemType.Water;
                    break;
                case "Coffee":
                    request.transform.GetChild(delivery).transform.GetChild(0).GetComponent<SpriteRenderer>().sprite = coffee;
                    request.transform.GetChild(delivery).GetComponent<Item>().type = ItemType.Coffee;
                    break;
                case "Paper":
                    request.transform.GetChild(delivery).transform.GetChild(0).GetComponent<SpriteRenderer>().sprite = paper;
                    request.transform.GetChild(delivery).GetComponent<Item>().type = ItemType.Paper;                    
                    break;
                case "Clipboard":
                    request.transform.GetChild(delivery).transform.GetChild(0).GetComponent<SpriteRenderer>().sprite = clipboard;
                    request.transform.GetChild(delivery).GetComponent<Item>().type = ItemType.Clipboard;                    
                    break;
                case "Stapler":
                    request.transform.GetChild(delivery).transform.GetChild(0).GetComponent<SpriteRenderer>().sprite = stapler;
                    request.transform.GetChild(delivery).GetComponent<Item>().type = ItemType.Stapler;                    
                    break;
                case "PencilHolder":
                    request.transform.GetChild(delivery).transform.GetChild(0).GetComponent<SpriteRenderer>().sprite = pencilHolder;
                    request.transform.GetChild(delivery).GetComponent<Item>().type = ItemType.PencilHolder;
                    break;
                case "Paperclip":
                    request.transform.GetChild(delivery).transform.GetChild(0).GetComponent<SpriteRenderer>().sprite = paperclip;
                    request.transform.GetChild(delivery).GetComponent<Item>().type = ItemType.PaperClip;
                    break;
                case "Scissor":
                    request.transform.GetChild(delivery).transform.GetChild(0).GetComponent<SpriteRenderer>().sprite = scissor;
                    request.transform.GetChild(delivery).GetComponent<Item>().type = ItemType.Scissor;
                    break;
                case "Eraser":
                    request.transform.GetChild(delivery).transform.GetChild(0).GetComponent<SpriteRenderer>().sprite = eraser;
                    request.transform.GetChild(delivery).GetComponent<Item>().type = ItemType.Eraser;
                    break;
            }
            Debug.Log(request.transform.GetChild(delivery).GetComponent<Item>().type);
        }
    }


    
}