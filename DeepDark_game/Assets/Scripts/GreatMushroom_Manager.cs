using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GreatMushroom_Manager : MonoBehaviour{
	
	public GameObject mushroomArt_dying;
	public GameObject mushroomArt_healthy;
	public GameObject sparkleVFXprefab;
	
	bool isHealed = false;
	float theTimer = 0;
	public float VFXspawnRate = 0.5f;
	public float VFXrangeX = 3;
	public float VFXrangeY = 3;
	
    void Start(){
        mushroomArt_dying.SetActive(true);
		mushroomArt_healthy.SetActive(false);
    }

	void FixedUpdate(){
		if (isHealed==true){
			theTimer += 0.01f;
			if (theTimer >= VFXspawnRate){
				MakeVFX();
				theTimer = 0;
			}
		}
	}

	public void OnCollisionEnter2D(Collision2D other){
		if ((other.gameObject.tag=="Player")&&(GameHandler.Level1IsEnd==true)){
			mushroomArt_dying.SetActive(false);
			mushroomArt_healthy.SetActive(true);
			isHealed = true;
			GameHandler_Level1Manager.mushroomHealed = true;
		}
	}
	
	void MakeVFX(){
		Vector3 pos;
		float offsetX = Random.Range(-VFXrangeX,VFXrangeX); 
		float offsetY = Random.Range(-VFXrangeY,VFXrangeY);
		pos = new Vector3(transform.position.x + offsetX, transform.position.y + offsetY, 0f);
		GameObject sparkleVFX = Instantiate(sparkleVFXprefab, pos, Quaternion.identity);
		DestroyVFX(sparkleVFX);
	}
	
	IEnumerator DestroyVFX(GameObject theVFX){
		yield return new WaitForSeconds(2f);
		Destroy(theVFX);
	}
	
}
