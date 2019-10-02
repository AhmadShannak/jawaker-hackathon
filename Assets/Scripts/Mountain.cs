using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mountain : MonoBehaviour {
  public static Vector3 outPos;

  void OnTriggerExit2D(Collider2D other) {
    if (other.CompareTag("Left")) {
      outPos = this.transform.parent.GetChild(2).localPosition;
      outPos.x +=  38.3098f;
      this.transform.localPosition = outPos;
      this.transform.SetAsLastSibling();
    }
  }
}
