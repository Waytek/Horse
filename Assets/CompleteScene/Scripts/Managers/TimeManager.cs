using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System;

public class TimeManager : MonoBehaviour {
    Text timer;
    float time = 0;

    private DateTime timeBegin;
    private TimeSpan timeTimer;
    public string timeString;
	// Use this for initialization
	void Start () {
        timer = GetComponent<Text>();
        timeBegin = DateTime.Now;
	}
	
	// Update is called once per frame
	void Update () {
        timeTimer = DateTime.Now - timeBegin;
        timeString = string.Format("{0:D2}:{1:D2}:{2:D2}", timeTimer.Hours, timeTimer.Minutes, timeTimer.Seconds);
        timer.text = timeString;
	}
}
