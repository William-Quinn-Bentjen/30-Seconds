using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player_movment : MonoBehaviour,IDamageable {
    public float speed;
    public float turnSpeed;
    public int heath;
    public float PromptWaitForTime = .25f;
    // Use this for initialization
    void Start () {
        StartCoroutine("PickUpPrompt");
    }
    IEnumerator PickUpPrompt()
    {
        while(true)
        {
            if (UIManager.instance.PickupPrompt != null)
            {
                bool enableUI = false;
                Collider[] cols = Physics.OverlapSphere(gameObject.transform.position, 1);
                if (cols.Length > 0)
                {
                    foreach (Collider col in cols)
                    {
                        if (col.tag == "ITEM")
                        {
                            enableUI = true;
                            break;
                        }
                    }
                }
                UIManager.instance.PickupPrompt.gameObject.SetActive(enableUI);
                yield return new WaitForSeconds(PromptWaitForTime);

            }
            else
            {
                yield return new WaitForSeconds(1);
            }
        }
        
    }

    // Update is called once per frame
    void Update () {
        if (Input.GetKey(KeyCode.W))
        {
            //transform.position += Vector3.forward * speed * Time.deltaTime;
            ///*transform.GetChild(0).*/transform.rotation = Quaternion.Euler(0, 0, 0);
            transform.position += transform.forward * speed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.S))
        {
            //transform.position += Vector3.back * speed * Time.deltaTime;
            ///*transform.GetChild(0).*/transform.rotation = Quaternion.Euler(0, 180, 0);
            transform.position += -transform.forward * speed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.A))
        {
            //transform.position += Vector3.left * speed * Time.deltaTime;
            ///*transform.GetChild(0).*/transform.rotation = Quaternion.Euler(0, 90, 0);
            transform.rotation = Quaternion.Euler(0, transform.rotation.eulerAngles.y - (turnSpeed * Time.deltaTime), 0);
            
        }
        if (Input.GetKey(KeyCode.D))
        {
            //transform.position += Vector3.right * speed * Time.deltaTime;
            ///*transform.GetChild(0).*/transform.rotation = Quaternion.Euler(0, -90, 0);
            transform.rotation = Quaternion.Euler(0, transform.rotation.eulerAngles.y + (turnSpeed * Time.deltaTime), 0);
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
