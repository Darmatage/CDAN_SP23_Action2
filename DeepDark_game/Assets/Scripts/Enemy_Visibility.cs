using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Visibility : MonoBehaviour{

	public float visibilityThreshold = 3.5f;
	public SpriteRenderer enemySprite;
	private float distanceToPlayer;
	private Transform player;


    void Start(){
        player = GameObject.FindWithTag("Player").GetComponent<Transform>();
    }


    void Update(){
        distanceToPlayer = Vector3.Distance(transform.position, player.position);
		
		if ((distanceToPlayer <= visibilityThreshold)&&(GameHandler.torchOn == true)){
			enemySprite.color = new Color(2.55f, 2.55f, 2.55f, 1f);
		}
		else {
			enemySprite.color = new Color(2.55f, 2.55f, 2.55f, 0.2f);
		}
		
		
		
    }
	
	
	
}
