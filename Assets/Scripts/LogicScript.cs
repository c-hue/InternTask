using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;


public class LogicScript : MonoBehaviour
{
    public bool day1 = true;
    public bool day2;
    public bool day3;
    public bool day4;
    public bool day5;
    public bool day1Completed;
    public bool day2Completed;
    public bool day3Completed;
    public bool day4Completed;
    public bool day5Completed;
    public bool gameStarted;
    public int tasksCompleted;
    public int tasksFailed;
    public float gameTimer;

    void Start()
    {
        if (!gameStarted)
        {
            if (day2 && !day2Completed || day3 && !day3Completed)
            {
                gameTimer = 180f;
                gameStarted = true;
            }

            if (day4 && !day4Completed || day5 && !day5Completed)
            {
                gameTimer = 150f;
                gameStarted = true;
            }     
        }
        
    }
    void Update()
    {
        if (gameTimer > 0)
        {
            gameTimer -= Time.deltaTime;
        }

        if (Keyboard.current.fKey.wasPressedThisFrame)
        {
            gameStarted = true;
        }

        if (gameStarted)
        {
            if (day1 && !day1Completed)
            {
                if (tasksCompleted == 5)
                {
                    tasksCompleted = 0;
                    tasksFailed = 0;
                    day1Completed = true;
                    day2 = true;
                    gameStarted = false;
                    nextDay();
                }
            }

            if (day2 && !day2Completed)
            {
                if (gameTimer <= 0)
                {
                    tasksCompleted = 0;
                    tasksFailed = 0;
                    day2Completed = true;
                    day3 = true;
                    gameStarted = false;
                    nextDay();
                }

                if (tasksFailed == 8 || gameTimer == 0)
                {
                    loseGame();
                }
            }
            
            if (day3 && !day3Completed)
            {
                if (gameTimer <= 0)
                {
                    tasksCompleted = 0;
                    tasksFailed = 0;
                    day3Completed = true;
                    day4 = true;
                    gameStarted = false;
                    nextDay();
                }

                if (tasksFailed == 6)
                {
                    loseGame();
                }
            }

            if (day4 && !day4Completed)
            {
                if (gameTimer <= 0)
                {
                    tasksCompleted = 0;
                    tasksFailed = 0;
                    day4Completed = true;
                    day5 = true;
                    gameStarted = false;
                    nextDay();
                }

                if (tasksFailed == 4)
                {
                    loseGame();
                }
            }
            
            if (day5 && !day5Completed)
            {
                if (gameTimer <= 0)
                {
                    tasksCompleted = 0;
                    tasksFailed = 0;
                    winGame();
                }

                if (tasksFailed == 2)
                {
                    loseGame();
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
        SceneManager.LoadScene("Gameplay 1");
    }
    void winGame()
    {
        Debug.Log("YOU WIN");
        Scenemanager.LoadScene("Win");
    }
    
    void loseGame()
    {
        Debug.Log("YOU LOSE");
        SceneManager.LoadScene("Lose");
    }
}
