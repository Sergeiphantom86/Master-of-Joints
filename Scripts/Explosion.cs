using UnityEngine;

[RequireComponent(typeof(ParticleSystem))]
public class Explosion : MonoBehaviour
{
    private ParticleSystem _particleSystem;

    private void Awake()
    {
        _particleSystem = GetComponent<ParticleSystem>();
    }

    private void Start()
    {
        _particleSystem.Play();

        _particleSystem.Stop();
    }
}