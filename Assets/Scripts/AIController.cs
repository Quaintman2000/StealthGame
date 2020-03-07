using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(EnemyPawn))]
public class AIController : Controller
{
    public float fieldOfView = 45;
    //keep track of our transform
    public Transform tf;

    //keep track of of our target location
    public Transform target;

    //track what state the AI is in
    public string AIState = "Idle";

    //track enemy's health
    public float health;

    //track enemy's heal rate per second
    public float restingHealRate = 1.0f;

    //if player is in range or not
    public float attackRange;

    //track health cutoff
    public int healthCutoff;

    //keep track of the movement speed
    private float speed = 5.0f;

    //track enemy's max health
    public float maxHealth;

    public float distanceTowardsPlayer;

    public float angleToTarget;
    // Start is called before the first frame update
    void Start()
    {
        tf = gameObject.GetComponent<Transform>();
        pawn = gameObject.GetComponent<EnemyPawn>();
        AIState = "Idle";
    }

    // Update is called once per frame
    void Update()
    {
        distanceTowardsPlayer = (Vector3.Distance(tf.position, target.position));
        Vector3 vectorToTarget = target.transform.position - tf.position;
         angleToTarget = Vector3.Angle(vectorToTarget, tf.up)+90;
        CanHear(GameManager.instance.Player);
        if (AIState == "Idle")
        {
            //do the state behavior
            Idle();

            //check for transitions
            if (CanHear(GameManager.instance.Player) || CanSee(GameManager.instance.Player))
            {
                ChangeState("Seek");
            }
        }
        else if (AIState == "Rest")
        {
            //do state behavior
            Rest();
            //check for transitions
            if (health >= healthCutoff)
            {
                ChangeState("Idle");
            }
        }
        else if (AIState == "Seek")
        {
            //do state behavior
            Seek();
            //check for transitions
            if (health < healthCutoff)
            {
                ChangeState(("Rest"));
            }

           //// if (Vector3.Distance(tf.position, target.position) < attackRange - 2)
           // {
           //     ChangeState("Attack");
           // }

            if (!CanHear(GameManager.instance.Player) || !CanSee(GameManager.instance.Player))
            {
                ChangeState("Idle");
            }
        }
        else if (AIState == "Attack")
        {

        }
        else
        {
            Debug.LogError("State does not exist:" + AIState);
        }
    }
    public void Idle()
    {
        //do nothing
    }

    public void Rest()
    {
        //stand still
        //heal
        health += restingHealRate * Time.deltaTime;
        health = Mathf.Min(health, maxHealth);
    }

    public void Seek()
    {
        //move toward player
       pawn.Move(1.0f);
       tf.rotation = Quaternion.RotateTowards(tf.rotation,Quaternion.Euler(0,0,Mathf.Atan2(target.transform.position.y -tf.position.y,target.position.x -tf.position.x)*Mathf.Rad2Deg),pawn.turnSpeed*Time.deltaTime );
    }

    public void ChangeState(string newState)
    {
        AIState = newState;
    }

    public bool IsInRange()
    {
        return (Vector3.Distance(tf.position, target.position) <= attackRange);
    }
    public bool CanHear(GameObject target)
    {
        //get noise maker from our target
        NoiseMaker noise = target.GetComponent<NoiseMaker>();
        //if there is a noise maker on our target, we can potentially hear our target
        if (noise != null)
        {
            float adjustedVolumeDistance = noise.volumeDistance - Vector3.Distance(tf.position, target.transform.position);
            //if we're close enough, we hear the noise
            if (adjustedVolumeDistance > 0)
            {
                Debug.Log("I heard the noise!");
                return true;
            }
        }
        return false;
    }

    public bool CanSee(GameObject target)
    {
        Vector3 vectorToTarget = target.transform.position - tf.position;
        //Vector3 rayStart = new Vector3(0,0.47f,0);
        //detect if target is inside FOV
         angleToTarget = Vector3.Angle(vectorToTarget, tf.right);
        if (angleToTarget <= fieldOfView)
        {
            //detect if target is in line of sight
            RaycastHit2D hitinfo = Physics2D.Raycast(tf.position/*+ rayStart*/, target.transform.position - tf.position,attackRange);
            if (hitinfo.collider.gameObject == GameManager.instance.Player)
            {
                Debug.Log("I see u");
                return true;
            }
            
        }
        
            return false;
        
    }
    //if the enemy runs into the player then the player loses
    private void OnCollisionEnter2D(Collision2D otherObject)
    {
        if (otherObject.gameObject == GameManager.instance.Player)
        {
            GameManager.instance.gameState = "Game Over";
        }
    }

}
