using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
public class PlayerSpawnManager : MonoBehaviour
{
    public Transform[] spawnPoints;
    public WinManager WM;
    
    void OnPlayerJoined(PlayerInput playerInput)
    {
        playerInput.gameObject.GetComponent<PlayerControls>().playerID = playerInput.playerIndex;

        playerInput.gameObject.transform.position = spawnPoints[playerInput.playerIndex].position;

        playerInput.gameObject.GetComponent<PlayerControls>().WM = WM;
        WM.activePlayers++;
    }
}