using UnityEngine;
using System.Collections.Generic;

public class Weapon : MonoBehaviour
{
    [Header("Weapon Stats")]
    [SerializeField] private float shootIntervalInSeconds = 3f; 

    [Header("Bullets")]
    public Bullet bulletPrefab; 
    [SerializeField] private Transform bulletSpawnPoint; 

    [Header("Bullet Pool")]
    private Queue<Bullet> objectPool = new Queue<Bullet>(); 
    private float timer = 0f; 

    void Update()
    {
        timer += Time.deltaTime;

        if (timer >= shootIntervalInSeconds)
        {
            Shoot(); 
            timer = 0f; 
        }
    }

    void Shoot()
    {
        Bullet b = GetBulletFromPool(); 
        if (b != null)
        {
            b.transform.position = bulletSpawnPoint.position; 
            b.gameObject.SetActive(true);  
        }
    }

    Bullet GetBulletFromPool()
    {
        if (objectPool.Count > 0)
        {
            return objectPool.Dequeue(); 
        }
        else
        {
            Bullet newBullet = Instantiate(bulletPrefab);
            return newBullet;
        }
    }

    public void ReturnBulletToPool(Bullet bullet)
    {
        objectPool.Enqueue(bullet); 
    }
}
