using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrashMovement : MonoBehaviour
{
    public new Rigidbody2D rigidbody;
    public float speed = 1;
    // Update is called once per frame
    void FixedUpdate()
    {
        rigidbody.velocity = new Vector2(0, -speed);
        if (transform.position.y < -12f)
        {
            Destroy(gameObject);
        }
    }

}
