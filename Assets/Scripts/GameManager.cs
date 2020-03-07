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
        //grabs the transforms of both the main camera and player
        cameraTransform = GameObject.Find("Main Camera").GetComponent<Transform>();
        playerTransform = GameObject.Find("Player").GetComponent<Transform>();       
    }

    // Update is called once per frame
    void Update()
    {
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
        TitleBackgroundImage.SetActive(false);
        TitleText.SetActive(false);
        GameStartButton.SetActive(false);
    }
}
