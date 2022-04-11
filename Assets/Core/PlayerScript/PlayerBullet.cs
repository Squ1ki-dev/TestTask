using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBullet : MonoBehaviour
{
    [SerializeField] private float snowballSpeed = 12f;
    Rigidbody2D rd2d;

    private void Awake() => rd2d = GetComponent<Rigidbody2D>();
    void Update() => Shoot();

    private void Shoot() => rd2d.velocity = transform.up * snowballSpeed;

    private void OnTriggerEnter2D(Collider2D other) 
    {
        if(other.gameObject.CompareTag("Enemy"))
        {
            UIManager.instance.AddPoint();
            gameObject.SetActive(false);
        }
    }
}