using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExistenceScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	//awesome comment
	// Update is called once per frame
	void Update () {
        float small = .05f;
        float x = Random.Range(-small, small);
        float y = Random.Range(-small, small);
        transform.position = transform.position + new Vector3(x, y, 0.0f);
        float edge = 5.0f;
        if (transform.position.x<-edge){
            transform.position = new Vector3(-edge, transform.position.y, 0.0f);
        }
        if (transform.position.x > edge)
        {
            transform.position = new Vector3(edge, transform.position.y, 0.0f);
        }
        if (transform.position.y < -edge)
        {
            transform.position = new Vector3(transform.position.x, -edge, 0.0f);
        }
        if (transform.position.y >edge)
        {
            transform.position = new Vector3(transform.position.x, edge, 0.0f);
        }
	}
}
