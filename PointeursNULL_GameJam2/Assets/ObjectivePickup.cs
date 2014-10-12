﻿using UnityEngine;
using System.Collections;

public class ObjectivePickup : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.layer == 11 && !collider.gameObject.GetComponent<Character_Controller>().transportObjective)
        {
            collider.GetComponent<Character_Controller>().transportObjective = true;
            Destroy(this.gameObject);
        }
        else if (collider.gameObject.layer == 12)
        {
            //ajouter point humain
            Destroy(this.gameObject);
        }
    }
}
