using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField] private Bullet bulletPrefab; 
    [SerializeField] private Transform bulletSpawnPoint; 
    [SerializeField] private float shootInterval = 0.5f; 

    private float shootTimer = 0f;

    void Update()
    {
        shootTimer += Time.deltaTime;

        if (Input.GetButtonDown("Fire1") && shootTimer >= shootInterval)
        {
            Shoot();
            shootTimer = 0f; 
        }
    }

    private void Shoot()
    {
        if (bulletPrefab == null)
        {
            Debug.LogError("Bullet prefab is not assigned!");
            return;
        }

        Instantiate(bulletPrefab, bulletSpawnPoint.position, bulletSpawnPoint.rotation);
    }
}
