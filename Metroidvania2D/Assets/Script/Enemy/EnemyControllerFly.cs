using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyControllerFly : MonoBehaviour
{
    [SerializeField] LayerMask playerMask;
    public float _enemySpeed;
    private Rigidbody2D _rigidbody2d;
    private GameObject detectedPlayer;


    private void Start()
    {
        _rigidbody2d = GetComponent<Rigidbody2D>();
    }
    private void Update()
    {
        Move();
        Turn();
    }
    void Turn()
    {
        if (detectedPlayer != null)
        {
            if (detectedPlayer.transform.position.x < transform.position.x)
            {
                transform.localScale = new Vector3(10f, 10f, 1);
            }
            else
            {
                transform.localScale = new Vector3(-10f, 10f, 1);
            }
        }
    }
    void Move()
    {
        if (detectedPlayer != null)
        {
            if (detectedPlayer.transform.position.x < transform.position.x)
            {
                _rigidbody2d.velocity = new Vector3(-1, _rigidbody2d.velocity.y, 0);

            }
            else
            {
                _rigidbody2d.velocity = new Vector3(1, _rigidbody2d.velocity.y, 0);
            }
        }
    }
}
