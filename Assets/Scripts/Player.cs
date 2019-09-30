using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {
  [SerializeField]
  Rigidbody2D playerRigidbody;
  public Rigidbody2D rb {
    get{return playerRigidbody;}
  }
  // Start is called before the first frame update
  void Start() {
    playerRigidbody = this.GetComponent<Rigidbody2D>();
    playerRigidbody.velocity = new Vector2(4, -5) ;
  }

  // Update is called once per frame
  void Update() {

  }
}
