using System;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;
using UnityStandardAssets._2D;

[RequireComponent(typeof (PlatformerCharacter2D))]
public class Platformer2DDualControl : MonoBehaviour
{
    private PlatformerCharacter2D m_Character;
    private bool m_Jump;
	public GameObject playerCamera;

	private bool firstPlayer = false;

	private PlatformerCharacter2D p2;

	public void SetMode (bool isFirstPlayer)
	{
		firstPlayer = isFirstPlayer;
	}

    private void Awake()
    {
        m_Character = GetComponent<PlatformerCharacter2D>();

		GameObject tmp = GameObject.Find ("Player2");
		if (tmp != null)
		{
			p2 = tmp.GetComponent<PlatformerCharacter2D>();
		}
    }


    private void Update()
    {
        if (!m_Jump)
        {
            // Read the jump input in Update so button presses aren't missed.
            m_Jump = Input.GetKeyDown(firstPlayer ? KeyCode.W : KeyCode.UpArrow);
        }

		if (firstPlayer) {
			//Vector3 cameraPosition = new Vector3 (gameObject.transform.position.x, gameObject.transform.position.y, playerCamera.transform.position.z);
			Vector3 p2Position = p2.transform.position;
			Vector3 p1Position = transform.position;

			float dist = Mathf.Sqrt(Mathf.Pow((p2Position.x - p1Position.x), 2) + Mathf.Pow((p2Position.y - p1Position.y), 2));

			float x = (p1Position.x + p2Position.x) / 2;
			float y = (p1Position.y + p2Position.y) / 2;

			Vector3 cameraPosition = new Vector3(x , y, playerCamera.transform.position.z);

			playerCamera.transform.position = cameraPosition;
			Camera cam = playerCamera.GetComponent<Camera>();
			float camSize = dist < 17 ? 5 : setCameraSize(dist);
			cam.orthographicSize = camSize;

			Debug.Log(dist);
		}
    }

	private float setCameraSize(float dist){
		return dist * 7 / 25;
	}


    private void FixedUpdate()
    {
        // Read the inputs.
        bool crouch = Input.GetKey(firstPlayer ? KeyCode.S : KeyCode.DownArrow);
		bool left = Input.GetKey (firstPlayer ? KeyCode.A : KeyCode.LeftArrow);
		bool right = Input.GetKey (firstPlayer ? KeyCode.D : KeyCode.RightArrow);
		float h = left ? -1f : (right ? 1f : 0f);
        // Pass all parameters to the character control script.
        m_Character.Move(h, crouch, m_Jump);
        m_Jump = false;
    }
}
