using System.Collections;
using UnityEngine;

public class GameController: MonoBehaviour {
  public GameObject hazard;
  public int hazardCount;
  public float startWaitValue;
  public float waveWaitValue;
  public float spawnWaitValue;
  public Vector3 spawnValue;

  void Start() {
    StartCoroutine(SpawnWaves());
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
}
