using UnityEngine;
using System.Collections;

public class Projectile : MonoBehaviour {
    Gun gun;
    GameObject shooter;
    float theta;
    Vector3 dir;

    // Use this for initialization
    void Awake ()
    {
        //shooter = gun.WhosShooting();
        //theta = shooter.transform.rotation.z;
        //dir = new Vector3(Mathf.Cos(theta) * 180 / Mathf.PI, Mathf.Sin(theta) * 180 / Mathf.PI, 0);
    }

	// Update is called once per frame
	void Update ()
    {
        //cool orbit efect
        //transform.position += transform.rotation * transform.position * gun.bulletSpeed * Time.deltaTime;
        transform.position += dir * gun.bulletSpeed * Time.deltaTime;
    }

    void OnTriggerEnter2D(Collider2D c)
    {
        if (c.gameObject.CompareTag("Enemy"))
        {
            Destroy(gameObject);
            c.gameObject.GetComponent<Enemy>().Damage(gun.damage);
        }
        if (c.gameObject.CompareTag("Wall"))
        {
            Destroy(gameObject);
        }
    }

    public void setGun(Gun g)
    {
        gun = g;
    }

    public void setShooter(GameObject s)
    {
        shooter = s;
        theta = (shooter.transform.rotation.eulerAngles.z)* Mathf.PI/180;
        dir = new Vector3((Mathf.Cos(theta)),(Mathf.Sin(theta)), 0);
        Debug.Log(shooter.transform.rotation);
    }
}
