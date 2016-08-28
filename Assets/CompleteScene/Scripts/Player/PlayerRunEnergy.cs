using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PlayerRunEnergy : MonoBehaviour {
    //GameObject Player_GameObject;
    Horse Player_Horse;
    public Slider Energy_indikator;
    public float curentEnergy = 100f;
    public float maxEnergy = 100f;
    public float energyCanRun = 20f;
    public float energyDawnOnSecond = 5f;
    public float energyUpOnWalk = 1f;
    public float energyUpOnStay = 5f;
	// Use this for initialization
	void Start () 
    {
        Player_Horse = GameObject.FindWithTag("Player").GetComponent<Horse>();
        Energy_indikator = this.GetComponent<Slider>();
	}
	
	// Update is called once per frame
	void Update () 
    {
        
	}
    void FixedUpdate()
    {
        EnergyUp();
        EnergyDawn();
        CanRunChanges();
        Energy_indikator.value = curentEnergy;
    }
    void EnergyUp()
    {
        if (!Player_Horse.isRuning)
        {
            if (Player_Horse.isWalking && curentEnergy <= maxEnergy)
            {
                curentEnergy += energyUpOnWalk * Time.deltaTime;
            }
            if (!Player_Horse.isWalking && curentEnergy <= maxEnergy)
            {
                curentEnergy += energyUpOnStay * Time.deltaTime;
            }
        }        
        if (curentEnergy > maxEnergy)
        {
            curentEnergy = maxEnergy;
        }
    }
    void EnergyDawn()
    {
        if (Player_Horse.isRuning && curentEnergy>=0)
        {
            curentEnergy -= energyDawnOnSecond * Time.deltaTime;
        }
        if (curentEnergy < 0) 
        { 
            curentEnergy = 0; 
        }    
    }
    void CanRunChanges()
    {
        if (curentEnergy == 0)
        {
            Player_Horse.canRun = false;
        }
        if (curentEnergy>=energyCanRun)
        {
            Player_Horse.canRun = true;
        }
    }
}
