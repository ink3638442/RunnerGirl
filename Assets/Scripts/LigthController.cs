using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LigthController : MonoBehaviour
{
	[SerializeField]
	GameObject player;

	Vector3 lightDistance;

    // Use this for initialization
    void Start()
    {
		// 開始時のライトとプレイヤーの位置の差を取得
		lightDistance = transform.position - player.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
		// プレイヤーに常に初期のライトとの差を加える
		transform.position = player.transform.position + lightDistance;
    }
}
