using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public Transform cameraTransform;
    public Transform playerTransform;

    public static GameManager instance;
    public GameObject TitleBackgroundImage;

    public GameObject TitleText;

    public GameObject GameStartButton;

    public GameObject Player;
    public GameObject tryAgainButton;
    public GameObject QuitButton;
    public GameObject YouLoseText;
    public GameObject YouWinText;
    public GameObject ExitGameObject;
    public GameObject StartSpotGameObject;
    public GameObject EnemyGameObject;
    public GameObject EnemeyStartSpotGameObject;
    public string gameState;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(this.gameObject);
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        gameState = "StartScreen";
        //grabs the transforms of both the main camera and player
        cameraTransform = GameObject.Find("Main Camera").GetComponent<Transform>();
        playerTransform = GameObject.Find("Player").GetComponent<Transform>();       
    }

    // Update is called once per frame
    void Update()
    {
        //check states
        Debug.Log(gameState);
        if (gameState == "StartScreen")
        {
            //act on state
            StartScreen();
        }

       else  if (gameState == "Game Over")
        {
            //act on state
            GameOverScreen();
        }

       else if (gameState == "Game Win")
        {
            //act on state
            YouWinScreen();
        }

       else if (gameState=="Game Running")
        {
            //do nothing
           
        }
        else
        {
            //if no state
            Debug.LogError("Unidentified game state"+gameState);
        }
        //hit escape to quit
        if (Input.GetKey(KeyCode.Escape))
        {
            Quit();
        }
        //makes the camera move along with the player
        cameraTransform.position = new Vector3(playerTransform.position.x, playerTransform.position.y, 
            cameraTransform.position.z);

    }

    public void Quit()
    {
        Application.Quit();
    }

    public void StartGame()
    {
       
        //closes UI
        TitleBackgroundImage.SetActive(false);
        TitleText.SetActive(false);
        YouLoseText.SetActive(false);
        YouWinText.SetActive(false);
        GameStartButton.SetActive(false);
        tryAgainButton.SetActive(false);
        QuitButton.SetActive(false);
        //change state
        gameState = "Game Running";
    }

    public void StartScreen()
    {
        //sets player at start
        playerTransform.position = StartSpotGameObject.transform.position;
        //sets enemy at start
        EnemyGameObject.transform.position = EnemeyStartSpotGameObject.transform.position;
        //opens startscreen UI
        TitleBackgroundImage.SetActive(true);
        TitleText.SetActive(true);
        YouLoseText.SetActive(false);
        YouWinText.SetActive(false);
        GameStartButton.SetActive(true);
        tryAgainButton.SetActive(false);
        QuitButton.SetActive(true);
        //sets game state
        gameState = "StartScreen";
    }

    public void GameOverScreen()
    {
        //open game over ui
        TitleBackgroundImage.SetActive(true);
        TitleText.SetActive(false);
        YouLoseText.SetActive(true);
        YouWinText.SetActive(false);
        GameStartButton.SetActive(false);
        tryAgainButton.SetActive(true);
        QuitButton.SetActive(true);
        //sets game state
        gameState = "Game Over";
    }

    public void YouWinScreen()
    {
        //open you win ui
        TitleBackgroundImage.SetActive(true);
        TitleText.SetActive(false);
        YouLoseText.SetActive(false);
        YouWinText.SetActive(true);
        GameStartButton.SetActive(false);
        tryAgainButton.SetActive(true);
        QuitButton.SetActive(true);
        //sets game state
        gameState = "Game Win";
    }

   
}
