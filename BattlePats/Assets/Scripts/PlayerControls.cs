using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
public class PlayerControls : MonoBehaviour
{
    public WinManager WM;
    [Tooltip("No Touching!")]
    public int playerID;

    private PlayerInput playerInput;
    private Rigidbody RB;
    private Vector2 inputVector;
    private Vector3 startPos;

    [Header("Jumping")] 
    public float jumpImpulse = 100f;
    
    [Header("Movement")]
    [Tooltip("Values less than 900 may not have enough force to move the player")] public float impulse = 1000f;

    private float timeAlive = 0;
    [Tooltip("How many seconds it takes to reach minimum mass")] public float meltTime = 60;
    [Tooltip("The multiplier for being in the hotspot")] public float hotSpotMult = 1;
    public float meltMult = 1.2f;

    [Header("Scoring")] 
    public int lives = 3;

    public int hotSpotScoreRate = 1;

    public float score = 0;

    public GameObject healthUI;
    
    
    
    public void onMove(InputAction.CallbackContext ctx) => inputVector = ctx.ReadValue<Vector2>();
    void Awake()
    {
        RB = GetComponent<Rigidbody>();
        playerInput = GetComponent<PlayerInput>();

        startPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        RB.AddForce(new Vector3(inputVector.x,0,inputVector.y) * impulse * Time.deltaTime);

        RB.mass = (1 - (timeAlive / meltTime));
        if (RB.mass <= 0)
        {
            RB.mass = 0.01f;
        }


        timeAlive += Time.deltaTime;

        RectTransform[] pips = healthUI.GetComponentsInChildren<RectTransform>();

        for (int i = 0; i < pips.Length; i++)
        {
            pips[i].gameObject.SetActive(false);
        }
        for (int i = 0; i <= lives; i++)
        {
            pips[i].gameObject.SetActive(true);
        }

        if (lives == 0)
        {
            WM.activePlayers--;
            Destroy(gameObject);
        }
    }

    public void Jump()
    {
        RB.AddForce(new Vector3(0,jumpImpulse,0));
    }

    private void Respawn()
    {
        RB.velocity = Vector3.zero;
        RB.angularVelocity = Vector3.zero;
        transform.position = startPos;
        timeAlive = 0;
        lives--;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Deathplane")
        {
            Respawn();
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Hotspot")
        {
            score += hotSpotScoreRate * Time.deltaTime;
            timeAlive += Time.deltaTime * (hotSpotMult - 1);
        }

        if (other.tag == "Melter")
        {
            timeAlive += Time.deltaTime * (meltMult - 1);
        }
    }

    public void StartUp()
    {
        WM.SendMessage("StartButton");
    }
}
