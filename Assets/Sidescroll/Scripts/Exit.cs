using UnityEngine;
using System.Collections;

public class Exit : MonoBehaviour {

	public GameObject particle1, particle2;

	IEnumerator OnTriggerEnter2D (Collider2D other) {
		if(other.CompareTag("Player")) {

			other.gameObject.SetActive(false);
			particle1.SetActive(true);
			particle2.SetActive(true);
			// particle1 och particle2 borde sättas aktiva här.

			yield return new WaitForSeconds(2f);

			// Här bör vi ladda en ny scen.
		}
	}
}
