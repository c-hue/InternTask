using UnityEngine;
using UnityEngine.InputSystem;
public class BossRequest : MonoBehaviour
{
    private ItemManager itemManager;
    public float createRequestTimer;
    private float deleteRequestTimer;
    private SpriteRenderer itemRequestSprite;
    private SpriteRenderer requestSprite;
    private bool day5;
    void Start()
    {
        if (day5)
        {
            createRequestTimer = Random.Range(5f, 30f);
        }
        itemManager = this.GetComponent<ItemManager>();
        requestSprite = this.GetComponent<SpriteRenderer>();
        itemRequestSprite = this.transform.GetChild(0).GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        if (day5)
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