using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class ThirdPersonUserControl : MonoBehaviour
{

	private ThirdPersonCharacter m_Character; // A reference to the ThirdPersonCharacter on the object
	private Transform m_Cam;                  // A reference to the main camera in the scenes transform
	private Vector3 m_CamForward;             // The current forward direction of the camera
	private Vector3 m_Move;

	public GameController gameController;

	private bool m_Jump;                      // the world-relative desired move direction, calculated from the camForward and user input.

	//以下为定制内容，主要为角色数值属性
	private int lpValue;
	private int attackValue;

	public int Hp { set; get; }

	private void Start()
	{
		// get the transform of the main camera
		if (Camera.main != null)
		{
			m_Cam = Camera.main.transform;
		}
		else
		{
			Debug.LogWarning(
				"Warning: no main camera found. Third person character needs a Camera tagged \"MainCamera\", for camera-relative controls.", gameObject);
			// we use self-relative controls in this case, which probably isn't what the user wants, but hey, we warned them!
		}

		// get the third person character ( this should never be null due to require component )
		m_Character = GetComponent<ThirdPersonCharacter>();

		lpValue = 100;

		gameController.LpValue = lpValue;
	}


	private void Update()
	{
		if (!m_Jump)
		{
			m_Jump = CrossPlatformInputManager.GetButtonDown("Jump");
		}

		if (Input.GetMouseButtonDown(0))		//每点击一次鼠标左键就能-1s
		{
			lpValue -= 1;
			gameController.LpValue = lpValue;

			//近距离攻击
			AttackNear();
		}

		if(Input.GetMouseButtonDown(1))
		{
			//远距离攻击
			AttackDistant();
		}

		if(Input.GetKeyDown(KeyCode.E)|| Input.GetMouseButtonDown(0))			//按E可赛艇
		{
			if (gameController.InteractableObject!=null)
			{
				//gameController.InteractableObject.E(this.gameObject.GetComponent<Transform>());
				gameController.InteractableObject.E(this.transform);
			}
			else
			{
				print("Fine there's no interactable object in this area.");
			}
		}

	}


	// Fixed update is called in sync with physics
	private void FixedUpdate()
	{
		// read inputs
		float h = CrossPlatformInputManager.GetAxis("Horizontal");
		float v = CrossPlatformInputManager.GetAxis("Vertical");
		bool crouch = Input.GetKey(KeyCode.C);

		// calculate move direction to pass to character
		if (m_Cam != null)
		{
			// calculate camera relative direction to move:
			m_CamForward = Vector3.Scale(m_Cam.forward, new Vector3(1, 0, 1)).normalized;
			m_Move = v * m_CamForward + h * m_Cam.right;
		}
		else
		{
			// we use world-relative directions in the case of no main camera
			m_Move = v * Vector3.forward + h * Vector3.right;
		}
#if !MOBILE_INPUT
		// walk speed multiplier
		if (Input.GetKey(KeyCode.LeftShift)) m_Move *= 0.5f;
#endif

		// pass all parameters to the character control script
		m_Character.Move(m_Move, crouch, m_Jump);
		m_Jump = false;
	}
	/// <summary>
	/// 人物进行近距离攻击
	/// </summary>
	/// 然后就打完了
	/// 真的
	private void AttackNear()
	{
		Debug.Log("Attack Near");
	}

	private void AttackDistant()
	{
		Debug.Log("Attack Distant");
	}
}
