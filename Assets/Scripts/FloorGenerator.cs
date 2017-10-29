using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloorGenerator : MonoBehaviour
{
	[SerializeField]
	GameObject floorPrefab;

	float latestFloorX = 0;
	float latestFloorY = 0;
	float latestFloorZ = 0;

    // Use this for initialization
    void Start()
    {	
		for (int i = 0; i < 500; i++)
		{
			GameObject go = Instantiate(floorPrefab);
			go.transform.position = new Vector3(latestFloorX, latestFloorY, latestFloorZ);
			
			UpdateFloorY();
			UpdateFloorZ();
		}
    }


	/// <summary>
	/// ランダムでオフセット実行、Yの位置をセット
	/// </summary>
	void UpdateFloorY()
	{
		int ran = Random.Range(0, 3);
		if (ran == 0) latestFloorY -= 0.2f;
	}

	/// <summary>
	/// Zの位置をセット
	/// </summary>
	void UpdateFloorZ()
	{
		latestFloorZ++;
	}
}
