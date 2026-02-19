using UnityEngine;
public class ItemManager : MonoBehaviour
{
    public ItemType[] items;
    public ItemType currentItem;
    private bool levelOne;
    private bool levelTwo;
    private bool levelThree;

    void Start()
    {
        levelTwo = true;
    }
    public void assignRandomItem()
    {
        if (levelOne)
        {
            int randomIndex = Random.Range(0, 3);
            currentItem = items[randomIndex];
        }

        if (levelTwo)
        {
            int randomIndex = Random.Range(0, 6);
            currentItem = items[randomIndex];
        }

        if (levelThree)
        {
            int randomIndex = Random.Range(0, 9);
            currentItem = items[randomIndex];
        }
    }
}
