using System;
using UnityEngine;

public class InputReader : MonoBehaviour
{
    [SerializeField] private KeyCode _launchKey = KeyCode.F;
    [SerializeField] private KeyCode _reloadKey = KeyCode.R;
    [SerializeField] private KeyCode _swingKey = KeyCode.Space;

    public Action CanPushSwing;
    public Action CanShoot;
    public Action CanRecharged;

    private void Update()
    {
        PushSwing();

        if (Input.GetKeyDown(_launchKey))
        {
            CanShoot?.Invoke();
        }
        else if (Input.GetKeyUp(_reloadKey))
        {
            CanRecharged?.Invoke();
        }
    }

    private void PushSwing()
    {
        if (Input.GetKeyDown(_swingKey))
        {
            CanPushSwing?.Invoke();
        }
    }
}