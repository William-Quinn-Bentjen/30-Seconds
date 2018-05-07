using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class timer : MonoBehaviour {
    //old text
    //public Text text;
    public float timeleft;
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (timeleft > 0)
        {

            timeleft -= Time.deltaTime;

        }
        else
        {
            WaitManager.instance.OnTimeUp();
        }
        //tell the UI manager 
        UIManager.instance.UpdateTimer(timeleft);
        //Old text change
        //text.text = "Time Left:" + timeleft.ToString("0");
    }
}
