using UnityEngine;

public class AsteroidController: MonoBehaviour {
  public float tumbleValue;

  void Start() {
    // Set a random value to the asteroid
    GetComponent<Rigidbody>().angularVelocity = Random.insideUnitSphere * tumbleValue;
  }

  void OnTriggerEnter(Collider other) {
    if (other.CompareTag("Boundary")) {
      return;
    }

    // Destroy the laser shot
    Destroy(other.gameObject);

    // Destroy the asteroid
    Destroy(gameObject);
  }
}
