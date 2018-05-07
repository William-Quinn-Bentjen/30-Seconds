using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bunker : MonoBehaviour {
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            //dump backpack and start the 30 seconds of "surviving" in the bunker
            ResourceHolder.EmptyBackpack();
            WaitManager.instance.StartWaitPhase();
        }
    }
}
