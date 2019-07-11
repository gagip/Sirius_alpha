using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JBControl : MonoBehaviour
{
    Rigidbody2D rigidbody2d;

    // Start is called before the first frame update
    void Start()
    {
        rigidbody2d = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        Vector2 position = rigidbody2d.position;
        position.x = position.x + 1.0f * horizontal;
        position.y = position.y + 1.0f * vertical;

        rigidbody2d.MovePosition(position);
    }
}
