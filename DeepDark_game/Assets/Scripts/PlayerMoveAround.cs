using System.Collections.Generic;
using System.Collections;
using UnityEngine;

public class PlayerMoveAround : MonoBehaviour {

      private Animator anim;
      //public AudioSource WalkSFX;
      private Rigidbody2D rb2D;
      private bool FaceRight = false; // determine which way player is facing.
      public static float runSpeed = 10f;
      public float startSpeed = 10f;
      public bool isAlive = true;

	private AudioSource StepToPlay;
	public AudioSource step1;
	public AudioSource step2;
	public AudioSource step3;
	public AudioSource step4;
	public AudioSource step5;
	public AudioSource step6;

	public AudioSource step1water;
	public AudioSource step2water;
	public AudioSource step3water;
	public AudioSource step4water;
	public AudioSource step5water;
	public AudioSource step6water;
	
	private bool isInWater = false;

      void Start(){
           anim = gameObject.GetComponentInChildren<Animator>();
           rb2D = transform.GetComponent<Rigidbody2D>();
      }

	void Update(){
		  
		//if (GameHandler_Lights.torchOn == true){anim.SetBool ("isHoldingTorch", true);} 
		//else {anim.SetBool ("isHoldingTorch", false);}
		
		//if (GameHandler_Lights.helmetOn == true){anim.SetBool ("isWearingMiner", true);} 
		//else {anim.SetBool ("isWearingMiner", false);}
		  
            //NOTE: Horizontal axis: [a] / left arrow is -1, [d] / right arrow is 1
            //NOTE: Vertical axis: [w] / up arrow, [s] / down arrow
            Vector3 hvMove = new Vector3(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"), 0.0f);
           if (isAlive == true){
                  transform.position = transform.position + hvMove * runSpeed * Time.deltaTime;

                  if ((Input.GetAxis("Horizontal") != 0) || (Input.GetAxis("Vertical") != 0)){
                       anim.SetBool ("walk", true); 
					   Debug.Log("I set walk = true");
					   
                  //     if (!WalkSFX.isPlaying){
                  //           WalkSFX.Play();
                  //     }
                  } else {
                       anim.SetBool ("walk", false);
					   Debug.Log("I set walk = false");
                  //     WalkSFX.Stop();
                 }

                  // Turning. Reverse if input is moving the Player right and Player faces left.
                 if ((hvMove.x <0 && !FaceRight) || (hvMove.x >0 && FaceRight)){
                        playerTurn();
                  }
            }
			if ((Input.GetAxisRaw("Horizontal")!= 0) || (Input.GetAxisRaw("Vertical")!= 0)){
                     PlaySteps();
              } else {
                     StopSteps();
              }
      }
	public void PlaySteps(){
		if ((StepToPlay !=null)&&(StepToPlay.isPlaying)){
			return;
		} else {
			int StepNum = Random.Range(1, 6);

			if (StepNum == 1){ 
				if (!isInWater){StepToPlay = step1;}
				else {StepToPlay = step1water;}
			}
			else if (StepNum == 2){ 
				if (!isInWater){StepToPlay = step2;}
				else {StepToPlay = step2water;}
			}
			else if (StepNum == 3){ 
				if (!isInWater){StepToPlay = step3;}
				else {StepToPlay = step3water;}
			}
			else if (StepNum == 4){ 
				if (!isInWater){StepToPlay = step4;}
				else {StepToPlay = step5water;}
			}
			else if (StepNum == 5){ 
				if (!isInWater){StepToPlay = step5;}
				else {StepToPlay = step5water;}
			}
			else if (StepNum == 6){ 
				if (!isInWater){StepToPlay = step6;}
				else {StepToPlay = step6water;}
			}

			StepToPlay.Play();
		}
	}

	public void StopSteps(){
             if ((StepToPlay != null) && (StepToPlay.isPlaying)){
                   StepToPlay.Stop();
             }
	}

	private void playerTurn(){
            // NOTE: Switch player facing label
            FaceRight = !FaceRight;

            // NOTE: Multiply player's x local scale by -1.
            Vector3 theScale = transform.localScale;
            theScale.x *= -1;
            transform.localScale = theScale;
	}
	
	public void OnTriggerEnter2D(Collider2D other){
		if (other.gameObject.tag == "Water"){
			isInWater = true;
		}
	}
	
		public void OnTriggerExit2D(Collider2D other){
		if (other.gameObject.tag == "Water"){
			isInWater = false;
		}
	}
	
}