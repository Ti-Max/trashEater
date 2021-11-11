using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipMovement : MonoBehaviour
{
    public new Rigidbody2D rigidbody;
    public float speed = 1;
    public float backwardsSpeed = 0.5f;
    public float rotationSpeed = 1;
    private void FixedUpdate()
    {
        Vector2 input = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        rigidbody.MoveRotation(-input.x * rotationSpeed + rigidbody.rotation);
        if (input.y < 0)
        {
            rigidbody.MovePosition(rigidbody.transform.position + rigidbody.transform.TransformDirection(new Vector2(0, backwardsSpeed * input.y)));
        }
        else
        {
            rigidbody.MovePosition(rigidbody.transform.position + rigidbody.transform.TransformDirection(new Vector2(0, speed * input.y)));
        }
    }
}
