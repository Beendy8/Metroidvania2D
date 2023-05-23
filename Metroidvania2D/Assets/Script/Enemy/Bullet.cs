using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    
    [HideInInspector] public bool goToRight = true;
    [SerializeField] int bulletSpeed = 3;
    [SerializeField] private AudioClip _hit;
    private Vector2 bulletVelocity; //поцизия цели
    public bool move;
    private bool isEnemyShooting;
    private Rigidbody2D _rigidbody2d;
    private Vector2 bulletDirection;

    private void Start()
    {
        _rigidbody2d = gameObject.GetComponent<Rigidbody2D>();

        StartCoroutine(MakeBulletVisible());
    }
    private void Update()
    {
        if (isEnemyShooting)
        {
            _rigidbody2d.velocity = bulletVelocity * bulletSpeed;
        }
        else
        {
            if (goToRight)
            {
                if (bulletDirection.x != 0)
                {
                    bulletDirection.x = bulletSpeed;
                }
            }
            else
            {
                if (bulletDirection.x != 0)
                {
                    bulletDirection.x = -bulletSpeed;
                }
            }
            _rigidbody2d.velocity = bulletDirection;
        }
    }
    public void SetBulletVelocity(Vector2 velocity)
    {
        bulletVelocity = velocity;
        isEnemyShooting = true;
    }
    public void SetHorizontalDirection()
    {
        _rigidbody2d = gameObject.GetComponent<Rigidbody2D>();
        bulletDirection = new Vector2(bulletSpeed, _rigidbody2d.velocity.y);
    }
    public void SetUpDirection()
    {
        _rigidbody2d = gameObject.GetComponent<Rigidbody2D>();
        bulletDirection = new Vector2(0, bulletSpeed);
    }
    public void SetDownDirection()
    {
        _rigidbody2d = gameObject.GetComponent<Rigidbody2D>();
        bulletDirection = new Vector2(0, -bulletSpeed);
    }

    private IEnumerator MakeBulletVisible()
    {
        yield return new WaitForSeconds(0.2f);
        GetComponent<SpriteRenderer>().enabled = true;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.GetComponent<PlayerHealth>().TakeDamage(10);
            SoundManager.instance.PlaySound(_hit);
        }
    }

}

