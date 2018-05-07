using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class timer : MonoBehaviour {
    public Text text;
    public float timeleft;
    public player_movment player;
    // Use this for initialization
    void Start () {
    }
	
	// Update is called once per frame
	void Update () {
        if (timeleft > 0)
        {

            timeleft -= Time.deltaTime;

        }
        if (timeleft <=0)
        {

            
            player.takeDamage(10);

        }
        text.text = "Time Left:" + timeleft.ToString("0");
    }
}
