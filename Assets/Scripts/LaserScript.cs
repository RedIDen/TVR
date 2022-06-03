using UnityEngine;

public class LaserScript : WeaponScript
{
    private float timeAfterShot;
    public float loadingTime = 1f;
    private float timeBeforeShot;
    private bool shoot;

    // Start is called before the first frame update
    void Start()
    {
        this.weight = 1.5f;
    }

    // Update is called once per frame
    void Update()
    {
        if (timeAfterShot > 0)
        {
            this.timeAfterShot -= Time.deltaTime;
        }

        if (this.shoot)
        {
            if (this.timeBeforeShot > 0)
            {
                this.timeBeforeShot -= Time.deltaTime;
            }
            else
            {
                SpawnBullet(transform.parent.localScale.x > 0 ? 0 : 180);
                this.shoot = false;
            }
        }
    }

    public override bool Shoot()
    {
        if (this.timeAfterShot <= 0 && !this.shoot)
        {
            this.timeAfterShot = this.timeBetweenShots;
            this.timeBeforeShot = this.loadingTime;
            this.shoot = true;

            return true;
        }

        return false;
    }

    void SpawnBullet(float angle)
    {
        Instantiate(effect, effectPoint.position, Quaternion.Euler(0, 90 + angle, 0));
        Instantiate(bullet,
            new Vector3(
            shootPoint.position.x + (angle == 0 ? 32 : -32),
            shootPoint.position.y,
            shootPoint.position.y),
            Quaternion.Euler(0, angle, 0));
    }
}
