using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTahker : MonoBehaviour {
  [SerializeField]
  Player player;

  void Awake() {
    this.transform.position = Camera.main.ViewportToWorldPoint(new Vector3(0.5f, 0.15f, 10));
  }

  private void OnTriggerEnter2D(Collider2D other) {
    if (other.CompareTag("Player")) {
      player.SwitchAnimation("Landing");
    }
  }
  private void OnTriggerExit2D(Collider2D other) {
    if (other.CompareTag("Player")) {
      player.SwitchAnimation("Flying");
    }
  }
}
