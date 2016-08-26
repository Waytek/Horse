using UnityEngine;
using System.Collections;
using UnityStandardAssets.CrossPlatformInput;

public class PlayerMovement : MonoBehaviour {
    Horse Player_Horse;
	// Use this for initialization
	void Start () 
    {
        Player_Horse = GetComponent<Horse>();
	}
	
	// Update is called once per frame
	void Update () 
    {
	
	}
    void FixedUpdate()
    {
        float inputWalk = CrossPlatformInputManager.GetAxisRaw("Vertical");
        float inputTurn = CrossPlatformInputManager.GetAxisRaw("Horizontal");
        float inputRun = CrossPlatformInputManager.GetAxisRaw("Run");
        Player_Horse.Move(inputWalk * Player_Horse.walkSpeed, inputRun * Player_Horse.runSpeed);
        Player_Horse.Turn(inputTurn * Player_Horse.turnSpeed, inputWalk);
        Player_Horse.Animating(inputWalk, inputTurn, inputRun);
    }
}
