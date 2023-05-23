using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.PlayerSettings;

public class MelliAttack : MonoBehaviour
{
    [SerializeField] private Transform _attackPoint;
    [SerializeField] private LayerMask _enemyLayerMask;
    [SerializeField] private Animator _animator;
    //[SerializeField] private AudioClip swordHit;
    //[SerializeField] private AudioClip dead;
    //[SerializeField] private AudioClip _hitEnemy;

    public float _attackRange;
    public bool _canAttack;
    private float _attackDilet = 1f;

    private void Start()
    {
        _animator = GetComponent<Animator>();
        _canAttack = true;
    }
    private void Update()
    {
        if (Input.GetMouseButtonDown(0) && _canAttack)
        {
            Attack();
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(_attackPoint.position, _attackRange);
    }

    private void Attack()
    {
        //SoundManager.instance.PlaySound(swordHit);
        _animator.SetTrigger("attack");
        _canAttack = false;
        StartCoroutine(CanAttack());
    }

    public void HitEnemy(int damage)
    {
        Collider2D[] hitEnemy = Physics2D.OverlapCircleAll(_attackPoint.position, _attackRange, _enemyLayerMask);

        foreach (Collider2D enemy in hitEnemy)
        {
            //SoundManager.instance.PlaySound(_hitEnemy);
            enemy.GetComponent<EnemyHealth>().TakeDamageEnemy(damage);
        }
    }
    

    IEnumerator CanAttack()
    {
        yield return new WaitForSeconds(_attackDilet);
        _canAttack = true;
    }


}
