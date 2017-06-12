using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class WrapController : MonoBehaviour {

    public float multiplaer,basse;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

       // gameObject.transform.localScale = new Vector3(basse - AudioSRC.cs[0] * multiplaer, basse - AudioSRC.cs[0] * multiplaer, basse - AudioSRC.cs[0] * multiplaer);
        gameObject.transform.localScale = new Vector3(Mathf.Abs(basse - AudioSRC.csBuff[0] * multiplaer), Mathf.Abs(basse - AudioSRC.csBuff[0] * multiplaer), Mathf.Abs(basse - AudioSRC.csBuff[0] * multiplaer));

    }
}
