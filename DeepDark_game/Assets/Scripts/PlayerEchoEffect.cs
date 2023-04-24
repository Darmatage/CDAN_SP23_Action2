using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;


public class PlayerEchoEffect : MonoBehaviour{
	
	public GameObject circleWaveVFX;
	public float echoRadius = 20f;  // target scale

	//public float targetScale;
	public float timeToLerp = 0.5f;
	public float scaleModifier;
	float scaleModifierStart = 1;
	
	//public Tilemap tilemap;

    void Update(){
		//listener, activate waveVFX
		
        if ((Input.GetKeyDown("space"))&&(GameHandler.torchOn == false)&&(GameHandler.canEcho)){
			GameObject newWave = Instantiate (circleWaveVFX, transform.position, Quaternion.identity);
			StartCoroutine(EchoWave(newWave));
			GameHandler.canEcho = false;
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
		
		//activate raycasts
		//EchoRaycasts(theWave.transform.position);
		
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
	
	//enable Raycast
	/*
	void EchoRaycasts(Vector2 wavPos){
		Physics2D.queriesStartInColliders = false;
		for (int castAngle = 0 ; castAngle < 360 ; castAngle += 15){
			Vector3 addAngle = new Vector3(0, 0, castAngle);
			RaycastHit2D hitInfo = Physics2D.Raycast(wavPos, transform.up + addAngle, echoRadius);
			Debug.DrawLine(wavPos, hitInfo.point);
			Debug.Log("current raycast angle = " + (transform.up + addAngle));
            if (hitInfo.collider != null){
                if (hitInfo.collider.CompareTag("wall")){
                    Vector2 hitPoint = hitInfo.point;
					//Instantiate (circleWaveVFX, hitPoint, Quaternion.identity);
				//	hitInfo.collider.gameObject.GetComponent<SpriteRenderer>().color = Color.white;  
					//Vector3Int hitPointInt = new Vector3Int((int)hitPoint.x,(int)hitPoint.y,0);
                    Debug.Log(" I hit a wall = " + hitPoint);
					//tilemap.SetTileFlags(hitPointInt, TileFlags.None);
					//tilemap.SetColor(hitPointInt, Color.white);
                }
            }
            else { Debug.Log("I can't find a wall"); }
		}
	}
	*/
	
}
