using System.Collections.Generic;
using System.Collections;
using UnityEngine;

public class PlayerMoveAround : MonoBehaviour {

      //public Animator anim;
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

      void Start(){
           //anim = gameObject.GetComponentInChildren<Animator>();
           rb2D = transform.GetComponent<Rigidbody2D>();
      }

      void Update(){
            //NOTE: Horizontal axis: [a] / left arrow is -1, [d] / right arrow is 1
            //NOTE: Vertical axis: [w] / up arrow, [s] / down arrow
            Vector3 hvMove = new Vector3(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"), 0.0f);
           if (isAlive == true){
                  transform.position = transform.position + hvMove * runSpeed * Time.deltaTime;

                  if ((Input.GetAxis("Horizontal") != 0) || (Input.GetAxis("Vertical") != 0)){
                  //     anim.SetBool ("Walk", true);
                  //     if (!WalkSFX.isPlaying){
                  //           WalkSFX.Play();
                  //     }
                  } else {
                  //     anim.SetBool ("Walk", false);
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

                   if (StepNum == 1){ StepToPlay = step1;}
                   else if (StepNum == 2){ StepToPlay = step2;}
                   else if (StepNum == 3){ StepToPlay = step3;}
                   else if (StepNum == 4){ StepToPlay = step4;}
                   else if (StepNum == 5){ StepToPlay = step5;}
                   else if (StepNum == 6){ StepToPlay = step6;}

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
}