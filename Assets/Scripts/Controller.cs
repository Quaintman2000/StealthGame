using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Controller : MonoBehaviour
{
    public Pawn pawn;

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
            pawn.Turn(1.0f);
        }

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            pawn.Turn(-1.0f);
        }
    }
}
