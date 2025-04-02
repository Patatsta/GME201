using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class ShipControls : MonoBehaviour
{
    [SerializeField] private float _rotSpeedVert;
    [SerializeField] private float _rotSpeedHor;
    [SerializeField] private float _moveSpeed;
    [SerializeField] private float _currentSpeed;
    private float _vertical;
    private float _horizontal;
    [SerializeField] private float _maxRotate;
    [SerializeField] private GameObject _shipModel;

    public bool _isCutScene = false;

    [SerializeField] CameraController _camCon;
    // Start is called before the first frame update
    void Start()
    {
        _currentSpeed = 1;
    }

    public void IsCutScene()
    {
        _isCutScene = !_isCutScene;
        _camCon.IsCut();
    }

    // Update is called once per frame
    void Update()
    {
        if (!_isCutScene)
        {
            ShipMovement();
        }
       
    }

    private void ShipMovement()
    {
        _vertical = Input.GetAxis("Vertical");
        _horizontal = Input.GetAxis("Horizontal");

        if (Input.GetKeyDown(KeyCode.T))
        {
            _currentSpeed++;
            if (_currentSpeed > 4)
            {
                _currentSpeed = 4;
            }
        }//increase speed

        if (Input.GetKeyDown(KeyCode.G))
        {
            _currentSpeed--;
            if (_currentSpeed < 1)
            {
                _currentSpeed = 1;
            }
        }//decrease speed

        Vector3 rotateH = new Vector3(0, _horizontal, 0);
        transform.Rotate(rotateH * _rotSpeedHor * Time.deltaTime);

        Vector3 rotateV = new Vector3(_vertical, 0, 0);
        transform.Rotate(rotateV * _rotSpeedVert * Time.deltaTime);

        transform.Rotate(new Vector3(0, 0, -_horizontal * 0.2f), Space.Self);

        transform.position += transform.forward * _currentSpeed * Time.deltaTime;
    }
}
