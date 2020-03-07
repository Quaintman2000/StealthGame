using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class PlayerPawn : Pawn
{
    
    // Start is called before the first frame update
    void Start()
    {
        Attack();
        tf = GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public override void Attack()
    {
        Debug.Log("Player Attack");
       // base.Attack();
    }
    //if the player hits the exit game object, they win
    private void OnCollisionEnter2D(Collision2D otherObject)
    {
        if (otherObject.gameObject == GameManager.instance.ExitGameObject)
        {
            GameManager.instance.gameState = "Game Win";
        }
    }
}
