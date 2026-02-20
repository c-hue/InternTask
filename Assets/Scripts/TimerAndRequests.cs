using UnityEngine;
using TMPro;

public class TimerAndRequests : MonoBehaviour
{
    [SerializeField] TMP_Text TimerText;
    [SerializeField] TMP_Text CheckText;
    [SerializeField] TMP_Text XText;
    private LogicScript logic;
    void Start()
    {
        logic = GameObject.FindGameObjectWithTag("Logic").GetComponent<LogicScript>();
        this.transform.GetChild(0).gameObject.SetActive(false);
    }
    void Update()
    {
        TimerText.text = Mathf.CeilToInt(logic.gameTimer).ToString();
        CheckText.text = logic.tasksCompleted.ToString();
        XText.text = logic.tasksFailed.ToString();

        if (logic.gameStarted)
        {
            this.transform.GetChild(0).gameObject.SetActive(true);
        } else
        {
            this.transform.GetChild(0).gameObject.SetActive(false);
        }

    }
}
