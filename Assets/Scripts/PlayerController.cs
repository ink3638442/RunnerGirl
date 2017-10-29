using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
	[SerializeField]
	Vector3 upDown_vec = new Vector3(0, 0, 3);

	[SerializeField]
	Vector3 leftRight_vec = new Vector3(3, 0, 0);

	Animator animator;

    // Use this for initialization
    void Start()
    {
		animator = GetComponent<Animator>();
		animator.SetFloat("Run", 1.0f);
    }

    // Update is called once per frame
    void Update()
    {
		if (Input.GetKey(KeyCode.DownArrow)) transform.Translate(upDown_vec * Time.deltaTime);
		if (Input.GetKey(KeyCode.UpArrow)) transform.Translate(-upDown_vec * Time.deltaTime);
		if (Input.GetKey(KeyCode.LeftArrow)) transform.Translate(leftRight_vec * Time.deltaTime);
		if (Input.GetKey(KeyCode.RightArrow)) transform.Translate(-leftRight_vec * Time.deltaTime);
    }
}
