using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AbrirPorta : MonoBehaviour {
	public float distancia;
	public GameObject acaoDisplay; // hud tecla de ação.
	public GameObject acaoTxt; // hud da exibição da ação.
	public GameObject porta; // gameObject da porta.
	public AudioSource rangerSom; // som de abertura da porta.

	// Update is called once per frame
	void Update () {
		distancia = PlayerCasting.distanciaAlvo; // pegando o valor da variável do RayCast anterior.

	}
	void OnMouseOver () { // quando o mouse está sobre o objeto.
		if (distancia <= 2) {
			acaoDisplay.SetActive (true);
			acaoTxt.SetActive (true);
		}
		if (Input.GetButtonDown ("BtnAcao")){ // quando apertar o botão.
			if (distancia <= 2) { // e a distância for menor ou igual a 2.
				this.GetComponentInChildren<BoxCollider>().enabled = false; // desliga o collider da porta.
				acaoDisplay.SetActive (false); 
				acaoTxt.SetActive (false);
				porta.GetComponent<Animation>().Play("porta01anim"); // iniciando a animação da porta.
				rangerSom.Play(); // iniciando o som.
			}
			
		}
		if (distancia >= 2) {
			acaoDisplay.SetActive (false);
			acaoTxt.SetActive (false);
		}
	}
	void OnMouseExit () { // quando o mouse não está a frente do objeto.
		acaoDisplay.SetActive (false);
		acaoTxt.SetActive (false);
	}
}
