using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mountain : MonoBehaviour {
  public static Vector3 outPos;

  void OnTriggerExit2D(Collider2D other) {
    if (other.CompareTag("Left")) {
      outPos = this.transform.parent.GetChild(2).position;
      outPos.x += + 39.89f;
      this.transform.position = outPos;
      this.transform.SetAsLastSibling();
    }
  }
}
