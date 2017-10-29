using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
	[SerializeField]
	GameObject player;

	Vector3 cameraDistance;

    void Start()
    {
		// 開始時のカメラとプレイヤーの位置の差を取得
		cameraDistance = transform.position - player.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
		// プレイヤーに常に初期のカメラとの差を加える
		transform.position = player.transform.position + cameraDistance;
    }
}
