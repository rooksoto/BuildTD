using Cinemachine;
using UnityEngine;

public class CameraHandler : MonoBehaviour {
    [SerializeField] private CinemachineVirtualCamera cinemachineVirtualCamera;

    private const float MoveSpeed = 30f;

    private const float ZoomAmount = 2f;
    private const float ZoomSpeed = 4f;
    private const float MINOrthographicSize = 10F;
    private const float MAXOrthographicSize = 30F;

    private float _orthographicSize;
    private float _targetOrthographicSize;

    private void Start() {
        _orthographicSize = cinemachineVirtualCamera.m_Lens.OrthographicSize;
        _targetOrthographicSize = _orthographicSize;
    }

    private void Update() {
        HandleMovement();
        HandleZoom();
    }

    private void HandleMovement() {
        var x = Input.GetAxisRaw("Horizontal");
        var y = Input.GetAxisRaw("Vertical");

        var moveDirection = new Vector3(x, y).normalized;
        transform.position += moveDirection * (MoveSpeed * Time.deltaTime);
    }

    private void HandleZoom() {
        _targetOrthographicSize += -Input.mouseScrollDelta.y * ZoomAmount;
        _targetOrthographicSize = Mathf.Clamp(_targetOrthographicSize, MINOrthographicSize, MAXOrthographicSize);
        _orthographicSize = Mathf.Lerp(_orthographicSize, _targetOrthographicSize, Time.deltaTime * ZoomSpeed);
        cinemachineVirtualCamera.m_Lens.OrthographicSize = _orthographicSize;
    }
}