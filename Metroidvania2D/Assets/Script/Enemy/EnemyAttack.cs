using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    [SerializeField] private Transform _attackPoint;
    [SerializeField] private LayerMask _playerLayerMask;
    [SerializeField] private Animator _animator;
    [SerializeField] private AudioClip _hit;
    public float _attackRange;
    private float _attackDilet = 1f;
    private bool inZoen;


    private void Start()
    {
        _animator = GetComponent<Animator>();
    }
    private void Update()
    {
        if (CollidPlayer() && inZoen == false)
        {
            inZoen = true;
            StartCoroutine(CanAttack());
        }
    }
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(_attackPoint.position, _attackRange);
    }

    public void HitPlayer()
    {
        RaycastHit2D hitPlayer = Physics2D.CircleCast(_attackPoint.position, _attackRange, transform.right, _attackRange, _playerLayerMask, 0f);

        if (hitPlayer.collider != null)
        {
            PlayerHealth p = hitPlayer.collider.GetComponent<PlayerHealth>();
            p.TakeDamage(10);
        }
        
    }
    public bool CollidPlayer()
    {
        RaycastHit2D hitPlayer = Physics2D.CircleCast(_attackPoint.position, _attackRange, transform.right, _attackRange, _playerLayerMask, 0f);

        return hitPlayer.collider != null;
    }

    IEnumerator CanAttack()
    {
        while (CollidPlayer())
        {
            //SoundManager.instance.PlaySound(_hit);
            _animator.SetTrigger("eAttack");
            yield return new WaitForSeconds(_attackDilet);
        }
        inZoen = false;
    }

}
