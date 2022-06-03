using System;
using UnityEngine;

public class WeaponSpawnerScript : MonoBehaviour
{
    public WeaponScript[] weapons;

    private float reloadTime = 10f;
    private float currentTime;
    private int index;
    private System.Random random = new System.Random();
    private bool isReady;

    // Start is called before the first frame update
    void Start()
    {
        this.index = this.random.Next(weapons.Length);
        this.currentTime = this.reloadTime / 5;
    }

    // Update is called once per frame
    void Update()
    {
        if (!this.isReady)
        {
            if (this.currentTime > 0)
            {
                this.currentTime -= Time.deltaTime;
            }
            else
            {
                this.isReady = true;
                this.ChangeWeapon(this.index);
            }
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (this.isReady)
        {
            PlayerScript player = collision.GetComponent<PlayerScript>();
            if (player != null)
            {
                if (Input.GetKey(player.changeWeapon))
                {
                    player.ChangeWeapon(this.index);
                    this.ChangeWeapon(-1);
                    this.currentTime = this.reloadTime;
                    this.isReady = false;
                    this.index = this.random.Next(weapons.Length);
                }
            }
        }
    }

    private void ChangeWeapon(int index)
    {
        foreach (var item in this.weapons)
        {
            item.gameObject.SetActive(false);
        }

        if (index != -1)
        {
            this.weapons[index].gameObject.SetActive(true);
        }
    }
}
