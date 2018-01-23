using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineRoad : MonoBehaviour {


   
    Ray mouseRay;

    RaycastHit hit;

    LineRenderer lineRoad;

	GameController gameController;


    List<Vector3> linePosition = new List<Vector3>();


    float timer;

    public float maxtime;


   [SerializeField] bool lineNow;



	// Use this for initialization
	void Start () {


        lineRoad = GetComponent<LineRenderer>();
        linePosition.Clear();
		
	}
	
	// Update is called once per frame
	void Update () {


        if (Input.GetMouseButtonDown(0))
        {
            linePosition.Clear();


            mouseRay = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(mouseRay,out hit))
            {

                Debug.DrawLine(mouseRay.origin, hit.point);

                linePosition.Add(hit.point);


            }
            

        }

        if (Input.GetMouseButton(0))
        {

            mouseRay = Camera.main.ScreenPointToRay(Input.mousePosition);



            if (Physics.Raycast(mouseRay, out hit))
            {

                Debug.DrawLine(mouseRay.origin, hit.point);

                linePosition.Add(hit.point);


            }
        }

        if (Input.GetMouseButtonUp(0))
        {

            lineNow = true;

        }




        if (lineNow)
        {
            if (timer < maxtime)
            {
                timer += Time.deltaTime;
            }
            else
            {
                timer = 0;
                lineNow = false;
                linePosition.Clear();
            }



        }







        // print(linePosition.Count);



            lineRoad.positionCount = linePosition.Count;
            for (int i = 0; i < linePosition.Count && linePosition.Count>1; i++)
            {
                lineRoad.SetPosition(i, linePosition[i]);
                
            }







    }
}
