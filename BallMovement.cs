using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class BallMovement : MonoBehaviour
{
    //this class controls the shooting of the ball and its movement, along with its attributes
    private int BallNo;
    private int Shots = 0;
    private bool shooting = true;
    private int score;

    public Transform ShootPosition;
    public GameObject BallPrefab;
    private int Hits = 0;
    public GameObject Player;
    public GameObject crosshairs;
    private Vector3 target;



    void Start()
    {
       
        BallNo = 0;
        Cursor.visible = false;
    }

    void Update()
    {
        target = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, transform.position.z));
        crosshairs.transform.position = new Vector2(target.x, target.y);
        Vector3 difference = target - Player.transform.position;
        float rotationz = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;
        Player.transform.rotation = Quaternion.Euler(0.0f, 0.0f, rotationz);

      

        if (shooting == true)
        {
            if (Input.GetMouseButtonDown(0))
            {
                Shoot();
            }


        }

    }

 
   public void Shoot()
    {
        score++;
        string SceneName = "" + SceneManager.GetActiveScene().name;
        if (SceneName == "Main Menu")
        {
            FindObjectOfType<SoundManager>().Play("Shooting");
        }
        if (BallNo == 0)
        {
            BallNo++;
            FindObjectOfType<SoundManager>().Play("Shooting");
            Instantiate(BallPrefab, ShootPosition.position, ShootPosition.rotation);
            
        }
        else if (SceneName == "Main Menu")
        {
            Instantiate(BallPrefab, ShootPosition.position, ShootPosition.rotation);
        }
       
        
    }

    public void setHits()
    {
        Hits++;
    }

    public int getHits()
    {
        return Hits;
    }
    public void setBallNo()
    {
        BallNo = 0;
    }
    public int getScore()
    {
        return score;
    }
  
    public int getShots()
    {
        return Shots;
    }
    public void setshots()
    {
        Shots++;
    }
    public void stopShooting()
    {
        shooting = false;
    }

  
}




























   /* public GameObject Ball;
    private float throwingForce;
    Vector3 StartPosition;

  
    /void OnMouseDown()
    {
        Debug.Log("1");
        StartPosition = transform.position;
    }
    
    void OnMouseDrag()
    {
        transform.position = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 10));
    }

    private void OnMouseUp()
    {
        Ball.GetComponent<Rigidbody2D>().AddForce((StartPosition - transform.position) * Vector3.Distance(transform.position, StartPosition) * throwingForce);
    }
}*/
