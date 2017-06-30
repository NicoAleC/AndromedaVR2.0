// Copyright 2015 Google Inc. All rights reserved.
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
using UnityEngine.UI;

[RequireComponent(typeof(Text))]
public class GvrFPS : MonoBehaviour {
  private const string DISPLAY_TEXT_FORMAT = "click en el objeto\npara agregarlo\nnombre:\n{0}\nprecio:\n{1}\ncantidad:\n{2}";
	private string nombre;
	private string precio;
	private string cantidad;
	private bool estado;

  private Text textField;
  private float fps = 60;

  public Camera cam;

  void Awake() {
    textField = GetComponent<Text>();
		nombre = "";
		precio = "";
		cantidad = "";
		estado = false;
  }
	public void setnombre(string t){
		nombre = t;
	}
	public void setprecio(string t){
		precio = t;
	}
	public void setcantidad(string t){
		cantidad = t;
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
				nombre, precio, cantidad);
		} else {
			textField.text = "";
		}
  }
}
