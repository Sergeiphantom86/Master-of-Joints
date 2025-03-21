using UnityEngine;

[RequireComponent(typeof(SpringJoint), typeof(Rigidbody))]
public class CatapultController : MonoBehaviour
{
    [SerializeField] private Spoon _spoon;
    [SerializeField] private InputReader _inputReader;

    private Rigidbody _rigidbody;
    private SpringJoint _springJoint;
    private Vector3 _anchorForShot;
    private Vector3 _chargingAnchor;


    private void Awake()
    {
        _springJoint = GetComponent<SpringJoint>();
        _rigidbody = GetComponent<Rigidbody>();

        _anchorForShot = new Vector3(0, 1.48f, -0.22f);
        _chargingAnchor = new Vector3(0, 0.69f, -0.99f);
    }

    private void OnEnable()
    {
        _inputReader.CanShoot += Shoot;
        _inputReader.CanRecharged += Recharge;
    }

    private void OnDisable()
    {
        _inputReader.CanShoot -= Shoot;
        _inputReader.CanRecharged -= Recharge;
    }

    private void Shoot()
    {
        if (_spoon.IsLoaded)
        {
            SetAnchor(_anchorForShot);
            LaunchProcess();
            _spoon.Launch();
        }
    }

    private void Recharge()
    {
        if (_spoon.IsLoaded == false)
        {
            SetAnchor(_chargingAnchor);
            LaunchProcess();
            StartCoroutine(_spoon.WaitReloadCatapult());
        }
    }

    public void SetAnchor(Vector3 positionAnchor)
    {
        _springJoint.anchor = positionAnchor;
    }

    private void LaunchProcess()
    {
        _rigidbody.position = transform.position;
        _springJoint.minDistance = 0;
    }
}