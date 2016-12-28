﻿using UnityEngine;

public class AsteroidController: MonoBehaviour {
  public float tumbleValue;
  public GameObject asteroidExplosion;
  public GameObject playerExplosion;

  void Start() {
    // Set a random value to the asteroid
    GetComponent<Rigidbody>().angularVelocity = Random.insideUnitSphere * tumbleValue;
  }

  void OnTriggerEnter(Collider other) {
    if (other.CompareTag("Boundary")) {
      return;
    }
    else if (other.CompareTag("Player")) {
      Instantiate(playerExplosion, transform.position, transform.rotation);
    }

    Instantiate(asteroidExplosion, transform.position, transform.rotation);
    Destroy(other.gameObject);
    Destroy(gameObject);
  }
}
