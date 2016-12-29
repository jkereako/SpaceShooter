using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameController: MonoBehaviour {
  public GameObject hazard;
  public int hazardCount;
  public float startWaitValue;
  public float waveWaitValue;
  public float spawnWaitValue;
  public Vector3 spawnValue;
  public Text scoreText;
  public Text restartText;
  public Text gameOverText;

  bool isGameOver;
  int score;

  void Start() {
    score = 0;
    isGameOver = false;
    restartText.enabled = isGameOver;
    gameOverText.enabled = isGameOver;
    UpdateScoreText();
    StartCoroutine(SpawnWaves());
  }

  void Update() {
    if (isGameOver && Input.GetKeyDown(KeyCode.R)) {
      isGameOver = false;
      restartText.enabled = isGameOver;
      SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
  }

  public void AddToScore(int aScore) {
    score += aScore;
    UpdateScoreText();
  }

  public void EndGame() {
    isGameOver = true;
    gameOverText.enabled = isGameOver;
  }

  IEnumerator SpawnWaves() {
    yield return new WaitForSeconds(startWaitValue);

    while (!isGameOver) {
      for (int i = 0; i < hazardCount; i++) {
        Vector3 position = new Vector3(
                             Random.Range(-spawnValue.x, spawnValue.x), spawnValue.y, spawnValue.z
                           );
        Quaternion rotation = Quaternion.identity;
        Instantiate(hazard, position, rotation);
        yield return new WaitForSeconds(spawnWaitValue);
      }
      yield return new WaitForSeconds(waveWaitValue);
    }

    restartText.enabled = isGameOver;
  }

  void UpdateScoreText() {
    scoreText.text = "SCORE: " + score;
  }
}
