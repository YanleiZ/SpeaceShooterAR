using UnityEngine;
using System.Collections;

public class DestroyByContact : MonoBehaviour
{
	public GameObject explosion;
	public GameObject playerExplosion;
	public int scoreValue;
	private GameController gameController;
	PlayerHealth playerStat; 
	// 每次受到攻击生命值减去10
	public int attackDamage = 10;

	void Start ()
	{
		GameObject gameControllerObject = GameObject.FindGameObjectWithTag ("GameController");
		if (gameControllerObject != null)
		{
			gameController = gameControllerObject.GetComponent <GameController>();
		}
		if (gameController == null)
		{
			Debug.Log ("Cannot find 'GameController' script");
		}

		GameObject playerObject = GameObject.FindWithTag ("Player");
		if (playerObject != null) {
			playerStat = playerObject.GetComponent <PlayerHealth> ();
		} 

		if (playerStat == null){
			Debug.Log ("Cannot find PlayerHealth");
		}
	}

	void OnTriggerEnter (Collider other)
	{
		if (other.tag == "Boundary" || other.tag == "Enemy")
		{
			return;
		}

		if (explosion != null)
		{
			Instantiate(explosion, transform.position, transform.rotation);
		}

		if (other.tag == "Player" && transform.tag != "Bolt") {
			Instantiate(playerExplosion, other.transform.position, other.transform.rotation);
			playerStat.TakeDamage(attackDamage);
		} else if(other.tag != "Player"){
			gameController.AddScore (scoreValue);
			Destroy (other.gameObject);
			Destroy (gameObject);
		}
		

	}
}