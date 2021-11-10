using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CandyScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter2D(Collider2D collision){
        if(collision.gameObject.tag == "Player") {

            Manager.instance.incrementTheScore();
            Destroy(gameObject);
        }

        if(collision.gameObject.tag == "DestroyBoundary"){

            Manager.instance.decreaseLife();
            Destroy(gameObject);
        }
    }
}
