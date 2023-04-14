using System.Collections.Generic;
using System.Collections;
using UnityEngine;

public class EnemyMoveHit : MonoBehaviour {

	public Animator anim;
	public Rigidbody2D rb2D;
	public float speed = 4f;
	private Transform target;
	public int damage = 10;
	public float knockBackForce = 20f; 

	public int EnemyLives = 3;
	private GameHandler gameHandler;

	public float attackRange = 10;
	public bool isAttacking = true;
	private float scaleX;

	public bool isMole = true;
	public bool isStunned = false;

	void Start () {
		anim = GetComponentInChildren<Animator> ();
		rb2D = GetComponent<Rigidbody2D> ();
		scaleX = gameObject.transform.localScale.x;

		if (GameObject.FindGameObjectWithTag ("Player") != null) {
			target = GameObject.FindGameObjectWithTag ("Player").GetComponent<Transform> ();
		}

		if (GameObject.FindWithTag ("GameHandler") != null) {
			gameHandler = GameObject.FindWithTag ("GameHandler").GetComponent<GameHandler> ();
		}
	}

	void Update () {
		float DistToPlayer = Vector3.Distance(transform.position, target.position);

		if ((target != null) && (DistToPlayer <= attackRange) && (!isStunned)){
			transform.position = Vector2.MoveTowards (transform.position, target.position, speed * Time.deltaTime);
			anim.SetBool("walk", true);
			//flip enemy to face player direction. Wrong direction? Swap the * -1.
			if (target.position.x > gameObject.transform.position.x){
				gameObject.transform.localScale = new Vector2(scaleX, gameObject.transform.localScale.y);
			} else {
				gameObject.transform.localScale = new Vector2(scaleX * -1, gameObject.transform.localScale.y);
			}
		}
		else { anim.SetBool("walk", false);}
	}

	public void OnCollisionEnter2D(Collision2D other){
		if ((other.gameObject.tag == "Player") && (!isStunned)) {
			isAttacking = true;
			anim.SetTrigger("attack");
			gameHandler.playerGetHit(damage);
			//rend.material.color = new Color(2.4f, 0.9f, 0.9f, 0.5f);
			//StartCoroutine(HitEnemy());

		//This method adds force to the player, pushing them back without teleporting (choose above or below).
			Rigidbody2D pushRB = other.gameObject.GetComponent<Rigidbody2D>();
			Vector2 moveDirectionPush = rb2D.transform.position - other.transform.position;
			pushRB.AddForce(moveDirectionPush.normalized * knockBackForce * - 1f, ForceMode2D.Impulse);
			StartCoroutine(EndKnockBack(pushRB));
		}
	} 
	   
	   
       public void OnCollisionExit2D(Collision2D other){
              if (other.gameObject.tag == "Player") {
                     isAttacking = false;
                     //anim.SetBool("Attack", false);
              }
       }
	   
	    IEnumerator EndKnockBack(Rigidbody2D otherRB){
              yield return new WaitForSeconds(0.2f);
              otherRB.velocity= new Vector3(0,0,0);
       }
	   
	public void StunMole(){
		if (isMole == true){
			isStunned = true;
			anim.SetBool("stun", true);
		}
	}
	
	public void UnstunMole(){
		if (isMole == true){
			isStunned = false;
			anim.SetBool("stun", false);
		}
	}
	   
	//DISPLAY the range of enemy's attack when selected in the Editor
	void OnDrawGizmosSelected(){
		Gizmos.DrawWireSphere(transform.position, attackRange);
	}
}