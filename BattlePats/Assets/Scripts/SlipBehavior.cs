using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlipBehavior : MonoBehaviour
{

    public WinManager WM;

    public PhysicMaterial myMat;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        myMat.dynamicFriction =WM.timer / WM.GameTime;
    }
}
