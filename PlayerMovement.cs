using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    //Player movement to move and control the box
    private float speed = 10f;
    private Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
       
            
            if (Input.GetKey(KeyCode.A))
                rb.AddForce(Vector3.left*speed);
            if (Input.GetKey(KeyCode.D))
                rb.AddForce(Vector3.right*speed);

        
    }
}
