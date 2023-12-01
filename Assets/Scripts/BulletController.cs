using Collectables;
using Player;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    public GameObject bulletPrefab;
    public PlayerController player;
    public float spawnInterval = 1f;
    public float bulletLifetime = 5f;
    public float bulletSpeed = 5f; // Bullet h�z�

    private float spawnTimer = 0f;
    private float spawnOffset = 1f; // Player'dan ba�lama mesafesi
    private TextMeshProUGUI textMeshPro;
    private float bulletSpawnDelay = 0.1f;
    private float currentBulletDelay = 0f;
    int bulletCon = 1;

    void Update()
    {
        // Belirli aral�klarla bullet �retme
        spawnTimer += Time.deltaTime;
        if (spawnTimer >= spawnInterval)
        {
            StartCoroutine(SpawnBulletsWithDelay(bulletCon, bulletSpawnDelay));
            spawnTimer = 0f;
        }

        if (player.rangeChangeSit)
        {
            bulletLifetime += (float)(0.1) * (player.rangeChange);
            player.rangeChangeSit = false;
        }

        if (player.bulletCountChangeSit)
        {

            bulletCon+=player.bulletCountChange;
            player.bulletCountChangeSit = false;
        }
    }

    IEnumerator SpawnBulletsWithDelay(int numBullets, float delay)
    {
        for (int i = 0; i < numBullets; i++)
        {
            SpawnBullet();
            yield return new WaitForSeconds(delay);
        }
    }

    void SpawnBullet()
    {
        // Player'�n mevcut pozisyonunu al
        Vector3 playerPosition = transform.position;

        // Player'dan belirli bir mesafe geride ba�latma
        playerPosition.z += spawnOffset;

        // Bullet instantiate etme ve spawn noktas�n� kullanma
        GameObject bullet = Instantiate(bulletPrefab, playerPosition, Quaternion.identity);

        // Bullet'�n ileri hareket etmesi i�in Rigidbody bile�enini kullanma
        Rigidbody bulletRb = bullet.GetComponent<Rigidbody>();
        if (bulletRb != null)
        {
            // velocity kullanarak ileri hareket etme
            bulletRb.velocity = Vector3.forward * bulletSpeed;
        }

        // Belirli bir s�re sonra bullet'� yok etme
        Destroy(bullet, bulletLifetime);
    }
}