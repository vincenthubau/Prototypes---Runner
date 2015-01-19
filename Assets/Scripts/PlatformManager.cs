using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PlatformManager : MonoBehaviour {

	public GameObject runnerRef;
	private float distanceToRecycle = 20;
	public int numberOfPlatforms = 10;
	public List<GameObject> platforms = new List<GameObject>();
	public List<Material> mats = new List<Material>();
	public List<PhysicMaterial> physMats = new List<PhysicMaterial>();

	public Vector3 minScale = new Vector3();
	public Vector3 maxScale = new Vector3();

	public float minGap;
	public float maxGap;

	public Vector3 minHeight = new Vector3();
	public Vector3 maxHeight = new Vector3();

	GameObject PlatformCreate(){
		GameObject platformPrefab = Resources.Load("Prefabs/Platform") as GameObject;
		GameObject g = Instantiate(platformPrefab, Vector3.zero, Quaternion.identity) as GameObject;
		ModifyPlateform(g);
		return g;
	}

	GameObject ModifyPlateform(GameObject g){
		Vector3 tempScale = new Vector3(Random.Range(minScale.x, maxScale.x),1,1);
		g.transform.localScale = tempScale;
		Vector3 tempPosition = new Vector3();
		if(platforms.Count>0){
			tempPosition = platforms[platforms.Count-1].transform.position;
			tempPosition.x += platforms[platforms.Count-1].transform.localScale.x * 0.5f;
			tempPosition.y = Random.Range(minHeight.y, maxHeight.y);
			tempPosition.x += g.transform.localScale.x * 0.5f;
			
		}
		tempPosition.x += Random.Range(minGap, maxGap);
		g.transform.position = tempPosition;
		
		int index = Random.Range(0, physMats.Count);
		g.renderer.material = mats[index];
		g.collider.material = physMats[index];
		
		g.transform.parent = gameObject.transform;
		return g;
	}
	
	// Use this for initialization
	void Start () {
		runnerRef = GameObject.FindGameObjectWithTag("Player");
		for(int i=0; i<numberOfPlatforms; i++){
			GameObject g = PlatformCreate();
			platforms.Add (g);
		}
	}
	
	// Update is called once per frame
	void Update () {

		if(platforms[0].transform.position.x + distanceToRecycle < runnerRef.transform.position.x){
			GameObject g = platforms[0];
			platforms.Remove(g);

			ModifyPlateform(g);
			platforms.Add(g);
		}
	}
}
