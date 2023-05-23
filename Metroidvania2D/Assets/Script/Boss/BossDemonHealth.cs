using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class BossDemonHealth : MonoBehaviour
{
    [SerializeField] private Slider sliderEnemy;
    [SerializeField] private Vector3 _offset;
    public float maxHPBoss = 500;
    public float currentHPBoss;
    public float _enemyHealth = 500;
    public float _enemySpeed;
    private void Start()
    {
        currentHPBoss = maxHPBoss;
        sliderEnemy.maxValue = _enemyHealth;
        sliderEnemy.value = _enemySpeed;
        sliderEnemy.gameObject.SetActive(false);
    }

    public void TakeDamage(float damage)
    {
        currentHPBoss -= damage;
        sliderEnemy.value = currentHPBoss;

        if (currentHPBoss <= 0)
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
    public void TakeDamageEnemy(float damage)
    {
        StartCoroutine(SliderActive());
        _enemyHealth -= damage;
        sliderEnemy.value = _enemyHealth;
        if (_enemyHealth <= 0)
        {
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
