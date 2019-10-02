using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ground : MonoBehaviour {
  [SerializeField]
  Vector2 velocity;
  [SerializeField]
  Player player;
  [SerializeField]
  Transform inScreen, outScreen;

  public bool ignorePlayer = false;
  // Start is called before the first frame update
  void Start() {

  }

  void Update() {
    this.transform.Translate(new Vector3( -0.1f, 0, 0) * Jumpy.Time.timeScale);
  }

  void OnCollisionEnter2D(Collision2D other) {
    if (other.transform.CompareTag("Player") && !ignorePlayer) {
      Rigidbody2D rb = other.gameObject.GetComponent<Rigidbody2D>();
      other.transform.localEulerAngles = Vector3.zero;
      rb.velocity = Vector2.zero;
      rb.velocity = velocity;
      player.SwitchAnimation("Jumping");
    }
  }

  void OnTriggerEnter2D(Collider2D other) {
    if (other.CompareTag("Right") && this.transform.CompareTag("Child0")) {

        this.transform.parent.parent = inScreen;
      }
   
  }
  void OnTriggerExit2D(Collider2D other) {
    if (other.CompareTag("Left") && this.transform.CompareTag("Child2")) {
      LevelGenerator.Generate(this.transform.parent.gameObject, outScreen.transform.GetChild(outScreen.transform.childCount - 1).localPosition);
      Debug.Log(outScreen.transform.GetChild(outScreen.transform.childCount - 1).localPosition);
      this.transform.parent.parent = outScreen;
    }
  }

  void OnCollisionExit2D(Collision2D other) {
    if (other.transform.CompareTag("Player") && !ignorePlayer) {
      other.transform.localEulerAngles = Vector3.zero;
    }
  }
}
