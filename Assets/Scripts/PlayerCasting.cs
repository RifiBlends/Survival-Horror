using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCasting : MonoBehaviour {

	public static float distanciaAlvo;// variável estática de distância ao alvo
	public float alvo; // variável até o alvo
	// Update is called once per frame
	void Update () {
		RaycastHit Hit; // variável de RayCast
		// verificando se o RayCast atingiu algum Collider
		if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out Hit)){
			alvo = Hit.distance;
			distanciaAlvo = alvo;
		}
	}
}
