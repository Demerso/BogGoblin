using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PlayerLoop;

public class lancer : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject itself;
    public GameObject def;
    public Rigidbody ball;
    public bool hit = false;
    public float dmg = 10.0f;

    public void throwing(Transform t)
    {

        itself.SetActive(true);
        itself.transform.LookAt(t);
        ball.velocity = new Vector3(0, 0, 5);
        

    }
    private void OnTriggerEnter(Collider other)
    {
        
        if(other.tag != "Player")
        {
            hit = true;
            itself.SetActive(false);
            itself.transform.position = def.transform.position;
        }
    }
    
}
