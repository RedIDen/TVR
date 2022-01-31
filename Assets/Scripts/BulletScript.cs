using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{
    public float speed = 10f;
    public float lifeTime = 2;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.right * this.speed * Time.deltaTime);
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
            Destroy(gameObject);
            return;
        }

        EnemyScript enemy = collision.GetComponent<EnemyScript>();
        if (enemy != null)
        {
            enemy.Die(transform.eulerAngles.y);
            Destroy(gameObject);
            return;
        }

        if (collision.gameObject.CompareTag("ground"))
        {
            Destroy(gameObject);
            return;
        }
    }
}
