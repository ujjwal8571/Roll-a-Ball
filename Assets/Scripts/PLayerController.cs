using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PLayerController : MonoBehaviour {

	public float speed;
	private Rigidbody rb;
	private int count;

	public Text countText;
	public Text winText;

	void Start () {
		rb = GetComponent<Rigidbody>();
		count = 0;
		displayCount ();
		winText.text = "";
	}

	void FixedUpdate(){
		float moveHorizontal = Input.GetAxis ("Horizontal");
		float moveVertical = Input.GetAxis ("Vertical");

		Vector3 movement = new Vector3 (moveHorizontal, 0.0f, moveVertical);

		rb.AddForce (movement * speed);

	}

	void OnTriggerEnter(Collider other){
		if(other.gameObject.CompareTag("Pick Up")){
			other.gameObject.SetActive(false);
			count = count + 1;
			displayCount ();
		}
	}

	void displayCount(){
		countText.text = "Count:" + count;
		if (count == 8) {
			winText.text = "You win!!";
		}

	}
}
