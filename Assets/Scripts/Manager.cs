using UnityEngine;
using System.Collections;

public class Manager : MonoBehaviour {

	public GameObject plateformManager;
	// Use this for initialization
	void Start () {
		Reset();
	}

	public void Reset(){
		GameObject g = Instantiate(plateformManager, Vector3.zero, Quaternion.identity) as GameObject;
	}
}
