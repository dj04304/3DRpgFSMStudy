using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletSpawn : MonoBehaviour
{
    [SerializeField] private float bulletSpeed = 1.5f;
    [SerializeField] private float spawnTime = 2f;
    [SerializeField] private float timer = 0f;

    public GameObject[] bulletSpawned;
    public GameObject playerPosition;
    
    private ObjectPool _objectPool;

    private string _bulletPoolTag = "Bullet"; // юс╫ц

    void Start()
    {
        _objectPool = GetComponent<ObjectPool>();
        SpawnRandomBullet();
    }

    private void Update()
    {
        timer += Time.deltaTime;

        if(timer >= spawnTime) 
        {
            SpawnRandomBullet();
            timer = 0f;
        }

    }

    private void SpawnRandomBullet()
    {
        if (_objectPool != null)
        {
            int randomIndex = Random.Range(0, bulletSpawned.Length);

            GameObject bulletInstance = _objectPool.SpawnFromPool(_bulletPoolTag);

            if (bulletInstance != null)
            {
                bulletInstance.transform.position = bulletSpawned[randomIndex].transform.position;
                bulletInstance.SetActive(true);

                Vector3 direction = DirectionTargetToPlayer(bulletInstance.transform.position);

                BulletForce(bulletInstance, direction);
            }
        }
       
    }

    private Vector3 DirectionTargetToPlayer(Vector3 currentPosition)
    {
        return (playerPosition.transform.position - currentPosition).normalized;
    }

    private void BulletForce(GameObject bullet, Vector3 direction)
    {
        Rigidbody bulletRigidbody = bullet.GetComponent<Rigidbody>();
        if (bulletRigidbody != null)
        {
            bulletRigidbody.velocity = direction * bulletSpeed; 
        }
    }


}
