using UnityEngine;
using System.Collections;

public class KillEnemy : MonoBehaviour {

	void OnTriggerEnter2D(Collider2D other) {
		if(other.CompareTag("Player")){
			GetComponent<Collider2D>().enabled = false;
			StartCoroutine(transform.parent.gameObject.GetComponent<Enemy>().Die());
		}
	}
}
