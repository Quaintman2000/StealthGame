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
            pawn.Move(1.0f);
        }

        if (Input.GetKey(KeyCode.DownArrow))
        {
            pawn.Move(-1.0f);
        }

        if (Input.GetKey(KeyCode.RightArrow))
        {
            pawn.Turn(-1.0f);
        }

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            pawn.Turn(1.0f);
        }
    }
}

