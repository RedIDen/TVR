using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotGunScript : MonoBehaviour
{
    public Transform shootPoint;
    public GameObject bullet;
    public Transform effectPoint;
    public GameObject effect;

    public float timeBetweenShots = 0.0f;
    private float timeAfterShot = 0.0f;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (timeAfterShot > 0)
        {
            this.timeAfterShot -= Time.deltaTime;
        }
    }

    public bool Shoot()
    {
        if (this.timeAfterShot <= 0)
        {
            if (transform.parent.localScale.x > 0)
            {
                SpawnBullet(0);
            }
            else
            {
                SpawnBullet(180);
            }

            this.timeAfterShot = this.timeBetweenShots;
            return true;
        }

        return false;
    }

    void SpawnBullet(float angle)
    {
        Instantiate(effect, effectPoint.position, Quaternion.Euler(0, 90 + angle, 0));
        Instantiate(bullet, shootPoint.position, Quaternion.Euler(0, angle, -3));
        Instantiate(bullet, shootPoint.position, Quaternion.Euler(0, angle, 0));
        Instantiate(bullet, shootPoint.position, Quaternion.Euler(0, angle, 3));
    }
}
