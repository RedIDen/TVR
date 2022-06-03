using UnityEngine;

public class LaserShotScropt : MonoBehaviour
{
    public float lifeTime = 0.1f;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        this.lifeTime = this.lifeTime - Time.deltaTime;
        if (this.lifeTime < 0)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        PlayerScript player = collision.GetComponent<PlayerScript>();
        if (player != null)
        {
            player.Die(transform.eulerAngles.y);
            return;
        }

        EnemyScript enemy = collision.GetComponent<EnemyScript>();
        if (enemy != null)
        {
            enemy.Die(transform.eulerAngles.y);
        }
    }
}
