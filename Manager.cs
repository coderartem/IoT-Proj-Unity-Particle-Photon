using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Manager : MonoBehaviour {

    GameObject _1st;
    GameObject _2nd;
    GameObject MainCube;
    Renderer MCM;
    public Material[] M = new Material[2];
    
    public static int _switchMusic;
    public static int bang;
    int SM;


	// Use this for initialization
	void Start () {
         _1st = GameObject.FindGameObjectWithTag("1st");
         _2nd = GameObject.FindGameObjectWithTag("2nd");
        MainCube = GameObject.FindGameObjectWithTag("MainCube");
        MCM = GameObject.FindGameObjectWithTag("MainCube").GetComponent<Renderer>();
        MCM.sharedMaterial = M[0];
        _1st.SetActive(false);
        _2nd.SetActive(false);
        _switchMusic = 0;
        bang = 0;
        

		
	}
	
	// Update is called once per frame
	void Update () {

        if (oscControl.orient != SM)
        {
            SM = oscControl.orient;

            if (SM != 5 )
            {
                
            }


            switch (oscControl.orient)
            {
                case 7:

                   
                    MainCube.SetActive(true);
                    MCM.sharedMaterial = M[1];
                    _2nd.SetActive(false);
                    _1st.SetActive(true);
                    _switchMusic = 1;

                    break;

                case 3:

                    bang = 1;
                    MainCube.SetActive(false);
                    MCM.sharedMaterial = M[0];
                    _1st.SetActive(false);
                    _2nd.SetActive(true);
                    _switchMusic = 2;
                   

                    break;

                case 5:

                    
                    MainCube.SetActive(true);
                    MCM.sharedMaterial = M[1];
                    _1st.SetActive(false);
                    _2nd.SetActive(true);
                    _switchMusic = 3;
                    bang = 2;

                    break;

                case 1:
                    
                    MainCube.SetActive(true);
                    MCM.sharedMaterial = M[0];
                    _1st.SetActive(false);
                    _2nd.SetActive(false);
                    _switchMusic = 4;


                    break;

                case 2:
                case 4:
                case 8:
                case 6:
                    MainCube.SetActive(true);
                    MCM.sharedMaterial = M[0];
                    _1st.SetActive(false);
                    _2nd.SetActive(false);
                    _switchMusic = 0;

                    break;

            }

        }

                
	}
}
