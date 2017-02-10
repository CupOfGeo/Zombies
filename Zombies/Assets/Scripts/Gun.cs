using UnityEngine;
using System.Collections;

public class Gun : MonoBehaviour
{
    public GameObject shooter;
    public Rigidbody2D bulletPrefab;
    public float fireRate = 0.5f;
    public float coolDown;
    public float bulletSpeed = 0.005f;
    public float damage = 1f;
    public float yValue = 2.3f; // Used to make it look like it's shot from the gun itself (offset)
    public float xValue = 1f;

    public void Shoot()
    {

        Rigidbody2D bPrefab = Instantiate(bulletPrefab, new Vector3(transform.position.x + xValue, transform.position.y + yValue, 0), shooter.transform.rotation) as Rigidbody2D;
        coolDown = Time.time + fireRate;
        bPrefab.GetComponent<Projectile>().setGun(this);
        bPrefab.GetComponent<Projectile>().setShooter(shooter);
    }

    public GameObject WhosShooting()
    {
        return shooter;
    }

}
