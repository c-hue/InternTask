using UnityEngine;
using UnityEngine.InputSystem;
public class Request : MonoBehaviour
{
    private ItemManager itemManager;
    public float deleteRequestTimer;
    private SpriteRenderer itemRequestSprite;
    private SpriteRenderer requestSprite;
    private bool requestActive;
    public LogicScript logic;
    void Start()
    {
        itemManager = this.GetComponent<ItemManager>();
        requestSprite = this.GetComponent<SpriteRenderer>();
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
            requestSprite.enabled = false;
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
        requestSprite.enabled = true;
        requestActive = true;
    }

    void DeleteRequest()
    {
        itemRequestSprite.sprite = null;
        requestSprite.enabled = false;
        logic.taskFailed();
        requestActive = false;
    }


    
}