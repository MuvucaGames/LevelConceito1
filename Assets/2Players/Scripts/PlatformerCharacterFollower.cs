using UnityEngine;
using System.Collections;
using UnityStandardAssets._2D;

[RequireComponent(typeof (PlatformerCharacter2D))]
public class PlatformerCharacterFollower : MonoBehaviour {

	public float maxDistance = 2f;
	public float threshold = 0.5f;

	private PlatformerCharacter2D m_Character;
	private Platformer2DUserControl m_Control;

	Transform tr;
	Transform other_tr;

	public void SetObjectToFollow(GameObject toFollow)
	{
		other_tr = toFollow.transform;
	}

	void Awake()
	{
		m_Character = GetComponent<PlatformerCharacter2D>();
		tr = transform;
	}

	void FixedUpdate () {
		float distance = other_tr.position.x - tr.position.x;
		if (Mathf.Abs (distance) > maxDistance) {
			float h = (distance > 0) ? 1f : -1f;
			//Debug.Log ( "distance" + distance + ", h = " + h );
			m_Character.Move (h, false, false);
		} else if (Mathf.Abs (distance) < maxDistance - threshold) {
			m_Character.Move (0f, false, false);
		}
	}
}
