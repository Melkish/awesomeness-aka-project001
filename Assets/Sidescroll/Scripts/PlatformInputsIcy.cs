using UnityEngine;
using System.Collections;

public class PlatformInputsIcy : MonoBehaviour {
	
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
		horizontalDirection = Input.GetAxis("Horizontal"); 
		
		grounded = Physics2D.OverlapPoint(groundCheck.position);
		

		if(grounded && Input.GetKeyDown(KeyCode.Space)){
			//	rigidBody.velocity += new Vector2(rigidBody.velocity.x,jumpHeight);
			rigidBody.AddForce(new Vector2(0f,700f));
		}
		
		anim.SetFloat("Speed", Mathf.Abs(horizontalDirection));
		
		if(horizontalDirection > 0)
			Flip(1);
		else if(horizontalDirection < 0)
			Flip(-1);

		rigidBody.AddForce(new Vector2(horizontalDirection * 500f * Time.deltaTime, 0f));
	}
	
	void Flip (int facingRight) {
		Vector3 myScale = transform.localScale;
		myScale.x = facingRight; 
		transform.localScale = myScale;
	}
}