using UnityEngine;
using UnityEngine.InputSystem;
public class Request : MonoBehaviour
{
    private ItemManager itemManager;
    public float deleteRequestTimer;
    private SpriteRenderer itemRequestSprite;    
    private SpriteRenderer chatSprite;
    private bool requestActive;
    private LogicScript logic;
    [SerializeField] Sprite greenChat;
    [SerializeField] Sprite redChat;
    [SerializeField] Sprite orangeChat;
    void Start()
    {
        itemManager = this.GetComponent<ItemManager>();     
        chatSprite = this.GetComponent<SpriteRenderer>();   
        itemRequestSprite = this.transform.GetChild(0).GetComponent<SpriteRenderer>();
        logic = GameObject.FindGameObjectWithTag("Logic").GetComponent<LogicScript>();
    }

    void Update()
    {
        if (logic.gameStarted)
        {
                if (deleteRequestTimer > 0)
                {
                    deleteRequestTimer -= Time.deltaTime;
                    if (deleteRequestTimer <= 10) {
                        chatSprite.sprite = redChat;
                    } else if (deleteRequestTimer <= 20)
                    {
                        chatSprite.sprite = orangeChat;
                    }
                    else
                        chatSprite.sprite = greenChat;
                } else
                {
                    if (!logic.day1 && requestActive)
                    {
                        DeleteRequest();
                    }
                    
                }
        } else
        {
            itemRequestSprite.sprite = null;
            this.gameObject.SetActive(false);
            requestActive = false;
        }
        
    }
    
    public void CreateRequest()
    {
        if (logic.day5)
        {
            deleteRequestTimer = 25f;
        } else if (logic.day4) {
            deleteRequestTimer = 30f;
        } else if (logic.day3)
        {
            deleteRequestTimer = 35f;
        } else
        {
            deleteRequestTimer = 40f;
        } 
        itemManager.assignRandomItem();
        itemRequestSprite.sprite = itemManager.currentItem.icon;
        this.gameObject.SetActive(true);
        requestActive = true;
    }

    void DeleteRequest()
    {
        itemRequestSprite.sprite = null;
        this.gameObject.SetActive(false);
        logic.taskFailed();
        requestActive = false;
    }


    
}