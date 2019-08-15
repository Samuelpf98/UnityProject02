using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{

    private float speed =20f;
    public Rigidbody2D rb;
    public ParticleSystem particlelauncher;
    private float interval;
    private int destroyedballs = 0;

    // Start is called before the first frame update
    //set firing speed of ball
    void Start()
    {
        
        rb.velocity = transform.right * speed;
        interval = 4.5f;
    }
    
    void Update()
    {
        //destroy the ball after a certain period of time
        if (interval > 0)
        {
            interval -= Time.deltaTime;
           
        }
        else
        {
            DestroyBall();
            destroyedballs++;

        }
    }

    //when the ball collides with an enemy let them take damage
    void OnTriggerEnter2D(Collider2D collision)
    {
        
       Enemy enemy =  collision.GetComponent<Enemy>();
        if(enemy != null)
        {
            enemy.getHit();
            
        }
    }

    //destroy the ball and set ballno and shots
    private void DestroyBall()
    {
        Instantiate(particlelauncher, transform.position, Quaternion.identity);

        
        Destroy(gameObject);
        GameObject.Find("Player").GetComponent<BallMovement>().setBallNo();
        GameObject.Find("Player").GetComponent<BallMovement>().setshots();


    }
    //get how many balls have been destroyed
    public int getdestroyedballs()
    {
        return destroyedballs;
        
    }

}
