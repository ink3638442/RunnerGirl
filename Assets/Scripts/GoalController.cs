using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoalController : MonoBehaviour
{
	GameObject gameManager;
	GameManager gm;

	void Start()
	{
		gameManager = GameObject.Find("GameManager");
		gm = gameManager.GetComponent<GameManager>();
	}

	void OnCollisionEnter(Collision collision)
    {
		if (collision.gameObject.tag == "Player")
		{
			gm.SetGameClearBool();
		}
	}
}
