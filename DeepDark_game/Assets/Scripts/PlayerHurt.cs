using System.Collections.Generic;
using System.Collections;
using UnityEngine;

public class PlayerHurt: MonoBehaviour{

      //public Animator animator;
      private Rigidbody2D rb2D;
	  public AudioSource player_injured;
	  public AudioSource player_die;

      void Start(){
           //animator = gameObject.GetComponentInChildren<Animator>();
           rb2D = transform.GetComponent<Rigidbody2D>();           
      }

      public void playerHit(){
		  player_injured.Play();
            //animator.SetTrigger ("GetHurt");
      }

      public void playerDead(){
            rb2D.isKinematic = true;
			player_die.Play();
            //animator.SetTrigger ("Dead");
      }
}