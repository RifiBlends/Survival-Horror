using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PegarLivro : MonoBehaviour {
	public float distancia;
	public GameObject acaoDisplay; // hud tecla de ação.
	public GameObject acaoTxt; // hud da exibição da ação.
	//public GameObject gaveta; // gameObject da porta.
	public GameObject crosshair;
	public GameObject extraCross;
	//public AudioSource coletarSom; // Som quando coleta qualquer item.
	public GameObject fxBrilhoItem;
	public GameObject livroFake; //Livro que está em cena.
	public GameObject textBox;

	// Update is called once per frame
	void Update () {
		distancia = PlayerCasting.distanciaAlvo; // pegando o valor da variável do RayCast anterior.

	}
	void OnMouseOver () { // quando o mouse está sobre o objeto.
		if (distancia <= 2) {
			extraCross.SetActive(true);
			crosshair.SetActive(false);

			acaoTxt.GetComponent<Text>().text = "Pick up the book";
			acaoDisplay.SetActive (true);
			acaoTxt.SetActive (true);
		}
		if (Input.GetButtonDown ("BtnAcao")){ // quando apertar o botão.
			if (distancia <= 2) { // e a distância for menor ou igual a 2.
				StartCoroutine(Banheiro());
				this.GetComponentInChildren<BoxCollider>().enabled = false; // desliga o collider da porta.
				acaoDisplay.SetActive (false); 
				acaoTxt.SetActive (false);
				//gaveta.GetComponent<Animation>().Play("porta01anim"); // iniciando a animação da porta.
				//abrirSom.Play(); // iniciando o som.
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

	IEnumerator Banheiro() //Rotina da intro do Jogador
	{
		livroFake.GetComponent<MeshRenderer>().enabled = false;
		yield return new WaitForSeconds(1f); //Espera esse tempo		
		textBox.GetComponent<Text>().text = "Finally! I found my book, I think I should go to the bathroom before I go to bed."; //Mostra o texto

		yield return new WaitForSeconds(2f); //Espera mais este tempo
		textBox.GetComponent<Text>().text = ""; //Reseta o texto	

		livroFake.SetActive(false);
	}
}
