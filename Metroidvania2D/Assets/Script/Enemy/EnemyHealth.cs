using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] private Slider sliderEnemy;
    [SerializeField] private Vector3 _offset;
    [SerializeField] private Animator animDead;
    public float maxHPEnemy = 5;
    public float currentHPEnemy;
    public float _enemyHealth = 5;
    public float _enemySpeed;
    private void Start()
    {
        currentHPEnemy = maxHPEnemy;
        sliderEnemy.maxValue = _enemyHealth;
        sliderEnemy.value = _enemySpeed;
        sliderEnemy.gameObject.SetActive(false);
    }

    public void TakeDamage(float damage)
    {
        currentHPEnemy -= damage;
        sliderEnemy.value = currentHPEnemy;

        if (currentHPEnemy <= 0)
        {
            Destroy(gameObject);
        }
    }

    public void SetHealthValue(int currentHPEnemy, int maxHPEnemy)
    {
        sliderEnemy.gameObject.SetActive(currentHPEnemy < maxHPEnemy);
        sliderEnemy.value = currentHPEnemy;
        sliderEnemy.maxValue = maxHPEnemy;
    }
    public void TakeDamageEnemy(int damage)
    {
        StartCoroutine(SliderActive());
        _enemyHealth -= damage;
        sliderEnemy.value = _enemyHealth;
        if (_enemyHealth <= 0)
        {
            animDead.SetTrigger("dead");
            Destroy(gameObject);
        }
    }

    IEnumerator SliderActive()
    {
        sliderEnemy.gameObject.SetActive(true);
        yield return new WaitForSeconds(1f);
        sliderEnemy.gameObject.SetActive(false);
    }
}
