using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class frdstage : MonoBehaviour
{

    public Material MT;
    public Vector3 startPosition;
    Quaternion startRotation;
    bool done;
    float t;
  

    // Use this for initialization
    void Start()
    {
        
        done = true;
        startPosition = transform.position;
        startRotation = transform.rotation;
        gameObject.GetComponent<Rigidbody>().isKinematic = true;
    }

    // Update is called once per frame
    void Update()
    {
        

        switch (Manager.bang)
        {
            case 1:

                if (done)
                {
                    gameObject.GetComponent<Rigidbody>().isKinematic = true;
                    gameObject.GetComponent<Rigidbody>().useGravity = false;
                    transform.position = startPosition;
                    transform.rotation = startRotation;
                    done = false;
                }
                break;

            case 2:
                
                if (Time.time-t>2*Time.deltaTime)
                {
                    gameObject.GetComponent<Rigidbody>().isKinematic = true;
                    gameObject.GetComponent<Rigidbody>().useGravity = false;
                    transform.position = startPosition;
                    transform.rotation = startRotation;
                }
                transform.Rotate(Random.value, Random.value, Random.value);
                gameObject.GetComponent<Rigidbody>().isKinematic = false;
                gameObject.GetComponent<Rigidbody>().useGravity = true;
                done = true;
                break;


        }

        t = Time.time;
    }
}
