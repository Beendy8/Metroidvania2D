using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyControllerGround : MonoBehaviour
{
    [SerializeField] private Transform[] _point;
    [SerializeField] private Transform _player;
    [SerializeField] float _agroDistance;
    public int nextWayPoint;
    public float _enemySpeed;
    
    public bool _angry = false;
    private Rigidbody2D _rigidbody2D;
    private Animator _anim;
    private BoxCollider2D _collider;
    private float distToPlayer;

    private void Awake()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _anim = GetComponent<Animator>();
        _collider = GetComponent<BoxCollider2D>();
        nextWayPoint = 1;
    }

    private void Update()
    {
        if (!_angry)
        {
            Move();
        }
        if (_player != null)
        {
            distToPlayer = Vector2.Distance(transform.position, _player.position);
        }
        if (distToPlayer < _agroDistance)
        {
            StartHunting();
        }
        else if (distToPlayer > _agroDistance)
        {
            StopHunting();
        }
    }
    private void Move()
    {
        transform.position = Vector2.MoveTowards(transform.position, _point[nextWayPoint].position, _enemySpeed * Time.deltaTime);

        if (transform.position == _point[nextWayPoint].position)
          {
            if (nextWayPoint < _point.Length - 1)
            {
                nextWayPoint++;
                transform.localScale = new Vector3(-10f, 10f, 0);
            }
            else if(nextWayPoint == _point.Length -1)
            {
                nextWayPoint = 0;
                transform.localScale = new Vector3(10f, 10f, 0);
            }
        }
        
    }
    
    private void StartHunting()
    {
        Vector2 direction = (_player.position - transform.position).normalized;
        _rigidbody2D.velocity = direction * _enemySpeed;
        if (direction.x > 0)
        {
            transform.localScale = new Vector3(10f, 10f, 0);
        }
        else if (direction.x < 0)
        {
            transform.localScale = new Vector3(-10f, 10f, 0);
        }
        _angry = true;
    }
    private void StopHunting()
    {
        _rigidbody2D.velocity = Vector2.zero;

        if (_point[nextWayPoint].position.x < transform.position.x)
        {
            transform.localScale = new Vector3(-10f, 10f, 0);
        }
        else if (_point[nextWayPoint].position.x > transform.position.x)
        {
            transform.localScale = new Vector3(10f, 10f, 0);
        }
        _angry = false;
    }
    public void SetSpeed(int v)
    {
        if (v == 1)
        {
            _enemySpeed = 2;
        }
        else
        {
            _enemySpeed = 0;
        }
    }

}
