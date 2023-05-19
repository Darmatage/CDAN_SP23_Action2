using System.Collections.Generic;
using System.Collections;
using UnityEngine;

public class PlayerAttackMelee : MonoBehaviour{

      public Animator anim;
      public Transform attackPt;
      public float attackRange = 0.5f;
      public float attackRate = 2f;
      private float nextAttackTime = 0f;
      public int attackDamage = 40;
      public LayerMask enemyLayers;
	  public float knockBackForce = 5f;
	   public AudioSource player_attack;
	// public AudioSource punch;
      void Start(){
           anim = gameObject.GetComponentInChildren<Animator>();
      }

	void Update(){
		/*
		if (GameHandler_Lights.torchOn == true){anim.SetBool ("isHoldingTorch", true);} 
		else {anim.SetBool ("isHoldingTorch", false);}
		
		if (GameHandler_Lights.helmetOn == true){anim.SetBool ("isWearingMiner", true);} 
		else {anim.SetBool ("isWearingMiner", false);}
		*/
		  
		  
           if (Time.time >= nextAttackTime){
                  //if (Input.GetKeyDown(KeyCode.Space))
                 if (Input.GetAxis("Attack") > 0){
                        Attack();
                        nextAttackTime = Time.time + 1f / attackRate;
						 player_attack.Play(); 
						
                  }
            }
      }

      void Attack(){
            anim.SetTrigger ("attack");
            Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPt.position, attackRange, enemyLayers);
           
            foreach(Collider2D enemy in hitEnemies){
                  Debug.Log("We hit " + enemy.name);
                  enemy.GetComponent<EnemyMeleeDamage>().TakeDamage(attackDamage);
				  //knockback part1
					Rigidbody2D enemyRB = enemy.GetComponent<Rigidbody2D>();
					Vector2 moveDirectionPush = gameObject.transform.position - enemy.transform.position;
					enemyRB.AddForce(moveDirectionPush.normalized * knockBackForce * - 1f, ForceMode2D.Impulse);
					StartCoroutine(EndKnockBack(enemyRB));
				  
            }
      }
	  
	  //knockback part2
		IEnumerator EndKnockBack(Rigidbody2D otherRB){
              yield return new WaitForSeconds(0.3f);
              otherRB.velocity= new Vector3(0,0,0);
       }
	   
      //NOTE: to help see the attack sphere in editor:
      void OnDrawGizmosSelected(){
           if (attackPt == null) {return;}
            Gizmos.DrawWireSphere(attackPt.position, attackRange);
      }
}
