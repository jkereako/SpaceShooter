using UnityEngine;

public class AsteroidController: MonoBehaviour {
  public float tumbleValue;
  public GameObject asteroidExplosion;
  public GameObject playerExplosion;

  GameController gameController;

  void Start() {
    GameObject gameControllerObject = GameObject.FindWithTag("GameController");

    if (gameControllerObject != null) {
      gameController = gameControllerObject.GetComponent<GameController>();
    }

    // Set a random value to the asteroid
    GetComponent<Rigidbody>().angularVelocity = Random.insideUnitSphere * tumbleValue;
  }

  void OnTriggerEnter(Collider other) {
    if (other.CompareTag("Boundary")) {
      return;
    }
    else if (other.CompareTag("Player")) {
      gameController.EndGame();
      Instantiate(playerExplosion, transform.position, transform.rotation);
    }

    Instantiate(asteroidExplosion, transform.position, transform.rotation);
    Destroy(other.gameObject);
    Destroy(gameObject);
    gameController.AddToScore(1);
  }
}
