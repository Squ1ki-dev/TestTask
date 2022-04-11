using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 15f;
    private Transform playerPos;
    private Vector2 _target;

    private void Start() 
    {
        playerPos = GameObject.FindGameObjectWithTag("Player").transform;
        _target = new Vector2(playerPos.position.x, playerPos.position.y);
    }

    private void Update() => EnemyShoot();

    private void EnemyShoot()
    {
        transform.position = Vector2.MoveTowards(transform.position, _target, moveSpeed * Time.deltaTime);

        if(transform.position.x == _target.x && transform.position.y == _target.y)
            DisactivateBullets();
    }

    private void DisactivateBullets() => gameObject.SetActive(false);
}