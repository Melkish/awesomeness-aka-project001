using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour {

	// Som komileringsfelet säger saknas en deklaration för variabeln speed som sätter hastigheten för denna fiende. Detta är en float som bör vara public. Ett bra värde verkade vara 3f.
	public float speed = 3f;
	public float damage = 25f;

	private Transform frontCheck;
	private float facingRight = -1f;
	public LayerMask layerMask;
	
	void Start () {
		frontCheck = transform.Find("FrontCheck");
	}
	
	void Update () {

		transform.Translate(new Vector3(facingRight,0f,0f)*speed*Time.deltaTime); // Vilket håll ska detta gameObject åka åt?

		if(Physics2D.OverlapPoint(frontCheck.position, layerMask)){
			facingRight *= -1f;
			transform.localScale = new Vector3(transform.localScale.y * -facingRight, transform.localScale.y, transform.localScale.z);

		}
	}

	void OnTriggerStay2D(Collider2D other) {
		if(other.CompareTag("Player")){

			// Kolliderar detta objekt med spelaren bör denna göra via Harm(float) funktionen som finns i spelarens PlayerVariables script.
			other.GetComponent<PlayerVariables>().Harm(damage);
		}
	}

	public IEnumerator Die(){
		GetComponent<Collider2D>().enabled = false;
		enabled = false;
		GetComponent<Rigidbody2D>().AddForce(new Vector2(2f,13f),ForceMode2D.Impulse);
		transform.localScale = new Vector3(transform.localScale.x, -transform.localScale.y, transform.localScale.z);
		
		// Denna funktion stänger av diverse funktioner för att få fienden se levande ut när den dör (...) men objektet tas bort direkt när man träffar det. Kan vi lägga in en paus? 2 sekunder verkade fungera bra.

		yield return new WaitForSeconds(2.0f);

	}
}
