using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SecndRotation : MonoBehaviour {
    public float basse;
    public float multiplaer;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
       // transform.RotateAround(transform.position,Vector3.up,20*Time.deltaTime);
        transform.Rotate(Random.value, Random.value, Random.value);
        //gameObject.transform.localScale = new Vector3(Mathf.Abs(basse - AudioSRC.csBuff[0] * multiplaer), Mathf.Abs(basse - AudioSRC.csBuff[0] * multiplaer ), Mathf.Abs(basse - AudioSRC.csBuff[0] * multiplaer));
    }
}
