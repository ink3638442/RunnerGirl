using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallFloorController : MonoBehaviour
{
	bool isFall = false;
	float destroyDistance = 0;

    // Update is called once per frame
    void Update()
    {
		if (isFall) Fall();
    }

	void OnCollisionEnter(Collision collision)
    {
		StartCoroutine(SetFallBool());
	}

	IEnumerator SetFallBool()
	{
		yield return new WaitForSeconds(3);
		isFall = true;
	}

	void Fall()
	{
		transform.Translate(0, -0.9f * Time.deltaTime, 0);
		destroyDistance += 0.8f * Time.deltaTime;

		if (destroyDistance > 2) Destroy(gameObject);
	}
}
