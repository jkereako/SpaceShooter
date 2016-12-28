using UnityEngine;

public class BoundaryController : MonoBehaviour {
  void OnTriggerExit(Collider other) {
    Destroy(other.gameObject);
  }
}
