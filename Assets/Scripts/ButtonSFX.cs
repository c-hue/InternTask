using UnityEngine;

public class ButtonSFX : MonoBehaviour
{
    public void playSFX()
    {
        AudioManager.instance.PlaySFX("ButtonClick");
    }
}
