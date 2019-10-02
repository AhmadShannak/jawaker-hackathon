using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StorageHelper : MonoBehaviour {
  public static string HIGH_SCORE_KEY = "high_score";

  public static void WriteStorage(string key, string value) {
    PlayerPrefs.SetString(HIGH_SCORE_KEY, value);
  }

  public static string ReadStorage(string key) {
    string value = PlayerPrefs.GetString(key);
    if (!string.IsNullOrEmpty(value)) {
      return value;
    }
    return null;
  }
}
