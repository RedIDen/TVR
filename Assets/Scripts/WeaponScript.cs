using UnityEngine;

public abstract class WeaponScript : MonoBehaviour
{
    public Transform shootPoint;
    public GameObject bullet;
    public Transform effectPoint;
    public GameObject effect;

    public int recoil = 20;
    public float timeBetweenShots = 0.0f;

    public abstract bool Shoot();
}
