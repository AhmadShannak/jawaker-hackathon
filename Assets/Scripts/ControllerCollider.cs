using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ControllerCollider : MonoBehaviour {
    [SerializeField]
  Player player;
    [SerializeField]
  Slider slider;
    float pauseFuel = 15;
  bool outOfFuel = false;
  bool useFuel = false;
  float maxFuel = 15;
  // Start is called before the first frame update
  void Start() {

  }

  // Update is called once per frame
  void Update() {
    if (player != null) {
      Fuel();
    }
  }
  private void OnMouseDown() {
    if (outOfFuel)
    return;
    useFuel = true;
  }
  private void OnMouseUp() {
    useFuel = false;
  }
    void Fuel() {
    if (useFuel) {
      if (pauseFuel > 0.2f) {
        slider.value = pauseFuel;
        pauseFuel -= Time.unscaledDeltaTime;
        Jumpy.Time.SlowTime();
      } else {
        useFuel = false;
      }
    } else {
      if (pauseFuel < maxFuel) {
        slider.value = pauseFuel;
        pauseFuel += Time.unscaledDeltaTime / 3;
        Jumpy.Time.ReseTime();
      }
    }
  }
    public void ActivateAddTime() {
    slider.value = pauseFuel;
    pauseFuel = pauseFuel + 2 > maxFuel ? maxFuel : pauseFuel + 2;
  }
}
