using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class GameController: MonoBehaviour {
  public GameObject hazard;
  public int hazardCount;
  public float startWaitValue;
  public float waveWaitValue;
  public float spawnWaitValue;
  public Vector3 spawnValue;
  public Text scoreText;

  int score;

  void Start() {
    score = 0;
    UpdateScoreText();
    StartCoroutine(SpawnWaves());
  }

  public void AddToScore(int aScore) {
    score += aScore;
    UpdateScoreText();
  }

  IEnumerator SpawnWaves() {
    yield return new WaitForSeconds(startWaitValue);

    while (true) {
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
  }

  void UpdateScoreText() {
    scoreText.text = "Score: " + score;
  }
}
