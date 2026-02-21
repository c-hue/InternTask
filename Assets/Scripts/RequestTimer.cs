using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;

public class RequestTimer : MonoBehaviour
{
    private int requestNum;
    public float requestTimer;
    private LogicScript logic;
    private Request request;
    void Start()
    {
        logic = GameObject.FindGameObjectWithTag("Logic").GetComponent<LogicScript>();
    }
    void Update ()
    {
        if (logic.gameStarted)
        {
            if (requestTimer >= 0)
            {
                requestTimer -= Time.deltaTime;
            } else
            {
                if (logic.day5)
                {
                    requestTimer = 10f;
                    requestNum = Random.Range(1, 13);
                } else if (logic.day4)
                {
                    requestTimer = 10f;
                    requestNum = Random.Range(1, 12);
                }
                else if (logic.day3)
                {
                    requestTimer = 15f;
                    requestNum = Random.Range(1, 12);
                } else
                {
                    requestTimer = 15f;
                    requestNum = Random.Range(2, 12);
                }
                request = this.transform.GetChild(requestNum).GetComponent<Request>();
                checkRequest();
                request.CreateRequest();
            }
        } else
        {
            requestTimer = 0;
        }
    }

    void checkRequest ()
    {
        int attempts = 0;

        while (request.requestActive && attempts < 20)
        {
            int newNum;

            if (logic.day5)
                newNum = Random.Range(0, 13);
            else if (logic.day4)
                newNum = Random.Range(0, 12);
            else if (logic.day3)
                newNum = Random.Range(0, 12);
            else
                newNum = Random.Range(1, 12);

            request = transform.GetChild(newNum).GetComponent<Request>();
            attempts++;
        }
    }
}