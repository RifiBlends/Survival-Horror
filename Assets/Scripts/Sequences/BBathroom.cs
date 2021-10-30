using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;
using UnityEngine.UI;

public class BBathroom : MonoBehaviour {

	public GameObject thePlayer;
	public GameObject fadeScreenIn;
	public GameObject textBox;

	public AudioSource bathroomSound;
	public AudioSource weirdSound;

	public void OnTriggerEnter()
	{
		fadeScreenIn.SetActive(true);
		thePlayer.GetComponent<FirstPersonController>().enabled = false; //Desativando a movimentação do jogador

		bathroomSound.Play(); // Som da descarga.

		thePlayer.transform.position = new Vector3(-111f, thePlayer.transform.position.y, -1);

		weirdSound.Play();
		StartCoroutine(WeirdNoises());
	}

	IEnumerator WeirdNoises() //Rotina da intro do Jogador
	{
		yield return new WaitForSeconds(5f); //Espera esse tempo
		fadeScreenIn.SetActive(false); //Desativa FadeScreenIn

		textBox.GetComponent<Text>().text = "Huh? What are those noises? I think they're coming from outside the house..."; //Mostra o texto

		yield return new WaitForSeconds(2); //Espera mais este tempo
		textBox.GetComponent<Text>().text = ""; //Reseta o texto
		thePlayer.GetComponent<FirstPersonController>().enabled = true; //Reativa o comando do jogador
	}



	
}
