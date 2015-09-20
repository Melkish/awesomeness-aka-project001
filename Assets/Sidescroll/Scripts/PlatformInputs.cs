using UnityEngine;
using System.Collections;

public class PlatformInputs : MonoBehaviour {

	Rigidbody2D rigidBody;
	public float speed = 10f;
	public float jumpHeight = 14f;

	private Transform groundCheck;
	private bool grounded = false;

	private Animator anim;
	private float horizontalDirection;

	void Start () {
		rigidBody = GetComponent<Rigidbody2D>();
		anim = GetComponent<Animator>();
		groundCheck = transform.Find("GroundCheck");
	}

	void Update () {
		horizontalDirection = Input.GetAxis("Horizontal"); // Det finns en klass som heter Input, den har en funktion som heter GetAxis - Det finns också en string som heter Horizontal som GetAxis tar.

		grounded = Physics2D.OverlapPoint(groundCheck.position);

		// Vi bör hoppa när vi använder Space-knappen. Detta ska vi bara göra när vi är grounded. Dvs, byt ut "false" i if-satsen nedan mot någonting som letar efter en typ av GetKeyDown under Input-klassen. 
		if(grounded && Input.GetKeyDown(KeyCode.Space)){
			rigidBody.velocity += new Vector2(rigidBody.velocity.x,jumpHeight);
		
		}

		anim.SetFloat("Speed", Mathf.Abs(horizontalDirection));
		
		if(horizontalDirection > 0)
			Flip(1);
		else if(horizontalDirection < 0)
			Flip(-1);

		// Vi borde förflytta spelaren via funktionen Translate som finns under dess transform. Här bör horizontalDirection, speed och Time.deltaTime användas
		transform.Translate (horizontalDirection * speed * Time.deltaTime, 0f, 0f);

	}

	void Flip (int facingRight) {
		Vector3 myScale = transform.localScale;
		myScale.x = facingRight; // Vrider sig inte karaktären efter det vi har skickat med till Flip-funktionen?
		transform.localScale = myScale;
	}
}
