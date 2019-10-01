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
  Vector3 oldPosition;
  bool landing = false;
  // Start is called before the first frame update
  void Start() {
    playerRigidbody = this.GetComponent<Rigidbody2D>();
    playerRigidbody.velocity = new Vector2(4, -5);
    this.transform.position = Camera.main.ViewportToWorldPoint(new Vector3(0,1.2f,10));
    oldPosition = this.transform.position;
  }

  public void SwitchAnimation(string name) {
    if (name == "Landing")
      landing = true;
    else if (name == "Flying")
      landing = false;
    this.transform.GetChild(0).GetComponent<SkeletonAnimation>().AnimationName = name;
  }

  // Update is called once per frame
  void Update() {
    Debug.Log("wow"+ oldPosition.y +"   " +this.transform.position.y);
    if (oldPosition.y > this.transform.position.y && !landing) {
      SwitchAnimation("Falling");
    }
    oldPosition = this.transform.position;
  }
}
