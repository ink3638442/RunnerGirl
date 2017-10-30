using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloorGenerator : MonoBehaviour
{
	[SerializeField]
	GameObject[] floorPrefab;

	[SerializeField]
	GameObject[] wallPrefab;

	int toralFloorNum = 300; // トータル作成数

	float nextFloorX = 0; // 次の床のX生成位置
	float nextFloorY = 0; // 次の床のY生成位置
	float nextFloorZ = 0; // 次の床のZ生成位置

	enum Direction {South, North, West, East}; // 方向用変数
	Direction direction = Direction.South;

    // Use this for initialization
    void Start()
    {	
		for (int num = 0; num < toralFloorNum;) // numの更新は下記に
		{
			DirectionChanger(); // 作成方向の決定

			int createFloors = Random.Range(10, 15); // 一方向の作成数
			for (int floor = 0; floor <= createFloors; floor++)
			{
				if (floor == createFloors / 2) CreateWall(); // 通路真ん中あたりで壁作成

				CreateFloor();
			}

			num += createFloors; // 現在までの全体作成数を更新
		}
    }


	/// <summary>
	/// 最新の位置で床を作成する
	/// </summary>
	void CreateFloor()
	{
		int index = Random.Range(0, 3);
		GameObject go = Instantiate(floorPrefab[index]);

		switch(direction)
		{
			case Direction.South:
				go.transform.position = new Vector3(nextFloorX, nextFloorY, nextFloorZ);
				UpdateFloorZ();

				break;
			case Direction.North:
				go.transform.position = new Vector3(nextFloorX, nextFloorY, nextFloorZ);
				UpdateFloorZ();

				break;
			case Direction.West:
				go.transform.position = new Vector3(nextFloorX, nextFloorY, nextFloorZ);
				UpdateFloorX();

				break;
			case Direction.East:
				go.transform.position = new Vector3(nextFloorX, nextFloorY, nextFloorZ);
				UpdateFloorX();
				
				break;
		}

		UpdateFloorY();
	}

	/// <summary>
	/// 最新の位置で壁を作成する
	/// </summary>
	void CreateWall()
	{
		int index = Random.Range(0, 3);
		GameObject go = Instantiate(wallPrefab[index]);

		switch(direction)
		{
			case Direction.South:
				go.transform.position = new Vector3(nextFloorX - 1, nextFloorY + 1, nextFloorZ);
				go.transform.rotation = Quaternion.Euler(0, 90, 0);

				break;
			case Direction.North:
				go.transform.position = new Vector3(nextFloorX - 1, nextFloorY + 1, nextFloorZ);
				go.transform.rotation = Quaternion.Euler(0, 90, 0);

				break;
			case Direction.West:
				go.transform.position = new Vector3(nextFloorX, nextFloorY + 1, nextFloorZ - 1);
				go.transform.rotation = Quaternion.Euler(0, 0, 0);

				break;
			case Direction.East:
				go.transform.position = new Vector3(nextFloorX, nextFloorY + 1, nextFloorZ - 1);
				go.transform.rotation = Quaternion.Euler(0, 0, 0);

				break;
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
	/// 次回のX位置をセット
	/// </summary>
	void UpdateFloorX()
	{
		if (direction == Direction.West) nextFloorX++;
		else                             nextFloorX--;
	}

	/// <summary>
	/// 次回のY位置をセット（ランダムでオフセット実行）
	/// </summary>
	void UpdateFloorY()
	{
		if (RandomBool()) nextFloorY -= 0.2f;
	}

	/// <summary>
	/// 次回のZ位置をセット
	/// </summary>
	void UpdateFloorZ()
	{
		if (direction == Direction.South) nextFloorZ++;
		else                              nextFloorZ--;
	}


	/// <summary>
	/// <param>方向を変える 南,北 -> 西または東</param>
	/// <param>方向を変える 西,東 -> 南または北</param>
	/// </summary>
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
