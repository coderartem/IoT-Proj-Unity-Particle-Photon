using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FCubeManager : MonoBehaviour {
    GameObject[] fc;
    Vector3[] stpos;
    Quaternion[] strt;
   

	// Use this for initialization
	void Start () {
       
        fc = GameObject.FindGameObjectsWithTag("FC");
        stpos = new Vector3[fc.Length];
        strt = new Quaternion[fc.Length];
        for (int i =0; i < fc.Length; i++)
        {
            stpos[i] = fc[i].transform.position;
            strt[i] = fc[i].transform.rotation;
        }
        
		
	}
	
	// Update is called once per frame
	void Update () {

        if (oscControl.orient == 3)
        {
            fc[0].transform.position = new Vector3(Mathf.SmoothStep(fc[0].transform.position.x, fc[0].transform.position.x - 1000f, .03f), stpos[0].y, stpos[0].z); //C2
            fc[1].transform.position = new Vector3(stpos[1].x, Mathf.SmoothStep(fc[1].transform.position.y, fc[1].transform.position.y + 1000f, .03f), stpos[1].z); //C5
            fc[2].transform.position = new Vector3(stpos[2].x, stpos[2].y, Mathf.SmoothStep(fc[2].transform.position.z, fc[2].transform.position.z + 1000f, .03f)); //C4
            fc[3].transform.position = new Vector3(Mathf.SmoothStep(fc[3].transform.position.x, fc[3].transform.position.x + 1000f, .03f), stpos[3].y, stpos[3].z);  //C1
            fc[4].transform.position = new Vector3(  stpos[4].x,  Mathf.SmoothStep(fc[4].transform.position.y, fc[4].transform.position.y - 1000f, .03f),stpos[4].z); //C6
            fc[5].transform.position = new Vector3( stpos[5].x, stpos[5].y, Mathf.SmoothStep(fc[5].transform.position.z, fc[5].transform.position.z - 1000f, .03f));  //C3
        }
        else 
        {

            for(int i = 0; i<fc.Length; i++)
            {
                fc[i].transform.position = stpos[i];
                fc[i].transform.rotation = strt[i];
            }
        }

    }
}
