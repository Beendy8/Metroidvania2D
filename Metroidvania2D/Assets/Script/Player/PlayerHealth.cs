using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] private Slider _healthBar;
    [SerializeField] private AudioClip dead;
    [SerializeField] private UIManager uiManager;
    public float _healthMax = 100;
    public float _currentHealth;

    private void Start()
    {
        _currentHealth = _healthMax;
    }

    public void TakeDamage(float damage)
    {
        _currentHealth -= damage;
        _healthBar.value = _currentHealth;

        if (_currentHealth <= 0)
        {
            uiManager.GameOver();
            //SoundManager.instance.PlaySound(dead);
            Destroy(gameObject);
        }
    }

}
