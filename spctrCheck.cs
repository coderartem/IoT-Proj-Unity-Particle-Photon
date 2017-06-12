using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spctrCheck : MonoBehaviour {

    public float multi;
    public float strtScale;
    public int i;

	// Use this for initialization
	void Start () {

    }
	
	// Update is called once per frame
	void Update () {
        transform.localScale = new Vector3(transform.localScale.x, (AudioSRC.csBuff[i] * multi) + strtScale, transform.localScale.z);
		
	}
}
