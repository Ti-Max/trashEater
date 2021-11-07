using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipMovement : MonoBehaviour
{
    public Rigidbody2D rigidbody;
    public float speed = 1;
    public float rotationSpeed = 1;
    private void FixedUpdate()
    {
        Vector2 input = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        rigidbody.MoveRotation(-input.x * rotationSpeed + rigidbody.rotation);
        rigidbody.MovePosition(rigidbody.transform.position + rigidbody.transform.TransformDirection(new Vector2(0, speed * input.y)));
/*        transform.Rotate(new Vector3(0, 0, 1), -input.x * rotationSpeed);
        transform.Translate(new Vector3(0, speed * input.y, 0), Space.Self);*/
    }
}
