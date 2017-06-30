using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Text))]
public class canvaslist : MonoBehaviour {
	private const string DISPLAY_TEXT_FORMAT = "click en el boton verde para\nfinalizar las compras\nnombre:\n{0}";
	private bool estado;
	private Text textField;
	private float fps = 60;
	public Camera cam;
	public cliente client;

	void Awake() {
		textField = GetComponent<Text>();
		estado = false;
	}
	public void setestado(bool t){
		estado = t;
	}
	void Start() {
		if (cam == null) {
			cam = Camera.main;
		}

		if (cam != null) {
			// Tie this to the camera, and do not keep the local orientation.
			transform.SetParent(cam.GetComponent<Transform>(), true);
		}
	}

	void LateUpdate() {
		if (estado) {
			textField.text = string.Format (DISPLAY_TEXT_FORMAT,
				client.mostrar());
		} else {
			textField.text = "";
		}
	}
}
