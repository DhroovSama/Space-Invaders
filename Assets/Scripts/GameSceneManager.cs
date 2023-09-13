using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class GameSceneManager : MonoBehaviour
{
	#region Constants
	#endregion Constants

	#region Unity Fields
	public Camera mainCamera;
	public Text scoreText;
	public Text gameOverText;
	public PlayerController player;
	public EnemyGroupController enemyGroup;
	#endregion Unity Fields

	#region Fields
	private int score;
	private int enemyCount;
	private float gameTimer;
	private bool gameOver;
	#endregion Fields

	#region Methods
	public void Start ()
	{
		Time.timeScale = 1;

		player.OnHitEnemy += OnGameOver;
		player.OnKillEnemy += OnKillEnemy;

		enemyCount = enemyGroup.GetComponentsInChildren<EnemyController>().Length;
	}

	public void Update ()
	{
		if (gameOver)
		{
			if (Input.GetKeyDown("r"))
			{
				SceneManager.LoadScene(SceneManager.GetActiveScene().name);
			}

			return;
		}

		scoreText.text = "Score: " + score;
	}

	private void OnKillEnemy ()
	{
		this.score += 100;
		enemyCount--;

		if (enemyCount == 0)
		{
			OnGameOver();
		}
	}

	private void OnGameOver ()
	{
		gameOver = true;

		scoreText.enabled = false;
		gameOverText.enabled = true;

		if (enemyCount != 0)
		{
			gameOverText.text = "Game over!\nScore: " + score + "\nPress R to restart";
		}
		else
		{
			gameOverText.text = "You win!\nScore: " + score + "\nPress R to restart";
		}

		Time.timeScale = 0;
	}

	private void OnGameWin ()
	{
		gameOver = true;

		scoreText.enabled = false;
		gameOverText.enabled = true;

		gameOverText.text = "You win!\nScore: " + score + "\nPress R to restart";

		Time.timeScale = 0;
	}
	#endregion Methods
}