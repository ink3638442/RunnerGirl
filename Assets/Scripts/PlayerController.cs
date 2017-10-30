using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
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
		if (Input.GetKey(KeyCode.DownArrow))
		{
			transform.rotation = Quaternion.Euler(0, 0, 0);
			transform.Translate(Vector3.forward * 3 * Time.deltaTime);
		}
		if (Input.GetKey(KeyCode.UpArrow))
		{
			transform.rotation = Quaternion.Euler(0, -180, 0);
			transform.Translate(Vector3.forward * 3 * Time.deltaTime);
		}
		if (Input.GetKey(KeyCode.LeftArrow))
		{
			transform.rotation = Quaternion.Euler(0, 90, 0);
			transform.Translate(Vector3.forward * 3 * Time.deltaTime);
		}
		if (Input.GetKey(KeyCode.RightArrow))
		{
			transform.rotation = Quaternion.Euler(0, -90, 0);
			transform.Translate(Vector3.forward * 3 * Time.deltaTime);
		}
    }
}
