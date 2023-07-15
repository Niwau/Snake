using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Food : MonoBehaviour
{

  public BoxCollider2D foodSpawnArea;

  void Start() {
    ChangePosition();
  }

  void OnTriggerEnter2D(Collider2D collision) {
    if (collision.tag == "Player") {
      ChangePosition();
    }
  }

  void ChangePosition() {
    Bounds bounds = foodSpawnArea.bounds;
    Vector2 newPosition = new Vector2(
      Mathf.Round(Random.Range(bounds.min.x, bounds.max.x)),
      Mathf.Round(Random.Range(bounds.min.y, bounds.max.y))
    );
    transform.position = newPosition;
  }
}
