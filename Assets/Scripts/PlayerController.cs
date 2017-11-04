using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
	Animator animator;
	
	[SerializeField]
	GameObject  gameManager;
	GameManager gm;

	[SerializeField]
	int gameOverLine = -15;

    // Use this for initialization
    void Start()
    {
		animator = GetComponent<Animator>();
		animator.SetFloat("Run", 1.0f);

		gm = gameManager.GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
		// カクカク曲がるようにGetAxisRawを使用　-1, 0, 1の値のみ
		float vertical   = Input.GetAxisRaw("Vertical");
		float horizontal = Input.GetAxisRaw("Horizontal");

		if (vertical != 0)
		{
			int direction = vertical < 0 ? 0 : -180;
			transform.rotation = Quaternion.Euler(0, direction, 0);
			transform.Translate(Vector3.forward * 3 * Time.deltaTime);
		}
		
		if (horizontal != 0)
		{
			int direction = horizontal < 0 ? 90 : -90;
			transform.rotation = Quaternion.Euler(0, direction, 0);
			transform.Translate(Vector3.forward * 3 * Time.deltaTime);
		}

		if (transform.position.y < gameOverLine)
		{
			gm.SetGameOverBool();
		}
    }

	void OnCollisionEnter(Collision collision)
    {
		if (collision.gameObject.tag == "Goal")
		{
			gm.SetGameClearBool();
		}
	}
}
