﻿using System.Collections;
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
    //if we want movement for the player to be very different
    //We can override our move function
   
}
