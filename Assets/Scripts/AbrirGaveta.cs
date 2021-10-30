using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AbrirGaveta : MonoBehaviour {
	public float distancia;
	public GameObject acaoDisplay; // hud tecla de ação.
	public GameObject acaoTxt; // hud da exibição da ação.
	//public GameObject gaveta; // gameObject da porta.
	public GameObject crosshair;
	public GameObject extraCross;
	public AudioSource abrirSom; // som de abertura da porta.
	public GameObject fxBrilhoItem;
	public GameObject textBox;

	// Update is called once per frame
	void Update () {
		distancia = PlayerCasting.distanciaAlvo; // pegando o valor da variável do RayCast anterior.

	}
	void OnMouseOver () { // quando o mouse está sobre o objeto.
		if (distancia <= 2) {
			extraCross.SetActive(true);
			crosshair.SetActive(false);

			acaoTxt.GetComponent<Text>().text = "Open Drawer";
			acaoDisplay.SetActive (true);
			acaoTxt.SetActive (true);
		}
		if (Input.GetButtonDown ("BtnAcao")){ // quando apertar o botão.
			if (distancia <= 2) { // e a distância for menor ou igual a 2.
				StartCoroutine(AcharLivro());
				this.GetComponentInChildren<BoxCollider>().enabled = false; // desliga o collider da porta.
				acaoDisplay.SetActive (false); 
				acaoTxt.SetActive (false);
				//gaveta.GetComponent<Animation>().Play("porta01anim"); // iniciando a animação da porta.
				abrirSom.Play(); // iniciando o som.
				extraCross.SetActive(false);
				fxBrilhoItem.SetActive(false);

			}
			
		}
		if (distancia >= 2) {
			acaoDisplay.SetActive (false);
			acaoTxt.SetActive (false);
		}
	}
	void OnMouseExit () { // quando o mouse não está a frente do objeto.
		extraCross.SetActive(false);
		crosshair.SetActive(true);

		acaoDisplay.SetActive (false);
		acaoTxt.SetActive (false);
	}

	IEnumerator AcharLivro() //Rotina da intro do Jogador
	{
		yield return new WaitForSeconds(1.5f); //Espera esse tempo	
		textBox.GetComponent<Text>().text = "That's weird, my book isn't here. Where did you end up?"; //Mostra o texto
		

		yield return new WaitForSeconds(2); //Espera mais este tempo
		textBox.GetComponent<Text>().text = ""; //Reseta o texto	
		
	}
}
