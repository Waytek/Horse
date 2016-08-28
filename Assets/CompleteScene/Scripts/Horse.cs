using UnityEngine;
using System.Collections;

public class Horse : MonoBehaviour {
    Animator Horse_Animator;
    Rigidbody Horse_Rigidbody;

    public float walkSpeed = 3;
    public float runSpeed = 6;
    public float turnSpeed = 60;

    public bool isRuning = false;
    public bool isWalking = false;
    public bool canRun = true;
    
	// Use this for initialization
	void Start () {
        //Instantiate(this.gameObject);
        Horse_Animator = GetComponent<Animator>();
        Horse_Rigidbody = GetComponent<Rigidbody>();
	}
	// Update is called once per frame
	void Update () {

	}
    void FixedUpdate()
    {

    }
    public void Animating(float walk, float turn, float run)
    {
        bool walking = walk != 0 && run == 0 || walk!=0 && !canRun;
        bool walking_back = walk < 0;
        bool turnOnStay = turn != 0 && run == 0 || turn!=0 && walk==0;        
        
        bool anim_walking = walking || walking_back || turnOnStay;        
        Horse_Animator.SetBool("walk", anim_walking);

        bool anim_runing = walk>0 && run!=0 && canRun;
        Horse_Animator.SetBool("run", anim_runing);
    }
    public void Move(float walk, float run)
    {
        //if (walk != 0)
        //{
            Horse_Rigidbody.position += Horse_Rigidbody.transform.forward * Speed(walk, run) * Time.deltaTime;

        //}
    }
    public void Turn(float turn, float move)
    {
        if (move < 0) 
        {
            turn *= -1; //инвертирует повороты при ходьбе назад
        } 
        if (turn != 0)
        {
            Horse_Rigidbody.transform.Rotate(Vector3.up * turn * Time.deltaTime);
        }

    }
    float Speed(float walk, float run)
    {
        if (walk > 0 && run > 0 && canRun)
        {
            isRuning = true;
            isWalking = false;
            return run;
            
        }
        else if (walk !=0)
        {
            isRuning = false;
            isWalking = true;
            return walk;
        }
        else
        {
            isRuning = false;
            isWalking = false;
            return 0;
        }
    }
}
