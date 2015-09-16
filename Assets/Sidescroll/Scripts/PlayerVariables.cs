using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PlayerVariables : MonoBehaviour {

	public float health = 100f;

	[HideInInspector]
	public int coins = 0;
	
	private float damageTimer = 1f;

	private Slider healthSlider;
	private Text coinUI;
	private Vector3 startPos;


	void Start () {
		healthSlider = GameObject.Find("HealthSliderUI").GetComponent<Slider>();
		coinUI = GameObject.Find("CoinTextUI").GetComponent<Text>();
		startPos = transform.position;
	}

	void Update () {
		// damageTimer bör öka med tiden som gått från senaste uppdate-loopen. Tiden räknas ut med Time.deltaTime;
		damageTimer = Time.deltaTime + damageTimer;
		healthSlider.value = Mathf.Lerp(healthSlider.value, health, Time.deltaTime);
		coinUI.text = coins+"";
	}

	public void Harm(float dmg){

		// Om damageTimer är större än en sekund bör vi sänka health med damage. Vi bör även sätta damageTimer till 0f för att nollställa timern.
		if (damageTimer > 1f) {
			health = health - dmg;
			Debug.Log("health="+health+" damageTimer="+damageTimer+ "deltatime"+Time.deltaTime);
			damageTimer = 0f;
		
		}
		// Om health är mindre än 1f så bör vi starta funktionen Die(). Det kan bara göras med StartCoroutine eftersom Die() är en IEnumerator.
		if (health < 1f) {
			StartCoroutine(Die());
		}
	}

	IEnumerator Die() {
		GetComponent<Collider2D>().enabled = false;
		GetComponent<PlatformInputs>().enabled = false;
		GetComponent<Rigidbody2D>().AddForce(new Vector2(1f,5f),ForceMode2D.Impulse);
		transform.localScale = new Vector3(transform.localScale.x, -1f, 1f);
		
		yield return new WaitForSeconds(2f);
		Respawn ();

		// Application.LoadLevel(0); //Load some scene
		// Eller kalla på Respawn-funktionen vi har gjort? 
	}

	public void Respawn () {

		// Här nollställer vi ett gäng med variabler för att få spelaren att börja om spelet istället för att helst starta om scenen. 
		health = 100f;
		damageTimer = 1f;
		// Sätt position, som finns under detta gameObjects transform, till Vector3n startPos.
		transform.position = startPos;
		GetComponent<Collider2D>().enabled = true;
		GetComponent<PlatformInputs>().enabled = true;
		transform.localScale = new Vector3(transform.localScale.x, 1f, 1f);

		// Sätt tillbaka spelarens hälsa till 100f. 
	}
}
