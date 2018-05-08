using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player_movment : MonoBehaviour,IDamageable {
    public float speed;
    public int heath;
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKey(KeyCode.W))
        {
            transform.position += Vector3.forward * speed * Time.deltaTime;
            /*transform.GetChild(0).*/transform.rotation = Quaternion.Euler(0, 0, 0);
        }
        if (Input.GetKey(KeyCode.S))
        {
            transform.position += Vector3.back * speed * Time.deltaTime;
            /*transform.GetChild(0).*/transform.rotation = Quaternion.Euler(0, 180, 0);
        }
        if (Input.GetKey(KeyCode.A))
        {
            transform.position += Vector3.left * speed * Time.deltaTime;
            /*transform.GetChild(0).*/transform.rotation = Quaternion.Euler(0, 90, 0);
            
        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.position += Vector3.right * speed * Time.deltaTime;
            /*transform.GetChild(0).*/transform.rotation = Quaternion.Euler(0, -90, 0);
        }

    }
    public void takeDamage(int damageTaken)
    {
        heath -= damageTaken;
        if(heath <= 0)
        {
            Destroy(gameObject);
        }
    }
}
