using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Pawn: MonoBehaviour
{
    public float moveSpeed = 5.0f;
    public Transform tf;
    public float health = 100.0f;

    public float speed=1;
    public float turnSpeed=1;
    void Start()
    {
        tf = gameObject.GetComponent<Transform>();
    }
    public virtual void Attack()
    {
        Debug.Log("Pawn Attack");
    }

    public virtual void Move(float direction)
    {
        direction *= speed;
        tf.position += tf.right * speed * Time.deltaTime;
    }
  

    public virtual void Turn(float direction)
    {
        direction *= turnSpeed;
        tf.Rotate(0, 0, direction);
    }

}
