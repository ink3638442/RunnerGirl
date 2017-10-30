using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallFloorController : MonoBehaviour
{
	bool isFall = false;　      // 落下作動スイッチ
	float destroyDistance = 0;  // 削除判定対象用

    // Update is called once per frame
    void Update()
    {
		if (isFall) Fall();
    }

	void OnCollisionEnter(Collision collision)
    {
		StartCoroutine(SetFallBool());
	}

	/// <summary>
	/// 落下スイッチ切り替え 一定時間後作動
	/// </summary>
	IEnumerator SetFallBool()
	{
		yield return new WaitForSeconds(3);
		isFall = true;
	}

	/// <summary>
	/// 自動床落下 一定ラインでオブジェクトが破棄される
	/// </summary>
	void Fall()
	{
		transform.Translate(0, -0.9f * Time.deltaTime, 0);
		destroyDistance += 0.9f * Time.deltaTime;

		if (destroyDistance > 1.5f) Destroy(gameObject);
	}
}
