using UnityEngine;

public class SwingController : MonoBehaviour
{
    [SerializeField] private float swingForce;
    [SerializeField] private InputReader inputReader;

    private Rigidbody _rigidbodySwing;

    void Start()
    {
        _rigidbodySwing = GetComponent<Rigidbody>();
    }

    private void OnEnable() => inputReader.CanPushSwing += RockUp;

    private void OnDisable() => inputReader.CanPushSwing -= RockUp;

    private void RockUp()
    {
        _rigidbodySwing.AddForce(Vector3.forward * swingForce, ForceMode.Impulse);
    }
}