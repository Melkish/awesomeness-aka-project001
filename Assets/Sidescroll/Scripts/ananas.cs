using UnityEngine;
using System.Collections;

public class Ananas : MonoBehaviour {

	void OnTriggerEnter2D (Collider2D other) {
		if(other.CompareTag("Player")){
			other.GetComponent<PlayerVariables>().timeleft = other.GetComponent<PlayerVariables>().timeleft + 15f;
			Destroy(gameObject);
			// Leta fram komponenten PlayerVariables på spelaren (det kolliderade objektet) och öka variablen coins med värdet på detta mynt.
			// Ta bort myntet från spelet

		}
	}
}
