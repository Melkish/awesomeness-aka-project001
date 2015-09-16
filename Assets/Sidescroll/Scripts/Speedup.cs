using UnityEngine;
using System.Collections;

public class Speedup : MonoBehaviour {

	private float startSpeed;
	private bool active = true;

	IEnumerator OnTriggerEnter2D (Collider2D other) {
		if(other.CompareTag("Player") && active) {
			active = false;
			startSpeed = other.GetComponent<PlatformInputs>().speed;

			// Här bör vi ändra på speed under other.GetComponent<PlatformInputs>() till att t.ex. vara sig själv * 1.5f; 
			other.GetComponent<PlatformInputs>().speed=startSpeed*1.5f;

			yield return new WaitForSeconds(3f);
			other.GetComponent<PlatformInputs>().speed=startSpeed;
			active = true;
		}
	}
}
