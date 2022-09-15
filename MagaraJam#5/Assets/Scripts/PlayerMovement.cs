using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
  public float speed;

  Rigidbody rb;
  Vector3 dir;

  void Start()
  {
    rb = this.gameObject.GetComponent<Rigidbody>();
  }

  void Update()
  {
    dir = new Vector3(0,0,0);

    if(Input.GetKey(KeyCode.RightArrow))
      dir.x += 1;
    if(Input.GetKey(KeyCode.LeftArrow))
      dir.x -= 1;
    if(Input.GetKey(KeyCode.UpArrow))
      dir.z += 1;
    if(Input.GetKey(KeyCode.DownArrow))
      dir.z -= 1;

    rb.velocity = dir * speed;

  }
}
