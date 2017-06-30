using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using System.Linq;
using System.Net;
using Newtonsoft.Json;

public class verificar : MonoBehaviour {

	public Text texto;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	public bool VerificarUsuario(string nombre, string pass)
	{
		bool a = false;
		try{
		var json = new WebClient().DownloadString(string.Format("http://192.168.40.217/slimapp/public/api/customer/verificar/{0}/{1}", nombre,pass));
		a = JsonConvert.DeserializeObject<bool> (json);
			if(!a)
				texto.text = "datos incorrectos";
		}catch(Exception){
			texto.text = "fallo en la conexion";
		}
		return a;
	}
}
class Cliente
{
	public long codusuario { get; set; }
	public string nombreusuario { get; set; }
	public string password { get; set; }
	public int ci { get; set; }
	public bool tipo { get; set; }
	public bool staff { get; set; }
	public bool admi { get; set; }

}
