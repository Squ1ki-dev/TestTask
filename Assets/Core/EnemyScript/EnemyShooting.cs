using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShooting : MonoBehaviour
{
    private EnemyManager enemyManager;
    private ObjectPool bulletPool;

    [SerializeField] private int bulletPoolCount = 3;

    [SerializeField] private Transform shootingPont;
    [SerializeField] private GameObject bulletPrefab;

    private float currentDelay = 0;
    [SerializeField] private float reloadDelay = 5f;

    private void Awake() => bulletPool = GetComponent<ObjectPool>();

    private void Start() => bulletPool.Initialize(bulletPrefab, bulletPoolCount);

    private void Update() => TimeToShoot();

    private void TimeToShoot()
    {
        if(currentDelay <= 0)
        {
            currentDelay = reloadDelay;
            GameObject bullet = bulletPool.CreateObject();

            bullet.transform.position = shootingPont.position;
        }
        else
            currentDelay -= Time.deltaTime;
    }
}
