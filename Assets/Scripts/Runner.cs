using UnityEngine;
using System.Collections;

public class Runner: MonoBehaviour {
	
	public float speed = 0;
	public Vector3 jumpHeight = new Vector3();
	private bool isOnGround = false;
	private int deathHeight = -3;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if(isOnGround){
			rigidbody.AddForce(new Vector3(speed, 0,0), ForceMode.Acceleration);
		}

		if(gameObject.transform.position.y < deathHeight){
			rigidbody.velocity = new Vector3();
			gameObject.transform.position = new Vector3(1, 3, 0);
			Destroy(GameObject.FindGameObjectWithTag("PlatformManager"));
			GameObject.FindGameObjectWithTag("GameController").GetComponent<Manager>().Reset();
		}

		if(Input.GetButtonDown("Jump") && isOnGround){
			isOnGround = false;
			rigidbody.AddForce(jumpHeight, ForceMode.VelocityChange);
		}
	}

	void OnCollisionEnter(){
		isOnGround = true;
	}

	void OnCollisionStay(){
		isOnGround = true;
	}

	void OnCollisionExit(){
		isOnGround = false;
	}
}
