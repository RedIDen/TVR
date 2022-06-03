public class SawScript : WeaponScript
{
    public DiscScript disc;

    // Start is called before the first frame update
    void Start()
    {
        this.weight = 1;
    }

    // Update is called once per frame
    void Update()
    {
    }


    public override bool Shoot()
    {
        this.disc.turnedOn = true;
        this.disc.time = 1;
        return true;
    }
}
