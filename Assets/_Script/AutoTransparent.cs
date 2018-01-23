using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoTransparent : MonoBehaviour
{

	Color temp;
	private bool isBlocking = false;

	//倒计时计数
	int countDown = 0;

	private void Start()
	{
		temp = this.GetComponent<Renderer>().material.color;
	}
	// Update is called once per frame
	void Update()
	{
		
		if (countDown>0)
		{
			countDown -= 1;
			temp.a = 1.0f - 0.018f * countDown;
			this.GetComponent<Renderer>().material.color = temp;
		}
		else
		{
			//this.GetComponent<BoxCollider>().enabled = true;
		}
	}

	public void SetIsBlocking()
	{
		countDown = 50;
		isBlocking = true;
		//this.GetComponent<BoxCollider>().enabled = false;//关闭碰撞
	}
}
