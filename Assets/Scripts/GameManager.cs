using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public Transform cameraTransform;
    public Transform playerTransform;
  
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
}
