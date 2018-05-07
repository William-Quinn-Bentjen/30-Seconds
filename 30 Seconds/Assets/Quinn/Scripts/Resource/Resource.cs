using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Resource : MonoBehaviour {

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            PickUpResource();
        }
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Player")
        {
            PickUpResource();
        }
    }
    public void PickUpResource()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            ResourceHolder.Backpack.Add(this);
            gameObject.SetActive(false);
        }
    }
}
