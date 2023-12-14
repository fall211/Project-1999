using UnityEngine;
using System.Collections.Generic;


public class TopDownPlayerController : MonoBehaviour
{

    private Vector2 _movementInput;
    private Vector3 _lastPosition;
    [HideInInspector] public Vector3 _velocity;
    private ContactFilter2D _contactFilter2D = new ContactFilter2D();
    private List<RaycastHit2D> _hitBuffer = new List<RaycastHit2D>();
    [SerializeField] private Transform _raycastOrigin;

    public float moveSpeed = 1f;

    private Camera _mainCamera;
    [SerializeField] private float _cameraMoveSpeed = 1f;



    private void Update() {
        if (TopDownManager.Instance.state != TopDownManager.GameState.Playing) return;
        Debug.Log(TopDownManager.Instance.state);
        _lastPosition = transform.position;
        _movementInput = new(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        
        if (_movementInput != Vector2.zero){
            bool success = TryMove(_movementInput);
            if (!success){
                success = TryMove(new Vector2(_movementInput.x, 0));
                if (!success){
                    success = TryMove(new Vector2(0, _movementInput.y));
                }
            }
        }


        _velocity = (transform.position - _lastPosition) / Time.deltaTime;

        MoveCamera();

    }

    private bool TryMove(Vector2 direction)
    {
        _contactFilter2D.SetLayerMask(LayerMask.GetMask("Obstacle"));
        var hitCount = Physics2D.Raycast(_raycastOrigin.position, direction, _contactFilter2D, _hitBuffer, (moveSpeed * Time.deltaTime) + 0.1f);
        if (hitCount > 0) return false;

        var moveHere = new Vector3(direction.x, direction.y, 0);
        moveHere = Vector3.ClampMagnitude(moveHere, 1f);
        moveHere *= Time.deltaTime * moveSpeed;
        transform.position += moveHere;

        return true;
    }

    private void MoveCamera()
    {
        if (_mainCamera == null) _mainCamera = Camera.main;
        if (_mainCamera == null) return;

        var cameraPos = _mainCamera.transform.position;
        var playerPos = transform.position;
        var newPos = Vector3.Lerp(cameraPos, playerPos, Time.deltaTime * _cameraMoveSpeed);
        newPos.z = -10;
        _mainCamera.transform.position = newPos;
    }

}

