using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    public GameObject upperBody;
    public GameObject lowerBody;
    public GameObject bloodEffect;
    public GameObject diePoint;

    private bool isDead;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void Die(float angle)
    {
        if (!isDead)
        {
            isDead = true;
            Instantiate(bloodEffect, diePoint.transform.position, Quaternion.Euler(0, 90 + angle, 0));
            Instantiate(upperBody, diePoint.transform.position, diePoint.transform.rotation).transform.localScale = transform.localScale;
            Instantiate(lowerBody, diePoint.transform.position, diePoint.transform.rotation).transform.localScale = transform.localScale;
        }

        Destroy(gameObject);
    }
}
