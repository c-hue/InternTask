using UnityEngine;

public enum ItemType
{
    Water, Coffee, Paper, Clipboard, Stapler, PencilHolder, PaperClip, Scissor, Eraser
}

public class Item : MonoBehaviour
{
    public ItemType type;
}