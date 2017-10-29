using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloorGenerator : MonoBehaviour
{
	[SerializeField]
	GameObject floorPrefab;

	float offsetFloor = 0;

    // Use this for initialization
    void Start()
    {	
		for (int i = 0; i < 500; i++)
		{
			GameObject go = Instantiate(floorPrefab);
			go.transform.position = new Vector3(0, offsetFloor, i);

			if (RandomBool()) offsetFloor -= 0.2f;
		}
    }

    // Update is called once per frame
    void Update()
    {

    }

	/// <summary>
	/// bool型の乱数を取得する
	/// </summary>
	/// <returns>bool型の乱数</returns>
	public static bool RandomBool()
	{
		return Random.Range(0, 2) == 0;
	}
}
