using UnityEngine;
using UnityEngine.Playables;
using Unity.Cinemachine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private CinemachineCamera _thirdPersonCamera;
    [SerializeField] private CinemachineCamera _cockpitCamera;
    [SerializeField] private PlayableDirector _cinematicTimeline; 

    private CinemachineCamera _activeCamera;
    private float _idleTimer = 0f;
    private bool _isCinematicActive = false;
    private float idleThreshold = 10f;
    [SerializeField] private GameObject _cockPit;
    [SerializeField] private GameObject _spaceShip;
    private bool _isCutScene = false;
    
    void Start()
    {
        _activeCamera = _thirdPersonCamera;
        _spaceShip.SetActive(true);
        _cockPit.SetActive(false);
        SetActiveCamera(_activeCamera);
    }

    public void IsCut()
    {
        _isCutScene = !_isCutScene;
        if (_isCinematicActive)
        {
            _cinematicTimeline.Stop();
            _isCinematicActive = false;
        }
    }
    void Update()
    {
        if (_isCutScene)
        {
            _idleTimer = 0f;
            return;
        }
        if (Input.anyKeyDown || Input.GetAxis("Mouse X") != 0 || Input.GetAxis("Mouse Y") != 0)
        {
            _idleTimer = 0f;

          
            if (_isCinematicActive)
            {
                _cinematicTimeline.Stop();
                SetActiveCamera(_activeCamera);
                _isCinematicActive = false;
            }
        }
        else
        {
            _idleTimer += Time.deltaTime;
        }

    
        if (_idleTimer >= idleThreshold && !_isCinematicActive)
        {
            _cinematicTimeline.Play();
            _isCinematicActive = true;
        }

    
        if (Input.GetKeyDown(KeyCode.R) && !_isCinematicActive)
        {
            _activeCamera = (_activeCamera == _thirdPersonCamera) ? _cockpitCamera : _thirdPersonCamera;
            SetActiveCamera(_activeCamera);
        }
    }

    void SetActiveCamera(CinemachineCamera cam)
    {
        _thirdPersonCamera.Priority = (cam == _thirdPersonCamera) ? 10 : 0;
        _cockpitCamera.Priority = (cam == _cockpitCamera) ? 10 : 0;

        _cockPit.SetActive((cam == _thirdPersonCamera) ? false : true);
        _spaceShip.SetActive((cam == _cockpitCamera) ? false : true);
    }
}
