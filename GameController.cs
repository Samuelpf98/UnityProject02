using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;
public class GameController : MonoBehaviour
{

    public GameObject Player;
    public GameObject UI;
    public GameObject LoseUI;
    private string currentScene;
    private int soundPlayed = 0;

    //this class controls the levels and win/lose staes

    // Start is called before the first frame update
    void Start()
    {
        UI.SetActive(false);
        LoseUI.SetActive(false);

    }

    // Update is called once per frame
    void Update()
    {
        currentScene = SceneManager.GetActiveScene().name;
        Debug.Log(currentScene);
        if (Player.GetComponent<BallMovement>().getHits() == 3)
        {
            if (soundPlayed == 0) { 
            FindObjectOfType<SoundManager>().Play("Win");
        }
            soundPlayed = 1;
            WinLevel();
           
        }

        if (Player.GetComponent<BallMovement>().getShots() == 3&& Player.GetComponent<BallMovement>().getHits() != 3&&currentScene!="Main Menu")
        {
            if (soundPlayed == 0)
            {
                FindObjectOfType<SoundManager>().Play("Lose");
            }
            soundPlayed = 1;
            
            LoseLevel();
        }

        if (isMouseOverUI()==true && isMouseOverUIWithIgnores() ==true)
        {
            Cursor.visible = true;
        }
        else
        {
            Cursor.visible = false;
        }
       
    }

    public void WinLevel()
    {
        UI.SetActive(true);
        Player.GetComponent<BallMovement>().stopShooting();

    }
    public void Restart()
    {
        string SceneName = "" + SceneManager.GetActiveScene().name;
            SceneManager.LoadScene(SceneName);
       
        
    }
    private bool isMouseOverUI()
    {
        return EventSystem.current.IsPointerOverGameObject();
    }
    private bool isMouseOverUIWithIgnores()
    {
        PointerEventData pointerEventData = new PointerEventData(EventSystem.current);
        pointerEventData.position = Input.mousePosition;

        List<RaycastResult> raycastResultList = new List<RaycastResult>();
        EventSystem.current.RaycastAll(pointerEventData, raycastResultList);
        for (int i = 0; i < raycastResultList.Count; i++)
        {
            if (raycastResultList[i].gameObject.GetComponent<MouseUIClickThrough>() != null)
            {
                raycastResultList.RemoveAt(i);
                i--;
            }
        }
        return raycastResultList.Count > 0;
    }

    public void NextLevel()
    {
        if (currentScene == "SampleScene")
        {
            SceneManager.LoadScene("Level02");
        }
        else if (currentScene == "Level02")
        {
            SceneManager.LoadScene("Level03");
        }
    }
    public void LoseLevel()
    {
        LoseUI.SetActive(true);
        Cursor.visible = true;
       
        Player.GetComponent<BallMovement>().stopShooting();
        //Destroy(GameObject.Find("LosePanel").GetComponent<MouseUIClickThrough>());
    }

    public void QuitLevel()
    {
        SceneManager.LoadScene("Main Menu");
    }
    public void RestartGame()
    {
        SceneManager.LoadScene("SampleScene");
    }
}
