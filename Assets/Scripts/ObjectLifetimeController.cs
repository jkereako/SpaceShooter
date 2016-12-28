using UnityEngine;

public class ObjectLifetimeController : MonoBehaviour {
  public float lifetime;

  void Start() {
    Destroy(gameObject, lifetime);
  }
}
