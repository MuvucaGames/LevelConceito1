using UnityEngine;
using System.Collections;

public class CameraControl : MonoBehaviour {

	public float minSize = 5f;
	public float maxSize = 100f;
	public float margin = 1f;
	public float heightCorrection = 1.5f;
	private float sizeRatio = 7f / 25f; //este valor e importante!

	Transform player1;
	Transform player2;
	Camera cam;

	// Use this for initialization
	void Start () {
		player1 = GameObject.Find ("Player1").GetComponent<Transform>();
		player2 = GameObject.Find ("Player2").GetComponent<Transform>();
		cam = GetComponent<Camera> ();
	}
	
	// Update is called once per frame
	void Update () {
		Vector3 p1pos = player1.position;
		Vector3 p2pos = player2.position;

		float dist = Mathf.Sqrt(Mathf.Pow((p2pos.x - p1pos.x), 2) + Mathf.Pow((p2pos.y - p1pos.y), 2));
		dist += margin + margin;

		float x = (p1pos.x + p2pos.x) / 2;
		float y = (p1pos.y + p2pos.y) / 2;
		
		Vector3 cameraPosition = new Vector3(x , y + heightCorrection, cam.transform.position.z);
		
		cam.transform.position = cameraPosition;
		cam.orthographicSize = Mathf.Clamp (dist * sizeRatio, minSize, maxSize);
	}
}
