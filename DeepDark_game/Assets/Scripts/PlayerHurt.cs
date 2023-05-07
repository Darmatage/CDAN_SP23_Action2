using System.Collections.Generic;
using System.Collections;
using UnityEngine;

public class PlayerHurt: MonoBehaviour{

      public Animator anim;
      private Rigidbody2D rb2D;
	  public AudioSource player_injured;
	  public AudioSource player_die;

      void Start(){
           anim = gameObject.GetComponentInChildren<Animator>();
           rb2D = transform.GetComponent<Rigidbody2D>();           
      }

	void Update(){
		/*
		if (GameHandler_Lights.torchOn == true){anim.SetBool ("isHoldingTorch", true);} 
		else {anim.SetBool ("isHoldingTorch", false);}
		
		if (GameHandler_Lights.helmetOn == true){anim.SetBool ("isWearingMiner", true);} 
		else {anim.SetBool ("isWearingMiner", false);}
		*/
	}


      public void playerHit(){
		  player_injured.Play();
            anim.SetTrigger("getHurt");
      }

      public void playerDead(){
            rb2D.isKinematic = true;
			player_die.Play();
            anim.SetTrigger ("KO");
      }
}