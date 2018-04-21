using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dropper : MonoBehaviour {

    public float velocity = 5f;
    public Rigidbody rb;
    public Transform dropSpot;
    public GameObject[] shapes;

	// Use this for initialization
	void Start () {
       rb.velocity = new Vector3(velocity,0,0);
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetButtonDown("Jump"))
        {
            SpawnShape();
        }
	}

    private void SpawnShape()
    {
        GameObject shape = shapes[Random.Range(0, shapes.Length)];
        Instantiate(shape, dropSpot.position, Quaternion.identity);
    }
}
