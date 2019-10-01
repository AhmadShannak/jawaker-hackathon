using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Spine;
using Spine.Unity;
public class Player : MonoBehaviour {
  [SerializeField]
  Rigidbody2D playerRigidbody;

  public Rigidbody2D rb {
    get { return playerRigidbody; }
  }

  // Start is called before the first frame update
  void Start() {
    playerRigidbody = this.GetComponent<Rigidbody2D>();
    playerRigidbody.velocity = new Vector2(4, -5);
    this.transform.position = Camera.main.ViewportToWorldPoint(new Vector3(0,1.2f,10));
  }

  public void SwitchAnimation(string name) {
    this.transform.GetChild(0).GetComponent<SkeletonAnimation>().AnimationName = name;
  }

  // Update is called once per frame
  void Update() {

  }
}
