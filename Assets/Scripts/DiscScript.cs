using UnityEngine;

public class DiscScript : MonoBehaviour
{
    public bool turnedOn;
    public float time = 0;
    private int angle;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        this.angle -= 20;
        this.angle %= 90;
        if (this.turnedOn)
        {
            this.time -= Time.deltaTime;
            transform.rotation = Quaternion.Euler(transform.parent.localScale.x > 0 ? 0 : 180, 0, this.angle);
            this.turnedOn = this.time > 0;
        }
    }
    
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (this.turnedOn)
        {
            int dirAngle = transform.parent.parent.localScale.x > 0 ? 0 : 180;
            PlayerScript player = collision.GetComponent<PlayerScript>();
            if (player != null)
            {
                player.Die(dirAngle);
                return;
            }

            EnemyScript enemy = collision.GetComponent<EnemyScript>();
            if (enemy != null)
            {
                enemy.Die(dirAngle);
            }
        }
    }
}
