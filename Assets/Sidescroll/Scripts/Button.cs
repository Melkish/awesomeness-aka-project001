using UnityEngine;
using System.Collections;

public class Button : MonoBehaviour {
	
	void OnTriggerEnter2D (Collider2D other) {
		if(other.CompareTag("Player")){
			other.GetComponent<PlayerVariables>();
			Destroy(gameObject);
			Destroy(GameObject.Find("Doorclosed"));
		
			
		}
	}
}
