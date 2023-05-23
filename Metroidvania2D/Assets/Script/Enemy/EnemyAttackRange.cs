using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyAttackRange : MonoBehaviour
{
    [SerializeField] LayerMask playerMask;
    [SerializeField] Bullet bullet;
    private int rayLength = 10;
    private bool canShoot = true;
    private GameObject detectedPlayer;
    
    void Update()
    {
        Vector2[] rayVectors = { Vector2.left, new Vector2(-0.5f, 0.5f), Vector2.up, new Vector2(0.5f, 0.5f), Vector2.right, new Vector2(0.5f, -0.5f), Vector2.down, new Vector2(-0.5f, -0.5f) };
        if (canShoot)
        {
            foreach (Vector2 rayVector in rayVectors)
            {
                RaycastHit2D hit = Physics2D.Raycast(transform.position, rayVector, rayLength, playerMask);
                Debug.DrawRay(transform.position, rayVector * rayLength, Color.red, 0.5f);
                if (hit.collider != null)
                {
                    if (detectedPlayer == null)
                    {
                        detectedPlayer = hit.collider.gameObject;
                    }
                    Bullet b = GameObject.Instantiate<Bullet>(bullet, bullet.transform.position, bullet.transform.rotation);
                    Vector3 playerPosition = hit.collider.transform.position;
                    Vector2 bulletVelocity = playerPosition - b.transform.position;
                    bulletVelocity = bulletVelocity.normalized;

                    b.SetBulletVelocity(bulletVelocity);

                    b.gameObject.SetActive(true);
                    b.move = true;
                    GameObject.Destroy(b.gameObject, 3f);
                    canShoot = false;
                    StartCoroutine(CoolDown());
                }
            }
        }

    }

    IEnumerator CoolDown()
    {
        int timer = 2;
        while (timer > 0)
        {
            timer--;
            yield return new WaitForSeconds(1);

        }
        canShoot = true;
    }
    
}
