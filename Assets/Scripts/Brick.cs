using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Brick : MonoBehaviour {

    [SerializeField]
    private int live_points = 0;
    
	// Use this for initialization
	void Start ()
    {
        
	}
	
	// Update is called once per frame
	void Update ()
    {
		if(live_points <= 0)
        {
            Destroy(gameObject);
        }
	}

    private void OnCollisionEnter(Collision other)
    {
        GameObject obj = other.gameObject;

        if(obj.tag == "Ball")
        {
            live_points -= 1;
        }
    }
}
