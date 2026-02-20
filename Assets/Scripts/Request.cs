using UnityEngine;
using UnityEngine.InputSystem;
public class Request : MonoBehaviour
{
    private ItemManager itemManager;
    public float createRequestTimer;
    private float deleteRequestTimer;
    private SpriteRenderer itemRequestSprite;
    private SpriteRenderer requestSprite;
    private bool requestActive;
    public LogicScript logic;
    void Start()
    {
        createRequestTimer = Random.Range(5f, 30f);
        itemManager = this.GetComponent<ItemManager>();
        requestSprite = this.GetComponent<SpriteRenderer>();
        itemRequestSprite = this.transform.GetChild(0).GetComponent<SpriteRenderer>();
        logic = GameObject.FindGameObjectWithTag("Logic").GetComponent<LogicScript>();
    }

    void Update()
    {
        if (!requestActive)
        {
            if (createRequestTimer > 0)
            {
                createRequestTimer -= Time.deltaTime;
            } else
            {
                CreateRequest();
            }
        } else
        {
            if (deleteRequestTimer > 0)
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
        requestActive = true;
    }

    void DeleteRequest()
    {
        itemRequestSprite.sprite = null;
        requestSprite.enabled = false;
        createRequestTimer = Random.Range(5f, 30f);
        requestActive = false;
        logic.taskFailed();
    }


    
}