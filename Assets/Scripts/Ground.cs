using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ground : MonoBehaviour {
  [SerializeField]
  Vector2 velocity;
  [SerializeField]
  Player player;

  // Start is called before the first frame update
  void Start() {

  }

  void Update() {
    this.transform.Translate(new Vector3( -0.1f, 0, 0) * Jumpy.Time.timeScale);
  }

  void OnCollisionEnter2D(Collision2D other) {
    if (other.transform.CompareTag("Player")) {
      player.SwitchAnimation("Jump");
      Invoke("Reset",1f);
      Rigidbody2D rb = other.gameObject.GetComponent<Rigidbody2D>();
      other.transform.localEulerAngles = Vector3.zero;
      rb.velocity = Vector2.zero;
      rb.velocity = velocity;
    }
  }

  void OnCollisionExit2D(Collision2D other) {
    if (other.transform.CompareTag("Player"))
      other.transform.localEulerAngles = Vector3.zero;
  }

  void Reset() {
     player.SwitchAnimation("Idle");
  }
}
