using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlimeHealth : MonoBehaviour
{
    [SerializeField] private Vector3 _offset;
    [SerializeField] private GameObject demon;
    public float maxHPEnemy = 1;
    public float currentHPEnemy;
    public float _enemyHealth = 1;
    public float _enemySpeed;
    private void Start()
    {
        currentHPEnemy = maxHPEnemy;
    }

    public void TakeDamage(float damage)
    {
        currentHPEnemy -= damage;

        if (currentHPEnemy <= 0)
        {
            demon.SetActive(true);
            Destroy(gameObject);
        }
    }

}
