using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ButtonScript : MonoBehaviour {

	public GameObject ballTransform; 
	public InputField texto;
	public GameObject errorText;
	public Transform[] entradas; 
	int numeroEntrada = 0;


	public void ballMove(string direction){

		if (direction == "derecha") {
			switch (numeroEntrada) {
			case 0:
				ballTransform.transform.position = new Vector3 (entradas[1].transform.position.x, ballTransform.transform.position.y, ballTransform.transform.position.z);
				numeroEntrada++;
				break;
			case 1:
				ballTransform.transform.position = new Vector3 (entradas[2].transform.position.x, ballTransform.transform.position.y, ballTransform.transform.position.z);
				numeroEntrada++;
				break;
			case 2:
				ballTransform.transform.position = new Vector3 (entradas[3].transform.position.x, ballTransform.transform.position.y, ballTransform.transform.position.z);
				numeroEntrada++;
				break;
			case 3:
				ballTransform.transform.position = new Vector3 (entradas[4].transform.position.x, ballTransform.transform.position.y, ballTransform.transform.position.z);
				numeroEntrada++;
				break;
			}
		}

		if (direction == "izquierda") {
			switch (numeroEntrada) {
			case 1:
				ballTransform.transform.position = new Vector3 (entradas[0].transform.position.x, ballTransform.transform.position.y, ballTransform.transform.position.z);
				numeroEntrada--;
				break;
			case 2:
				ballTransform.transform.position = new Vector3 (entradas[1].transform.position.x, ballTransform.transform.position.y, ballTransform.transform.position.z);
				numeroEntrada--;
				break;
			case 3:
				ballTransform.transform.position = new Vector3 (entradas[2].transform.position.x, ballTransform.transform.position.y, ballTransform.transform.position.z);
				numeroEntrada--;
				break;
			case 4:
				ballTransform.transform.position = new Vector3 (entradas[3].transform.position.x, ballTransform.transform.position.y, ballTransform.transform.position.z);
				numeroEntrada--;
				break;
			}

				
		}
			
		ballTransform.GetComponent<AudioSource> ().Play ();
	
	}

	public void buttonStart(){
		if (texto.text.Length == 5) {
			ballTransform.GetComponent<Rigidbody> ().useGravity = true;
			errorText.SetActive (false);
		} else {
			errorText.SetActive (true);
		}
	}
		

	public void buttonAgain(){
		Time.timeScale = 1;
		SceneManager.LoadScene(SceneManager.GetActiveScene().name);
	}
}
