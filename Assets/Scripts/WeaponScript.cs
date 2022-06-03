using UnityEngine;

public abstract class WeaponScript : MonoBehaviour
{
    public Transform shootPoint;
    public Transform effectPoint;
    public GameObject effect;
    public GameObject bullet;
    public float weight;

    public int recoil = 20;
    public float timeBetweenShots = 0.0f;

    public abstract bool Shoot();
}
