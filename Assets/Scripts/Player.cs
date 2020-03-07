using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private Transform tf;
    public float speed;
    public float turnSpeed;

    public PlayerPawn pawn;
    // Start is called before the first frame update
    void Start()
    {
        tf = GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.UpArrow))
        {
            tf.position += tf.right * speed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            tf.position += -tf.right * speed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            tf.Rotate(0, 0, -turnSpeed);
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            pawn.Turn(1.0f);
        }
    }
}
