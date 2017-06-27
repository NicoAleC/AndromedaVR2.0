using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CambiarEscena : MonoBehaviour {
	public verificar ver;
	public Text user;
	public Text pass;
    public void escena1()
    {
            SceneManager.LoadScene("listaproducots");
    }

	public void escenaTienda()
	{
		string a = user.text;
		string b = pass.text;
		if (ver.VerificarUsuario (a,b)) { 
			SceneManager.LoadScene ("tienda");
		}
	}

	public void escenaRegistro()
	{
		SceneManager.LoadScene("MenuRegistro");
	}

	public void escenaLogin()
	{
		SceneManager.LoadScene("MenuLogin");
	}

	public void escenaFinal()
	{
		SceneManager.LoadScene("final");
	}
}
