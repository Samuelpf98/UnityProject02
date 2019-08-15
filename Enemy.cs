using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public GameObject Player;
    public ParticleSystem particlelauncher;
    
    //change the enemy colour when they come into contact with a ball
 
     void Start()
    {
        
       
        

    }

    public void getHit()
    {
        
        Die();
    }

    private void Die()
    {
        FindObjectOfType<SoundManager>().Play("Hit");
        Renderer rend = GetComponent<Renderer>();
        rend.material.shader = Shader.Find("_Color");
        rend.material.SetColor("_Color", Color.cyan);
        Destroy(GetComponent<Enemy>());
        Player.GetComponent<BallMovement>().setHits();
        particlelauncher.Emit(50);
    }
}
