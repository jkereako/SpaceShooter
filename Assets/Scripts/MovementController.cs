using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class MovementController: MonoBehaviour {
  public float speed;

  void Start() {
    GetComponent<Rigidbody>().velocity = transform.forward * speed;
  }
}
