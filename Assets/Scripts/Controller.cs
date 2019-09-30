using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
public class Controller : MonoBehaviour {
  [SerializeField]
  Player player;
  Vector2 lastVelocity;
  Transform camera;
  void Start() {
    this.transform.localScale = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width * 1.5f, Screen.height * 1.5f,Camera.main.nearClipPlane));
    camera = this.transform.parent;
  }
  void Update() {
    
    if (player.transform.position.x >= this.transform.position.x) {
      camera.transform.position = new Vector3(player.transform.position.x, camera.transform.position.y, camera.transform.position.z);
    }
  }
  public void OnMouseDown() {
    Jumpy.Time.timeScale = 0.15f;
    lastVelocity = player.rb.velocity;
    Jumpy.Time.SlowTime();
    // player.rb.velocity = new Vector2;
    // player.rb.gravityScale = 0;
  }
  public void OnMouseUp() {
   Jumpy.Time.timeScale = 1;
   Jumpy.Time.ReseTime();
  //  player.rb.velocity = lastVelocity;
  //  player.rb.gravityScale = 1;
  }
}
