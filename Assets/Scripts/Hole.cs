using UnityEngine;
using System.Collections;

public class Hole : MonoBehaviour {

    bool fallIn;
    public string activeTag;

    public bool isFallIn()
    {
        return fallIn;
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == activeTag)
        {
            fallIn = true;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == activeTag)
        {
            fallIn = false;
        }
    }

    void OnTriggerStay(Collider other)
    {
        Rigidbody r = other.gameObject.GetComponent<Rigidbody>();
        Vector3 direction = transform.position - other.gameObject.transform.position;
        direction.Normalize();

        if (other.gameObject.tag == activeTag)
        {
            r.velocity *= 0.9f;
            r.AddForce(direction * r.mass * 20.0f);
        }
        else
        {
            r.AddForce(-direction * r.mass * 80.0f);
        }
    }
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
