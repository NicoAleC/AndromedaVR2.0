using System.Collections;
using UnityEngine;
using System.Collections.Generic;
using System;
using System.Linq;
using System.Net;
using Newtonsoft.Json;
using UnityEngine.UI;
using System.Timers;

public class cliente : MonoBehaviour {
	public static List<Producto> p;
	public Listaofi lalista;
	public static cliente client;
	public Text anadir;
	public Timer temporalizador;
	public int tiempo;


	// Use this for initialization
	void Start () {
		p = new List<Producto>();
		lalista = new Listaofi ();
		anadir.enabled = false;
		temporalizador = new Timer();
		tiempo = 5;
	}
	
	// Update is called once per frame
	void Update () {

		if (tiempo <= 0) {
			anadir.enabled = false;
			tiempo = 5;
			temporalizador.Stop();
		}
		
	}

	public void Crono()
	{
		temporalizador.Interval = 1000;
		temporalizador.Start ();
		temporalizador.Elapsed += (object sender, System.Timers.ElapsedEventArgs e) => tiempo--;
	}

	public void añadir(Producto n){
		if (n.cantidad > 0) {
			bool aux = false;
			for (int i = 0; i < p.Count; i++) {
				if (p [i].codproducto == n.codproducto) {
					if (n.cantidad > p [i].cantidad) {
						p [i].cantidad += 1;
						anadir.text = "El producto se añadio\ncorrectamente";
						anadir.enabled = true;
						Crono ();
					} else {
						anadir.text = "Inventario insuficiente";
						anadir.enabled = true;
						Crono ();
					}
					aux = true;
				}
			}
			if (!aux) {
				Producto abc = new Producto ();
				abc.nombreprod = n.nombreprod;
				abc.codproducto = n.codproducto;
				abc.cantidad = 1;
				abc.preciov = n.preciov;
				p.Add (abc);
				anadir.text = "El producto se añadio\ncorrectamente";
				anadir.enabled = true;
				Crono ();
			}
		} else {
			anadir.text = "Inventario insuficiente";
			anadir.enabled = true;
			Crono ();
		}
	}
	public string mostrar(){
		string aux = "";
		for (int i = 0; i < p.Count; i++) {
			aux = aux + p[i].nombreprod +": "+ p[i].cantidad+ "\n";
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
		try{
		var json = new WebClient().DownloadString("http://192.168.42.232/slimapp/public/api/productos/total");
		m = JsonConvert.DeserializeObject<List<Producto>>(json);
		}catch(Exception){}
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

