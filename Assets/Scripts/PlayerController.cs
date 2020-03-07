using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerController : Controller
{
    // Start is called before the first frame update
    void Start()
    {
        pawn = FindObjectOfType<PlayerPawn>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.UpArrow))
        {
            //move forward
            pawn.Move(1.0f);
        }

        if (Input.GetKey(KeyCode.DownArrow))
        {
            //move backward
            pawn.Move(-1.0f);
        }

        if (Input.GetKey(KeyCode.RightArrow))
        {
            //turn right
            pawn.Turn(-1.0f);
        }

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            //turn left
            pawn.Turn(1.0f);
        }
    }
   
}

