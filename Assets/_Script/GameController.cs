using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{

	public Text lpText;										//暂时是用这玩意儿来显示能量值	
	public int LpValue { get; set; }						//能量值
	public Interact InteractableObject { get; set; }		//可交互物体，门、窗、电饭锅、电视机、洗衣机、旧电脑、旧空调


	[SerializeField]

	private void Start()
	{
		
	}

	private void Update()
	{
		lpText.text = LpValue.ToString();					//每帧刷一次能量槽
	}

	//显示可交互物体的简介
	internal void Notification()
	{
		
	}
}