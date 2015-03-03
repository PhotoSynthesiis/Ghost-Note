using UnityEngine;
using System.Collections;

public class firemovement4 : MonoBehaviour {
	// Use this for initialization
	public bool right = true;
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		if (transform.position.x < 0 && right == true) 
		{
			transform.position = transform.position + Vector3.right * Time.deltaTime;
		}
		else{
			right = false;
			transform.position = transform.position + Vector3.left * Time.deltaTime;
			if(transform.position.x <= -4){
				right = true;
			}
		}
	}
}