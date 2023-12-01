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
    public float bulletSpeed = 5f; // Bullet hýzý

    private float spawnTimer = 0f;
    private float spawnOffset = 1f; // Player'dan baþlama mesafesi
    private TextMeshProUGUI textMeshPro;
    private float bulletSpawnDelay = 0.1f;
    private float currentBulletDelay = 0f;
    int bulletCon = 1;

    void Update()
    {
        // Belirli aralýklarla bullet üretme
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
        // Player'ýn mevcut pozisyonunu al
        Vector3 playerPosition = transform.position;

        // Player'dan belirli bir mesafe geride baþlatma
        playerPosition.z += spawnOffset;

        // Bullet instantiate etme ve spawn noktasýný kullanma
        GameObject bullet = Instantiate(bulletPrefab, playerPosition, Quaternion.identity);

        // Bullet'ýn ileri hareket etmesi için Rigidbody bileþenini kullanma
        Rigidbody bulletRb = bullet.GetComponent<Rigidbody>();
        if (bulletRb != null)
        {
            // velocity kullanarak ileri hareket etme
            bulletRb.velocity = Vector3.forward * bulletSpeed;
        }

        // Belirli bir süre sonra bullet'ý yok etme
        Destroy(bullet, bulletLifetime);
    }
}