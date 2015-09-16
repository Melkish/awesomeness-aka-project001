using UnityEngine;
using System.Collections;

public class Death : MonoBehaviour {

	void OnTriggerEnter2D (Collider2D other) {
		if(other.CompareTag("Player")) {

			// Spelaren har en funktion som heter Respawn i scriptet PlayerVariables. Anropa denna funktion för att få spelaren att börja om från sin startposition.
			other.GetComponent<PlayerVariables>().Respawn();
		}
		else {
			Destroy(other.gameObject);
			// Om det inte är en spelare som kolliderar med denna trigger bör vi ta bort det objektet.

		}
	}
}
