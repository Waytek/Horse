using UnityEngine;
using System.Collections;
using System.Linq;

public class AImovement : MonoBehaviour {
    NavMeshAgent navAgent;
    Horse UI_Horse;
    GameObject Player;
    GameObject[] destinations;

    private static float imprecisionSpeed = 0.1f; //погрешность скорости
    private static int timeForStart = 0;

    public int timeForSwithMode = 10;

    public float destroyDistance = 100f;

	// Use this for initialization
	void Start () {
        navAgent = this.gameObject.AddComponent<NavMeshAgent>();
        UI_Horse = GetComponent<Horse>();
        Player = GameObject.FindWithTag("Player");

        destinations = GameObject.FindGameObjectsWithTag("Destinations");

        InvokeRepeating("ChosingMode", timeForStart, timeForSwithMode);
	}
	
	// Update is called once per frame
	void Update () 
    {
    }
    void FixedUpdate()
    {
        UI_anim();
        DestroyOnDistance(destroyDistance);
    }
    void Idle()
    {
        if (navAgent.enabled)
        {
            navAgent.enabled = false;
        }
    }
    void Walk()
    {
        if (!navAgent.enabled)
        {
            navAgent.enabled = true;
        }        
        navAgent.speed = UI_Horse.walkSpeed;
    }
    void Run()
    {
        if (!navAgent.enabled)
        {
            navAgent.enabled = true;
        }        
        navAgent.speed = UI_Horse.runSpeed + imprecisionSpeed;
    }
    void UI_anim()
    {
        float walk = navAgent.velocity.magnitude;
        float run = 0;
        if (walk >= UI_Horse.runSpeed)
        {
            run = walk;
        }
        UI_Horse.Animating(walk, 0, run);
    }
    void SetDestination(int numberDestinations)
    {        
        navAgent.SetDestination(destinations[numberDestinations].transform.position);      
    }
    void ChosingMode()
    {
        int modesAmount = 3;
        int numOfMode = Random.Range(0,modesAmount);
        int numberDestinations = Random.Range(0, destinations.Length);
        switch (numOfMode)
        {
            case 2:
                Idle();
                break;
            case 1:
                Walk();
                SetDestination(numberDestinations);
                break;
            case 0:
                Run();
                SetDestination(numberDestinations);
                break;
            default:
                break;
        }
    }
    void DestroyOnDistance(float destroyDistance)
    {
        if (Vector3.Distance(this.transform.position,Player.transform.position)>destroyDistance){
            Destroy(gameObject);
        }
    }
}
