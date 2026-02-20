using UnityEngine;
public class ItemManager : MonoBehaviour
{
    public ItemType[] items;
    public ItemType currentItem;
    private LogicScript logic;

    void Start()
    {
        logic = GameObject.FindGameObjectWithTag("Logic").GetComponent<LogicScript>();
    }
    public void assignRandomItem()
    {
        if (logic.day5 || logic.day4)
        {
            int randomIndex = Random.Range(0, 9);
            currentItem = items[randomIndex];
        } else if (logic.day3 || logic.day2) 
        {
            int randomIndex = Random.Range(0, 6);
            currentItem = items[randomIndex];
        } else
        {
            int randomIndex = Random.Range(0, 3);
            currentItem = items[randomIndex];
        }
    }
}
