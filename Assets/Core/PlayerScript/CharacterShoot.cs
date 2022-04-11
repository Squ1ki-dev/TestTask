using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterShoot : MonoBehaviour
{
    private ObjectPool bulletPool;
    [SerializeField] private int bulletPoolCount = 3;

    [SerializeField] private Transform shootingPont;
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private float reloadDelay = 2f;

    private bool canShoot = true;
    private float currentDelay = 0;

    private void Awake() => bulletPool = GetComponent<ObjectPool>();

    private void Start() => bulletPool.Initialize(bulletPrefab, bulletPoolCount);

    
    private void Update()
    {
        if (canShoot == false)
        {
            currentDelay -= Time.deltaTime;
            if (currentDelay <= 0)
                canShoot = true;
        }
    }

    public void Shoot()
    {
        if(canShoot)
        {
            canShoot = false;
            currentDelay = reloadDelay;

            GameObject bullet = bulletPool.CreateObject();
            bullet.transform.position = shootingPont.position;
            bullet.transform.rotation = Quaternion.identity;
        }
    }
}
