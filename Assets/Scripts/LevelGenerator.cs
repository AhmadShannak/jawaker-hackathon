using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class LevelGenerator : MonoBehaviour {
  [SerializeField]
  Transform inScreen, outScreen;
  [SerializeField]
  Transform leftWall, rightWall;
    [SerializeField]
    GameObject[] items;
    [SerializeField]
    GameObject itemSpawner;

    private static float gap;
  private static int grounds = 3;
  static float[] random = new float[4];
  static bool[] sign = { false, false, true, true };
  static float[] weight = new float[4];
  static bool done = false;
  static int counter = 0;
  static LevelGenerator leveler;
   static bool generating = false;
  // Start is called before the first frame update
  void Awake() {
    leveler = this;
    rightWall.position = Camera.main.ViewportToWorldPoint(new Vector3(1, 0.5f, 0));
    leftWall.position = Camera.main.ViewportToWorldPoint(new Vector3(0, 0.5f, 0));
    random = new float[4];
    sign [0] = false;
    sign[1] = false;
    sign[2] = true;
    sign[3] = true;
    done = false;
    weight[0] = 30;
    weight[1] = 45;
    weight[2] = 15;
    weight[3] = 5;
    generating = false;
    counter = 0;
  }

  public static void Generate(GameObject outie, Vector3 newPosition) {
    // TODO :: CHECK LEVEL TO DETERMINE RANDOM VALUES
    newPosition.x += 5.69f;
    outie.transform.localPosition = newPosition;
    foreach (Ground ground in outie.GetComponentsInChildren<Ground>()) {
      ground.GetComponent<SpriteRenderer>().enabled = true;
      ground.ignorePlayer = false;
      ground.GetComponent<BoxCollider2D>().isTrigger = false;
    }
    // grounds = Random.Range(1,3);
    if (weight[3] >= 5) {
      sign[3] = false;
    }
    if (weight[2] >= 30) {
      sign[2] = false;
      sign[1] = true;
      weight[1] = 20;
    }
    if (weight[1] >= 65) {
      sign[1] = false;
      sign[0] = true;
      weight[0] = 10;
    }
    if (weight[0] >= 30) {
      done = true;
      weight[0] = 30;
      weight[1] = 45;
      weight[2] = 15;
      weight[3] = 10;
    }
    for (int i = 0; i < 4; i++)
    {
      if ((!(weight[i] - 0.5f < 1) || !(weight[i] + 0.5f >= 100)) && !done)
        weight[i] += sign[i] ? 0.5f : -0.5f ;
    }
    // gap = Random.Ra
    // newPosition.x += gap;
    for (int i = 0; i < 4; i++) {
      random[i] = UnityEngine.Random.Range(1, 4) * weight[i];
    }
    float maxNumber = Mathf.Max(random);
    int indexOfMax = Array.IndexOf(random, maxNumber);
    Ground[] grounds = outie.GetComponentsInChildren<Ground>();
    if (indexOfMax == 0) {
      counter++;
      if (counter == 3)
        return;
      for (int i = 0; i < 3; i++) {
        grounds[i].GetComponent<SpriteRenderer>().enabled = false;
        grounds[i].ignorePlayer = true;
        grounds[i].GetComponent<BoxCollider2D>().isTrigger = true;
      }
    }
    if (indexOfMax == 1) {
      counter =0;
      for (int i = 0; i < 2; i++) {
        grounds[i].GetComponent<SpriteRenderer>().enabled = false;
        grounds[i].ignorePlayer = true;
        grounds[i].GetComponent<BoxCollider2D>().isTrigger = true;
      }
    }
    if (indexOfMax == 2) {
       counter = 0;
      grounds[0].GetComponent<SpriteRenderer>().enabled = false;
      grounds[0].ignorePlayer = true;
      grounds[0].GetComponent<BoxCollider2D>().isTrigger = true;
    }
        SpawnItem();
  }

    private static void SpawnItem() {
        if (!generating)
        {
            generating = true;
            int createAfter = UnityEngine.Random.Range(3, 15);
            leveler.Invoke("CreateItem", createAfter);
        }

    }

    private void CreateItem(){
        int itemIndex = UnityEngine.Random.Range(1, 3);
        if (Score.avilableItems != 0)
        {
            Score.avilableItems--;
            float randomHeight = UnityEngine.Random.Range(0.3f, 0.7f);
            Vector3 vector = Camera.main.ViewportToWorldPoint(new Vector3(0,randomHeight,10));
            vector.x = outScreen.GetChild(outScreen.childCount - 1).position.x - 15;
            Instantiate(items[2], vector,Quaternion.identity, itemSpawner.transform);
            generating = false;

        }
    }
}
