using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Irfinal : MonoBehaviour {

	private bool estado;
	// Use this for initialization
	void Start () {
		estado = false;
		gameObject.SetActive (false);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	public void cambia(){
		if (estado)
			gameObject.SetActive (false);
		else
			gameObject.SetActive (true);
		estado = !estado;
	}
}
