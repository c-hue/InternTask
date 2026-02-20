using UnityEngine;
using UnityEngine.InputSystem;
public class MeetingRequest : MonoBehaviour
{
    private ItemManager itemManager;
    public float createRequestTimer;
    private float deleteRequestTimer;
    public SpriteRenderer itemRequestSprite;
    private SpriteRenderer requestSprite;
    public LogicScript logic;
    void Start()
    {
        logic = GameObject.FindGameObjectWithTag("Logic").GetComponent<LogicScript>();
        if (logic.day3)
        {
            createRequestTimer = Random.Range(5f, 30f);
        }
        itemManager = this.GetComponent<ItemManager>();
        requestSprite = this.GetComponent<SpriteRenderer>();
        itemRequestSprite = this.transform.GetChild(0).GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        if (logic.day3)
        {
            if (createRequestTimer > 0 && deleteRequestTimer == 0)
            {
                createRequestTimer -= Time.deltaTime;
            } else
            {
                CreateRequest();
            }

            if (deleteRequestTimer > 0 && createRequestTimer == 0)
            {
                deleteRequestTimer -= Time.deltaTime;
            } else
            {
                DeleteRequest();
            }
        }
        
    }
    
    void CreateRequest()
    {
        deleteRequestTimer = 20f;
        itemManager.assignRandomItem();
        itemRequestSprite.sprite = itemManager.currentItem.icon;
        requestSprite.enabled = true;
    }

    void DeleteRequest()
    {
        itemRequestSprite.sprite = null;
        requestSprite.enabled = false;
        createRequestTimer = Random.Range(5f, 30f);
    }


    
}