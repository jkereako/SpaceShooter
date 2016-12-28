using UnityEngine;

public class BoltController: MonoBehaviour {
  public float speed;

  void Start() {
    GetComponent<Rigidbody>().velocity = transform.forward * speed;
  }
}
