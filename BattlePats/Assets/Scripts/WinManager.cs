using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class WinManager : MonoBehaviour
{
    public int activePlayers = 0;
    public bool gameStart = false;
    public float GameTime = 300;

    public float timer;

    private GameObject winner;

    public GameObject startingUI;
    public GameObject timerUI;
    public GameObject endUI;

    public Text resultsText;
    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 0;
        timer = GameTime;
    }

    public void StartButton()
    {
        Time.timeScale = 1;
        gameStart = true;
        startingUI.SetActive(false);
        Destroy(PlayerInputManager.instance);
    }

    // Update is called once per frame
    void Update()
    {
        timerUI.GetComponent<Text>().text = "Seconds Left: " + Mathf.RoundToInt(timer);

        timer -= Time.deltaTime;
        
        if (timer == 0 || (activePlayers == 1 && gameStart))
        {
            FindWinner();
            
            
            Time.timeScale = 0;
            endUI.SetActive(true);
            resultsText.text = "The Butter Royale is over! \n Butter " +
                               (winner.GetComponent<PlayerControls>().playerID + 1) + " Wins! \n They had " +
                               winner.GetComponent<PlayerControls>().score + " seconds in the hotspot," +
                               " and weren't dead!";
        }
    }

    public void FindWinner()
    {
        GameObject[] players = GameObject.FindGameObjectsWithTag("Player");

        for (int i = 0; i < players.Length; i++)
        {
            if (i == 0)
            {
                winner = players[i];
            }
            if (players[i].GetComponent<PlayerControls>().score > winner.GetComponent<PlayerControls>().score &&
                players[i].GetComponent<PlayerControls>().lives > 0) //If the player has more score than the current winning player and isn't dead
            {
                winner = players[i];
            }
        }
    }
}
