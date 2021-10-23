using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;
using UnityEngine.UI;

public class AOpening : MonoBehaviour {
	public GameObject thePlayer;
	public GameObject fadeScreenIn;
	public GameObject textBox;

	void Start () {
		thePlayer.GetComponent<FirstPersonController>().enabled = false; //Desativando a movimentação do jogador
		StartCoroutine(ScenePlayer());		
	}

	IEnumerator ScenePlayer() //Rotina da intro do Jogador
    {
		yield return new WaitForSeconds(1.5f); //Espera esse tempo

		fadeScreenIn.SetActive(false); //Desativa FadeScreenIn
		textBox.GetComponent<Text>().text = "I'd like to read my book before bed..."; //Mostra o texto

		yield return new WaitForSeconds(2); //Espera mais este tempo
		textBox.GetComponent<Text>().text = ""; //Reseta o texto
		thePlayer.GetComponent<FirstPersonController>().enabled = true; //Reativa o comando do jogador
    }
	
	
}
