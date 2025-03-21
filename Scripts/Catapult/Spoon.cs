using System.Collections;
using UnityEngine;

public class Spoon : MonoBehaviour
{
    [SerializeField] private Transform _spawnPoint;
    [SerializeField] private Bomb _bombPrefab;
    [SerializeField] private ParticleSystem _fire;

    private Bomb _currentProjectile;
    private WaitForSeconds _wait;
    private float _delay;

    public bool IsLoaded { get; private set; }

    private void Awake()
    {
        _delay = 1f;
        _wait = new WaitForSeconds(_delay);
    }

    void Start()
    {
        StartCoroutine( WaitReloadCatapult());
    }

    public void Launch()
    {
        _fire.Play();

        _currentProjectile.transform.SetParent(null);
        _currentProjectile.GetRigidbody().isKinematic = false;

        IsLoaded = false;

        _currentProjectile = null;
    }

    public IEnumerator WaitReloadCatapult()
    {
        if (_currentProjectile != null) yield return null;

        yield return _wait;

        _currentProjectile = Instantiate(_bombPrefab,_spawnPoint);

        _currentProjectile.transform.SetParent(_spawnPoint);
        _currentProjectile.GetRigidbody().isKinematic = true;

        IsLoaded = true;
    }
}