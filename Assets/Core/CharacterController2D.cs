using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class CharacterController2D : MonoBehaviour
{
    private bool isGrounded;

    private Rigidbody2D rb2d;
    [SerializeField] private float moveSpeed;
    [SerializeField] private float jumpForce;

    private float inputHorizontal;

    private void Awake() => rb2d = GetComponent<Rigidbody2D>();

    private void Update() => Move();

    public void Move()
    {
        inputHorizontal = SimpleInput.GetAxis("Horizontal");
        transform.position += new Vector3(inputHorizontal, 0, 0) * Time.deltaTime * moveSpeed;
    }

    public void Jump()
    {
        if(rb2d.velocity.y == 0)
            rb2d.AddForce(new Vector2(0, jumpForce));
    }
}
