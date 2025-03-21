using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Bomb : MonoBehaviour
{
    [SerializeField] private float _explosionDelay;
    [SerializeField] private Explosion _explosionPrefab;

    private WaitForSeconds _wait;
    private Rigidbody _rigidbody;
    private float _deletionTime;

    private void Awake()
    {
        _deletionTime = 0.1f;
        _wait = new WaitForSeconds(_explosionDelay);
        _rigidbody = GetComponent<Rigidbody>();
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.TryGetComponent(out Spoon spoon))
        {
            StartCoroutine(ExplosionCountdown());
        }
    }

    public Rigidbody GetRigidbody()
    {
        return _rigidbody;
    }

    private IEnumerator ExplosionCountdown()
    {
        yield return _wait;
        Explode();
    }

    private void Explode()
    {
        Instantiate(_explosionPrefab, transform.position, Quaternion.identity);

        Destroy(gameObject, _deletionTime);
    }
}