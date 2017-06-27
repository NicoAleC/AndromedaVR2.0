// Copyright 2014 Google Inc. All rights reserved.
//
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
//
//     http://www.apache.org/licenses/LICENSE-2.0
//
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.

using UnityEngine;
using System;
using System.Timers;
using System.Collections;


[RequireComponent(typeof(Collider))]
public class Teleport : MonoBehaviour {
	
  	private Vector3 startingPosition;
	private Vector3 changePosition;
	private int click;
	private Timer temp;
	private Producto prod;
	public int tiempo;
	public Material inactiveMaterial;
	public Material gazedAtMaterial;
	public GameObject cart;
	public GameObject objeto;
	public GvrFPS texto;
	public cliente client;
	void Start() {
		prod = new Producto ();
    	startingPosition = transform.localPosition;
    	SetGazedAt(false);
		click = 0;
		tiempo = 15;
		temp = new Timer ();
		cart = GameObject.Find ("cart");
		try{
		prod = client.lalista.buscar (Convert.ToInt32(objeto.name));
		}catch(Exception){}
		/*texto.setnombre (objeto.name);
		texto.setestado (true);*/
  	}

  	public void SetGazedAt(bool gazedAt) {
    	if (inactiveMaterial != null && gazedAtMaterial != null) {
      	GetComponent<Renderer>().material = gazedAt ? gazedAtMaterial : inactiveMaterial;
      	return;
    	}
    	GetComponent<Renderer>().material.color = gazedAt ? Color.green : Color.red;
  	}

	//Metodo que reinicia las condiciones del cronometro
	public void ResetT()
	{
		temp = new Timer ();
	}

	// Metodo que reinicia las condiciones de posicion del objeto
  	public void Reset() {
    	transform.localPosition = startingPosition;
  	}

  	public void Recenter() {
#if 	!UNITY_EDITOR
    	GvrCardboardHelpers.Recenter();
#else
    	GvrEditorEmulator emulator = FindObjectOfType<GvrEditorEmulator>();
    	if (emulator == null) {
      	return;
    	}
    	emulator.Recenter();
#endif  // !UNITY_EDITOR
  }

	//Metodo de movimiento del objeto frente al usuario para que realice la compra.
	public void Movement()
	{
		changePosition.x = cart.gameObject.transform.position.x;
		changePosition.y = cart.gameObject.transform.position.y + (float)1.7;
		changePosition.z = cart.gameObject.transform.position.z + (float)0.5;
		transform.localPosition = changePosition;
		texto.setnombre (prod.nombreprod);
		texto.setprecio (""+prod.preciov);
		texto.setcantidad (""+prod.cantidad);
		texto.setestado(true);
	}

	//Metodo que se utiliza despues de que se realiza los cambios de posicion del click para devolver todo a su estado original
	public void AfterEvent()
	{
		Reset ();
		temp.Stop();
		click = 0;
		tiempo = 15;
		ResetT ();
	}

	//Metodo que crea el objeto y realiza los lapsos e intervalos que se usan para manejarlo
	public void Cronometer()
	{
		temp.Interval = 1000;
		temp.Start ();
		temp.Elapsed += (object sender, System.Timers.ElapsedEventArgs e) => tiempo--;
	}

	// Metodo para Mover el objeto cuando se realice un click, el segundo click logra que el objeto tenga la logica
	// de compra y este vuelve a su posicion original, ademas se implementa un cronometro interno al objeto en caso 
	// de que no quiera ser comprado
  	public void Move() {
		Movement();
		click++;
		Cronometer();
		if (click == 2) {
			texto.setestado (false);
			client.añadir (prod);
			AfterEvent ();
		}
	}

	//se realiza un update que llama al metodo AfterEvent cuando el cronometro interno del objeto llega a 0
	void Update()
	{
		if (tiempo <= 0) {
			texto.setestado (false);
			AfterEvent ();
		}
	}

}