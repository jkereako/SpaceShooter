using UnityEngine;

public class PlayerController: MonoBehaviour {
  public float speed;
  public float tilt;
  public Boundry boundry;

  void FixedUpdate() {
    float horizontalMovement = Input.GetAxis("Horizontal");
    float verticalMovement = Input.GetAxis("Vertical");
    Rigidbody aRigidBody = GetComponent<Rigidbody>();
    Vector3 movement = new Vector3(horizontalMovement, 0.0f, verticalMovement);
    Vector3 position = new Vector3(
                         Mathf.Clamp(aRigidBody.position.x, boundry.xMin, boundry.xMax), 
                         0.0f, 
                         Mathf.Clamp(aRigidBody.position.z, boundry.zMin, boundry.zMax)
                       );

    aRigidBody.velocity = movement * speed;
    aRigidBody.position = position;
    aRigidBody.rotation = Quaternion.Euler(0.0f, 0.0f, aRigidBody.velocity.x * -tilt);
  }
}

[System.Serializable]
public class Boundry {
  public float xMin, xMax, zMin, zMax;
}