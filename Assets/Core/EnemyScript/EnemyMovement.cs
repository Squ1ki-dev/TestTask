using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public EnemyManager enemyManager;

    [SerializeField] private Transform moveSpot;

    private float waitTime;
    [SerializeField] private float startWaitTime;
    [SerializeField] private float minXDir, maxXDir;
    public bool isMove;

    private void Start()
    {
        isMove = false;
        waitTime = startWaitTime;
        moveSpot.position = new Vector2(Random.Range(minXDir, maxXDir), 0);
    }

    private void Update() => EnemyMove();

    public void EnemyMove()
    {
        isMove = true;
        transform.position = Vector2.MoveTowards(transform.position, moveSpot.position,  enemyManager.walkSpeed * Time.deltaTime);

        if(Vector2.Distance(transform.position, moveSpot.position) < 0.2f)
        {
            if(waitTime <= 0)
            {
                moveSpot.position = new Vector2(Random.Range(minXDir, maxXDir), 0);
                waitTime = startWaitTime;
            }
            else
                waitTime -= startWaitTime;
        }
    }

    private void OnTriggerEnter2D(Collider2D other) 
    {
        if(other.gameObject.CompareTag("Player Bullet"))
            Destroy(gameObject);
    }
}