using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float _speed = 5;
    [SerializeField] private float _jump = 20;
    [SerializeField] private LayerMask _groundLayer;
    [SerializeField] private bool _oneJump;
    [SerializeField] private AudioClip jumpSound;
    private Rigidbody2D _rigidbody2D;
    private Animator _anim;
    private BoxCollider2D _collider;

    float h;
    float v;

    private void Awake()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _anim = GetComponent<Animator>();
        _collider = GetComponent<BoxCollider2D>();
    }

    private void Update()
    {
        h = Input.GetAxis("Horizontal");
        _rigidbody2D.velocity = new Vector2(h * _speed, _rigidbody2D.velocity.y);

        if (Input.GetKeyDown(KeyCode.Space) && isGrounded())
        {
            Jump();
            StartCoroutine(OneJump());
        }

        else if (Input.GetKeyDown(KeyCode.Space) && !isGrounded() && _oneJump)
        {
            _rigidbody2D.AddForce(Vector2.up * _jump);
            _oneJump = false;
            _anim.SetTrigger("jump");
            //SoundManager.instance.PlaySound(jumpSound);
        }

        if (isGrounded())
        {
            _oneJump = false;
        }

        Flip();
        _anim.SetBool("run", h != 0);
    }

    private void Flip()
    {
        if (h < -0.01f)
        {
            transform.localScale = new Vector3(-10f, 10f, 0); 
        }
        else if (h > 0.01f)
        {
            transform.localScale = new Vector3(10f, 10f, 0);
        }
    }

    private void Jump()
    {
        _rigidbody2D.AddForce(Vector2.up * _jump);
        _anim.SetTrigger("jump");
        //SoundManager.instance.PlaySound(jumpSound);
    }

    private bool isGrounded()
    {
        RaycastHit2D raycastHit = Physics2D.BoxCast(_collider.bounds.center, _collider.bounds.size, 0, Vector2.down, 0.1f, _groundLayer);
        return raycastHit.collider != null;
    }

    IEnumerator OneJump()
    {
        yield return new WaitForSeconds(0.2f);
        _oneJump = true;
    }

}
