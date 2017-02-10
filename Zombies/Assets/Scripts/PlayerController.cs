using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    public Gun gun;
    public float speed = 10f;
    private int health;
    public Text healthText;
    public Text deathText;
    bool alive = true;
    //Vector3 mousePosition;


    void Start()
    {
       
        health = 10;
        healthText.text = "Health: " + health.ToString();
        deathText.text = "";
    }

    public void Update()
    {
        Move();
        Look();
        if (Time.time >= gun.coolDown)
        {
            if (Input.GetMouseButton(0))
            {
                gun.Shoot();
            }
        }
        
    }

    void Look()
    {
        Vector3 objectPos = Camera.main.WorldToScreenPoint(transform.position);
        Vector3 dir = Input.mousePosition - objectPos;
        transform.rotation = Quaternion.Euler(new Vector3(0, 0, Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg));
    }


    public void Move()
    {
        if (alive)
        {
            if (Input.GetKey(KeyCode.A))
            {
                transform.position += Vector3.left * speed * Time.deltaTime;
            }
            if (Input.GetKey(KeyCode.D))
            {
                transform.position += Vector3.right * speed * Time.deltaTime;
            }
            if (Input.GetKey(KeyCode.W))
            {
                transform.position += Vector3.up * speed * Time.deltaTime;
            }
            if (Input.GetKey(KeyCode.S))
            {
                transform.position += Vector3.down * speed * Time.deltaTime;
            }
        }
    }

    void OnTriggerEnter2D(Collider2D c)
    {
        if (c.gameObject.CompareTag("Enemy") && alive)
        {
            OnHit();
        }
    }

    void OnHit()
    {
        health -= 1;
        healthText.text = "Health: " + health.ToString();
        if(health <= 0)
        {
            Death();
        }
    }

    void Death()
    {
        alive = false;
        deathText.text = "YOU DIE";
    }
}