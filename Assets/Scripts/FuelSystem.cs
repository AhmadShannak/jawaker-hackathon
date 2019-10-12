using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FuelSystem : MonoBehaviour {
  [SerializeField]
  Player player;
  [SerializeField]
  Slider slider;
  [SerializeField]
  float maxFuel = 15, fuelPerSecond = 3;
  
  float pauseFuel = 15;
  bool useFuel = false;


  // Update is called once per frame
  void Update() {
    if (player != null) {
      Fuel();
    }
  }

  void OnMouseDown() {
    useFuel = true;
  }

  void OnMouseUp() {
    useFuel = false;
  }

  void Fuel() {
    if (useFuel) {
      if (pauseFuel > 0.1f) {
        slider.value = pauseFuel;
        pauseFuel -= Time.unscaledDeltaTime;
        Jumpy.Time.SlowTime();
      } else {
        useFuel = false;
      }
    } else {
      ReChargeFuel();
    }
  }

  void ReChargeFuel() {
    if (pauseFuel < maxFuel) {
      slider.value = pauseFuel;
      pauseFuel += Time.unscaledDeltaTime / fuelPerSecond;
      Jumpy.Time.ReseTime();
    }
  }

  public void ActivateAddTime() {
    slider.value = pauseFuel;
    pauseFuel = pauseFuel + 2 > maxFuel ? maxFuel : pauseFuel + 2;
  }
}
