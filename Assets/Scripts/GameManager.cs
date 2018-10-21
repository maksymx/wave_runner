using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManager:MonoBehaviour {

	public GameObject GameOverPanel;
	public TextMeshProUGUI currentScoreText;

	int currentScore;

	// Use this for initialization
	void Start () {
		currentScore = 0;
		SetScore();
	}

	// Update is called once per frame
	void Update () {

	}

	public void CallGameOver() {
		Debug.Log("Game Over");
		StartCoroutine(GameOver());
	}

	IEnumerator GameOver() {
		yield return new WaitForSeconds(0.5f);
		GameOverPanel.SetActive(true);
		yield break;
	}

	public void Restart() {
		SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
	}

	public void AddScore() {
		currentScore++;
		SetScore();
	}

	void SetScore() {
		currentScoreText.text = currentScore.ToString();
	}

}
