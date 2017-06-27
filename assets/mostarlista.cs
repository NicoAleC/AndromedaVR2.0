using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mostarlista : MonoBehaviour {
	public canvaslist texto;
	public Irfinal fin;
	private bool estad;
	// Use this for initialization
	void Start () {
		estad = false;
	}

	// Update is called once per frame
	void Update () {}

	public void mostrar(){
		estad = !estad;
		texto.setestado (estad);
		fin.cambia ();
	}
}
