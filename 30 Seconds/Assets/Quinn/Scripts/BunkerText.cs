using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BunkerText : MonoBehaviour {
    public GameObject bunkerText;
    private void OnTriggerEnter(Collider other)
    {
        bunkerText.SetActive(true);
    }
    private void OnTriggerStay(Collider other)
    {
        bunkerText.SetActive(true);
    }
    private void OnTriggerExit(Collider other)
    {
        bunkerText.SetActive(false);
    }
}
