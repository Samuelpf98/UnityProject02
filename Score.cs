using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    //controls the score of the player after the level is complete
    public GameObject score;
    public GameObject Player;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        int points = 4 - Player.GetComponent<BallMovement>().getScore();
        if(points == 0)
        {
            GameOver();
        }
        
        score.GetComponent<TMPro.TextMeshProUGUI>().text = "Score: " + points + "/3";
    }

    public void GameOver()
    {

    }
}
