using System;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;
using UnityStandardAssets._2D;

[RequireComponent(typeof (PlatformerCharacter2D))]
public class Platformer2DDualControl : MonoBehaviour
{
    private PlatformerCharacter2D m_Character;
    private bool m_Jump;

	private bool firstPlayer = false;

	public void SetPlayer (bool isFirstPlayer)
	{
		firstPlayer = isFirstPlayer;
	}

    private void Awake()
    {
        m_Character = GetComponent<PlatformerCharacter2D>();
    }
	
    private void Update()
    {
        if (!m_Jump)
        {
            // Read the jump input in Update so button presses aren't missed.
            m_Jump = Input.GetKeyDown(firstPlayer ? KeyCode.W : KeyCode.UpArrow);
        }
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
