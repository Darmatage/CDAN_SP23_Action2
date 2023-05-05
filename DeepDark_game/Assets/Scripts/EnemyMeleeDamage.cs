using System.Collections.Generic;
using System.Collections;
using UnityEngine;

public class EnemyMeleeDamage : MonoBehaviour {
	public Animator anim1;
	public Animator anim2;
	private Renderer rend;
	public GameObject healthLoot;
	public int maxHealth = 100;
	public int currentHealth;
	public AudioSource SFX_die;
	public AudioSource SFX_injured;
	 
	void Start(){
		rend = GetComponentInChildren<Renderer> ();
		//anim = GetComponentInChildren<Animator> ();
		currentHealth = maxHealth;
	}

	public void TakeDamage(int damage){
		currentHealth -= damage;
			
		//rend.material.color = new Color(2.4f, 0.9f, 0.9f, 1f);
		//StartCoroutine(ResetColor());
		anim1.SetTrigger ("getHurt");
		anim2.SetTrigger ("getHurt");
		if (!SFX_injured.isPlaying){
				SFX_injured.Play();
		}
		if (currentHealth <= 0){
			Die();
					 
		}
	}

	void Die(){
		Instantiate (healthLoot, transform.position, Quaternion.identity);
		//anim1.SetTrigger ("KO");
		//anim2.SetTrigger ("KO");
		SFX_die.Play();
		GetComponent<Collider2D>().enabled = false;
		StartCoroutine(Death());
	}

	IEnumerator Death(){
		yield return new WaitForSeconds(0.5f);
		Debug.Log("You Killed a baddie. You deserve loot!");
		Destroy(gameObject);
	}

	IEnumerator ResetColor(){
		yield return new WaitForSeconds(0.5f);
		rend.material.color = Color.white;
	}
}

