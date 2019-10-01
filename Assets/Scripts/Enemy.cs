using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {
  public static float speed = 1;

  private void OnCollisionEnter2D(Collision2D other) {
    if (other.transform.CompareTag("Player")) {
      // TODO :: PLAY DEAT ANIMATION
      Debug.Log("DEAD!");
    }
  }
}
