using System.Collections.Generic;
using UnityEngine;
using System;
using System.Linq;
using System.Net;
using Newtonsoft.Json;

public class verificar : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	public bool VerificarUsuario(string nombre, string pass)
	{
		bool a = false;
		var json = new WebClient().DownloadString(string.Format("http://192.168.42.157/slimapp/public/api/customer/verificar/{0}/{1}", nombre,pass));
		a = JsonConvert.DeserializeObject<bool> (json);
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
