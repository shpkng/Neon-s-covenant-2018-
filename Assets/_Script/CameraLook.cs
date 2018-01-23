using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraLook : MonoBehaviour {


    public Transform player1;

    private Ray ray;
    private RaycastHit hit;

    [SerializeField]

    Vector3 playerToLook,nPlayerToLook;



    private void Awake()
    {
        playerToLook = this.transform.position - player1.transform.position;	 //Offset
		nPlayerToLook = -playerToLook;											//
	}


    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        this.transform.position = player1.transform.position + playerToLook;
		
		ray = new Ray(this.transform.position, nPlayerToLook);

		if (Physics.Raycast(ray, out hit))
		{
			if(hit.transform.CompareTag("Building"))
			{
				hit.collider.gameObject.GetComponent<AutoTransparent>().SetIsBlocking();	//也就是每帧都会刷一遍
			}
		}

	}

	private void LateUpdate()
	{
		
	}
}