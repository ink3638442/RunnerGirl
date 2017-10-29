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

	enum Direction {South, North, West, East};
	Direction direction = Direction.South;

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
	/// ランダムで TRUE または FALSE を返す
	/// </summary>
	bool RandomBool()
	{
		int ran = Random.Range(0, 2);
		return Random.Range(0, 2) == 0;
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

	void DirectionChanger()
	{
		switch(direction)
		{
			case Direction.South:
				if (RandomBool()) direction = Direction.West;
				else              direction = Direction.East;
				
				break;
			case Direction.North:
				if (RandomBool()) direction = Direction.West;
				else              direction = Direction.East;

				break;
			case Direction.West:
				if (RandomBool()) direction = Direction.South;
				else              direction = Direction.South;

				break;
			case Direction.East:
				if (RandomBool()) direction = Direction.South;
				else              direction = Direction.North;

				break;
		}
	}
}
