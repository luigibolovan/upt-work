using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    public bool canMove = true;


    [SerializeField]
    float moveSpeed;


    [SerializeField]
    float maxPosition;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        if (canMove){
            move();
        }
	}

    private void move(){
        
        float inputX = Input.GetAxis("Horizontal"); //left or right arrow key

        transform.position += Vector3.right * inputX * moveSpeed * Time.deltaTime;

        float xPosition = Mathf.Clamp(transform.position.x, -maxPosition, maxPosition); // keep the player within screen

        transform.position = new Vector3(xPosition, transform.position.y, transform.position.z);
    }
}
