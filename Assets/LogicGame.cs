using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LogicGame : MonoBehaviour {

	string[][] matrizAd = new string[][]
	   {new string[]{"Estados", "a", "b", "c"},
		new string[]{"1","ERROR","R","ERROR"},
		new string[]{"2","L","R","ERROR"},
		new string[]{"3","ERROR","R","L"},
		new string[]{"4","L","R","ERROR"},
		new string[]{"5","ERROR","ERROR","L"},
		new string[]{"6","L","R","ERROR"},
		new string[]{"7","L","R","ERROR"},
		new string[]{"8","R","ERROR","L"},
		new string[]{"9","ERROR","L","R"},
		new string[]{"10","ERROR","ERROR","R"},
		new string[]{"11","L","R","ERROR"},
		new string[]{"12","ERROR","L","R"},
		new string[]{"13","R","L","ERROR"},
		new string[]{"14","ERROR","ERROR","L"},
		new string[]{"15","R","ERROR","L"},
		new string[]{"16","R","ERROR","L"},
		new string[]{"17","R","L","ERROR"},
		new string[]{"18","ERROR","R","L"},
		new string[]{"19","L","R","ERROR"},
		new string[]{"20","R","ERROR","L"},
		new string[]{"21","ERROR","L","R"},
		new string[]{"22","L","R","ERROR"},
		new string[]{"23","R","ERROR","L"},
		}; 

	int estado = 0, estadoAnt = 0, simboloPosition = 0, letraPosition = 0;
	public InputField texto;
	string direccion = "E";
	public GameObject infoGameOver;
	public GameObject infoWin;
	void Start () {
		//palabra = texto.text;
	}
	
	// Update is called once per frame
	void Update () {
		if (direccion == "R") {
			//transform.position = new Vector3 (transform.position.x + 6.0f, transform.position.y, transform.position.z);
			GetComponent<Rigidbody> ().velocity = new Vector2 (30, GetComponent<Rigidbody> ().velocity.y);

		}else if(direccion == "L") {
			GetComponent<Rigidbody> ().velocity = new Vector2 (-30, GetComponent<Rigidbody> ().velocity.y);
			//transform.position = new Vector3 (transform.position.x - 6.0f, transform.position.y, transform.position.z);
		}
	}

	void OnCollisionEnter(Collision collision){
		if (collision.collider.tag == "estados") {
			string estateName = collision.collider.name;
			estado = Int32.Parse (estateName);
			if (estadoAnt != estado) {
				estadoAnt = estado;
				string palabra = texto.text;
				switch (palabra [simboloPosition]) {
				case 'a':
					letraPosition = 1;
					break;
				case 'b':
					letraPosition = 2;
					break;
				case 'c':
					letraPosition = 3;
					break;
				}

			/*	float velocidadR = direccion == "L"? 40.0f: 0.0f; 
				float velocidadL = direccion == "R"? -40.0f: 0.0f;
				if (direccion == "E") {
					velocidadL = -20.0f;
					velocidadR = 20.0f;
				}
				Debug.Log ("velocidadR: " + velocidadR); */
				//Debug.Log ("velocidadL: " + velocidadL);
				string matrizValor = matrizAd [estado] [letraPosition];
				direccion = matrizValor;
				if ((matrizValor == "ERROR") || (palabra [simboloPosition] != 'a' && palabra [simboloPosition] != 'b' && palabra [simboloPosition] != 'c' ) ) {
					Time.timeScale = 0;
					infoGameOver.SetActive (true);
				} /*else {
					if (matrizValor == "R") {
						//transform.position = new Vector3 (transform.position.x + 6.0f, transform.position.y, transform.position.z);
						//GetComponent<Rigidbody> ().velocity = new Vector2 (2, GetComponent<Rigidbody> ().velocity.y);

					} else {
						//GetComponent<Rigidbody> ().velocity = new Vector2 (-2, GetComponent<Rigidbody> ().velocity.y);
						//transform.position = new Vector3 (transform.position.x - 6.0f, transform.position.y, transform.position.z);

					}
				} */
				simboloPosition++;
			}
		}

		if (collision.collider.tag == "Finish") {
				infoWin.SetActive (true);
		}
	}
		

		
}
