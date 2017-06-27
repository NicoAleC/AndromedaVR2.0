using System.Collections;
using UnityEngine;
using System.Collections.Generic;
using System;
using System.Linq;
using System.Net;
using Newtonsoft.Json;

public class cliente : MonoBehaviour {
	public static List<Producto> p;
	public Listaofi lalista;
	public static cliente client;

	void Awake (){
		if (client == null) {
			client = this;
			DontDestroyOnLoad (gameObject);
		} else if (client != this) {
			Destroy (gameObject);
		}
	}
	// Use this for initialization
	void Start () {
		p = new List<Producto>();
		lalista = new Listaofi ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	public void añadir(Producto n){
		p.Add (n);
	}
	public string mostrar(){
		string aux = "";
		for (int i = 0; i < p.Count; i++) {
			aux = aux + p[i].nombreprod+ "\n";
		}
		return aux;
	}
}

public class Producto{

	private long _codproducto;
	private  long _codc;
	private  double _precioc;
	private  double _preciov;
	private  int _cantidad;
	private  string _imagen;
	private  string _descripcionp;
	private  string _nombreprod;

	public Producto(){
		_codproducto = 0;
		_codc = 0;
		_precioc = 0;
		_preciov = 0;
		_cantidad = 0;
		_imagen = "";
		_descripcionp = "";
		_nombreprod = "";
	}

	public long codproducto { get{ return _codproducto;} set{_codproducto = value; } }
	public long codc { get{ return _codc;} set{_codc = value; } }
	public double precioc { get{ return _precioc;} set{_precioc = value; } }
	public double preciov { get{ return _preciov;} set{_preciov = value; } }
	public int cantidad { get{ return _cantidad;} set{_cantidad = value; } }
	public string imagen { get{ return _imagen;} set{_imagen = value; } }
	public string descripcionp { get{ return _descripcionp;} set{_descripcionp = value; } }
	public string nombreprod { get{ return _nombreprod;} set{_nombreprod = value; } }
}

public class Listaofi{
	private List<Producto> m;
	public Listaofi(){
		//try{
		var json = new WebClient().DownloadString("http://192.168.42.157/slimapp/public/api/productos/total");
		m = JsonConvert.DeserializeObject<List<Producto>>(json);
		//}catch(Exception){}
	}
	/*public string mostrar(){
		string aux = "";
		for (int i = 0; i < m.Count; i++) {
			aux = m [i].nombreprod;
		}
		return aux;
	}*/
	public List<string> ListaProductos()
	{
		List<string> producto = new List<string>();
		for (int i = 0; i < m.Count; i++)
		{
			string aux = string.Format("{0}\t{1}\t{2}\t{3}", m[i].codproducto, m[i].preciov, m[i].cantidad,m[i].nombreprod);
			producto.Add(aux);
		}
		return producto;
	}

	public List<Producto> lalist(){
		return m;
	}

	public Producto buscar(int n){
		Producto aux = new Producto();
		for (int i = 0; i < m.Count; i++)
		{
			if (n == m[i].codproducto) {
				aux = m [i];
				break;
			}
		}
		return aux;
	}
}

