using UnityEngine;
using System.Collections;

public class FireTrap : MonoBehaviour
{
    [SerializeField] private float damage;
    [SerializeField] private float _activationDelay;
    [SerializeField] private float _activeTime;
    [SerializeField] private AudioClip _fireTrap;
    private Animator _animator;
    private SpriteRenderer _spriteRenderer;
    private bool _triggered;
    private bool _active;
    private void Awake()
    {
        _animator = GetComponent<Animator>();
        _spriteRenderer= GetComponent<SpriteRenderer>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            if (!_triggered)
            {
                StartCoroutine(ActivateFiretrap());
            }
            if (_active)
            {
                collision.GetComponent<PlayerHealth>().TakeDamage(damage);
            }
        }
    }
    private IEnumerator ActivateFiretrap()
    {
        _triggered = true;
        _spriteRenderer.color = Color.red;
        yield return new WaitForSeconds(_activationDelay);
        SoundManager.instance.PlaySound(_fireTrap);
        _spriteRenderer.color = Color.white;
        _active = true;
        _animator.SetBool("activated", true);
        yield return new WaitForSeconds(_activeTime);
        _active = false;
        _triggered = false;
        _animator.SetBool("activated", false);
    }
}
