using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;
using TMPro;


public class LogicScript : MonoBehaviour
{
    public bool day1 = true;
    public bool day2;
    public bool day3;
    public bool day4;
    public bool day5;
    public bool gameStarted;
    public int tasksCompleted;
    public int tasksFailed;
    public float gameTimer;
    [SerializeField] TMP_Text dayText;
    private GameObject startMenu;
    private GameObject player;
    private Door supplyDoor1;
    private Door supplyDoor2;
    private Door meetingDoor;
    private Door bossDoor;
    void Start()
    {
        startMenu = GameObject.FindGameObjectWithTag("Start");
        player = GameObject.FindGameObjectWithTag("Player");
        dayText.text = "Day 1";
        supplyDoor1 = GameObject.Find("SupplyDoor1").GetComponent<Door>();
        supplyDoor2 = GameObject.Find("SupplyDoor2").GetComponent<Door>();
        meetingDoor = GameObject.Find("MeetingDoor").GetComponent<Door>();
        bossDoor = GameObject.Find("BossDoor").GetComponent<Door>();
    }
    void Update()
    {
        if (day5)
        {
            dayText.text = "Day 5";
            bossDoor.Unlock();
        } else if (day4)
        {
            dayText.text = "Day 4";
            supplyDoor2.Unlock();
        } else if (day3)
        {
            dayText.text = "Day 3";
            meetingDoor.Unlock();
        } else if (day2)
        {
            dayText.text = "Day 2";
            supplyDoor1.Unlock();
        } else
        {
            dayText.text = "Day 1";
        }

        if (!gameStarted)
        {
            if (Keyboard.current.spaceKey.wasPressedThisFrame)
            {
                startMenu.SetActive(false);
                setGameTimer();
                tasksFailed = 0;
                gameStarted = true;
            }
        } else
        {
            if (gameTimer > 0)
            {
                gameTimer -= Time.deltaTime;
            }
            
            if (day5)
            {
                if (gameTimer <= 0)
                {
                    winGame();
                }

                if (tasksFailed == 2)
                {
                    loseGame();
                }
            } else if (day4)
            {
                if (gameTimer <= 0)
                {
                    day4 = false;
                    day5 = true;
                    nextDay();
                }

                if (tasksFailed == 4)
                {
                    loseGame();
                }
            } else if (day3)
            {
                if (gameTimer <= 0)
                {
                    day3 = false;
                    day4 = true;
                    nextDay();
                }

                if (tasksFailed == 6)
                {
                    loseGame();
                }
            } else if (day2)
            {
                if (gameTimer <= 0)
                {
                    day2 = false;
                    day3 = true;
                    nextDay();
                }

                if (tasksFailed == 8)
                {
                    loseGame();
                }
            } else
            {
                if (tasksCompleted == 5)
                {
                    day1 = false;
                    day2 = true;
                    nextDay();
                }
            }
        }
    }
    
    public void taskCompleted()
    {
        tasksCompleted += 1;
    }
    public void taskFailed()
    {
        tasksFailed += 1;
    }
    void nextDay()
    {
        gameStarted = false;
        startMenu.SetActive(true);
        tasksCompleted = 0;
        tasksFailed = 0;
        player.transform.position = new Vector2(.29f, -14.62f);
    }
    void setGameTimer()
    {
        if (day2 || day3)
        {
            gameTimer = 180f;
            gameStarted = true;
        }

        if (day4 || day5)
        {
            gameTimer = 150f;
            gameStarted = true;
        }  
    }
    void winGame()
    {
        Debug.Log("YOU WIN");
        SceneManager.LoadScene("Win");
    }
    
    void loseGame()
    {
        Debug.Log("YOU LOSE");
        SceneManager.LoadScene("Lose");
    }
}
