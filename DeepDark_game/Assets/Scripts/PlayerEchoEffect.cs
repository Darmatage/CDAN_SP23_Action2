using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerEchoEffect : MonoBehaviour{
	//one of two scripts that produce the echo effect, along with Player_EchoReveal
	private Animator anim;
	public GameObject circleWaveVFX;
	public float echoRadius = 20f;  // target scale
	public AudioSource echolocation_final;

	//public float targetScale;
	public float timeToLerp = 0.5f;
	public float scaleModifier;
	float scaleModifierStart = 1;

	void Start(){
		anim = GetComponentInChildren<Animator>();
		
	}

    void Update(){
		//listener, activate waveVFX
        if ((Input.GetKeyDown("e"))&&(GameHandler_Lights.torchOn == false)&&(GameHandler_Lights.helmetOn == false)&&(GameHandler_Lights.canEcho)){
			GameObject newWave = Instantiate (circleWaveVFX, transform.position, Quaternion.identity);
			StartCoroutine(EchoWave(newWave));
			anim.SetTrigger("echo");
			GameHandler_Lights.canEcho = false;
			echolocation_final.Play();
		}
		
		
    }
	
	
	//enable wave scaling, destroy after delay
	IEnumerator EchoWave(GameObject theWave){
		float time = 0;
		scaleModifier = scaleModifierStart;
		float startValue = 0.1f;
		Vector3 startScale = theWave.transform.localScale;
		//Debug.Log("wave start size = " + theWave.transform.localScale);
		while (time < timeToLerp){
			scaleModifier = Mathf.Lerp(startValue, echoRadius, time / timeToLerp);
			theWave.transform.localScale = startScale * scaleModifier;
			time += Time.deltaTime;
			yield return null;
		}
		
		//reverse
		time = 0;
		scaleModifier = scaleModifierStart;
		startScale = theWave.transform.localScale;
		//Debug.Log("wave peak size = " + theWave.transform.localScale);
		while (time < timeToLerp){
			scaleModifier = Mathf.Lerp(echoRadius, startValue, time / timeToLerp);
			theWave.transform.localScale = startScale * scaleModifier/echoRadius;
			time += Time.deltaTime;
			yield return null;
		}
	
		Destroy(theWave);
	}
	
}
