using UnityEngine;
using System.Collections;

public class AI_Spawn_Manager : MonoBehaviour {
    public float spawnTime = 5f;
    public float spawnDistance = 100f;
    public GameObject[] spawnPoints;
    public GameObject AI_Horse;
    GameObject Player;
	// Use this for initialization
	void Start () {
        Player = GameObject.FindWithTag("Player");
        spawnPoints = GameObject.FindGameObjectsWithTag("Spawn Point");
        spawnDistance = AI_Horse.GetComponent<AImovement>().destroyDistance;
        InvokeRepeating("Spawn", spawnTime, spawnTime);
	}
	
	// Update is called once per frame
	void Update () {
	}
    void Spawn()
    {
        foreach (GameObject point in spawnPoints)
        {
            if (Vector3.Distance(point.transform.position, Player.transform.position) < spawnDistance)
            {
                Instantiate(AI_Horse, point.transform.position, point.transform.rotation);
            }            
        }
    }
}
