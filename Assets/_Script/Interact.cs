using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interact : MonoBehaviour
{

	GameController gameController;
	public string typeOfThisObject;
	public Interact anotherInteractableObject;

	[SerializeField]
	bool portable = false;


	private void Start()
	{
		gameController = GameObject.Find("GameController").GetComponent<GameController>();
	}

	/// <summary>
	/// 按E可赛艇
	/// </summar
	public void E(Transform player)
	{
		switch (typeOfThisObject)
		{
			case "Portal": Portal(player); break;

			case "Else": Else(); break;
		}
	}

	private void OnTriggerEnter(Collider other)
	{
		gameController.InteractableObject = this;
		gameController.Notification();
	}

	private void OnTriggerExit(Collider other)
	{
		gameController.InteractableObject = null;
	}

	void Portal(Transform player)
	{

		Debug.Log("Portal");
		if (portable)
		{

			player.position = anotherInteractableObject.GetComponent<Transform>().position;

		}
		else
		{
			Debug.Log("This is A One-way Portal");
		}
	}

	void Else()
	{
		Debug.Log("Else");
	}

}

//
//命苦 刚打算追一个妹子 妹子就要出国 这日子没法过了
//
