using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
	bool isGameOver  = false; // ゲームオーバー判定
	bool isGameClear = false; // ゲームクリア判定

	GameObject gameOverText;
	GameObject gameClearText;

	void Start()
    {
		gameOverText  = GameObject.Find ("GameOver");
		gameClearText = GameObject.Find ("GameClear");
    }

    // Update is called once per frame
    void Update()
    {
		if (isGameOver)
		{
			GameOver();
		}


		if (isGameClear)
		{
			GameClear();
		}
    }

	/// <summary>
	/// ゲームオーバー処理
	/// </summary>
	void GameOver()
	{
		gameOverText.GetComponent<Text>().text = "GameOver";

		if (Input.GetMouseButtonDown(0)) Restart();
	}

	/// <summary>
	/// ゲームクリア処理
	/// </summary>
	void GameClear()
	{
		gameClearText.GetComponent<Text>().text = "GameClear";

		if (Input.GetMouseButtonDown(0)) Restart();
	}

	/// <summary>
	/// リスタート処理
	/// </summary>
	void Restart()
	{
		SceneManager.LoadScene("MainScene");
	}

	/// <summary>
	/// ゲームオーバースイッチ
	/// </summary>
	public void SetGameOverBool()
	{
		isGameOver = true;
	}

	/// <summary>
	/// ゲームクリアスイッチ
	/// </summary>
	public void SetGameClearBool()
	{
		isGameClear = true;
	}
}
