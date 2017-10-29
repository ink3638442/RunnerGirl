using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloorGenerator : MonoBehaviour
{
	[SerializeField]
	GameObject floorPrefab;

    // Use this for initialization
    void Start()
    {	
		for (int i = 0; i < 500; i++)
		{
			GameObject go = Instantiate(floorPrefab);
			go.transform.position = new Vector3(i, 0, 0);


		}
    }

    // Update is called once per frame
    void Update()
    {

    }
}
