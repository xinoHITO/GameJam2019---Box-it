using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Rewired;
using UnityEngine.Events;
[RequireComponent(typeof(PlayerInput))]
public class TetrisPiece : MonoBehaviour
{
    public float _lateralGridSize = 3.5f;
    public float _dropGridSize = 1;
    [SerializeField]
    private float _dropInterval = 1;
    public float DropInterval { get {return _dropInterval; } set {_dropInterval = value; } }

    public float _hardDropSpeed = 10;

    public PieceContainer.ContainerType _containerType;

    private float _timeToNextDrop;

    private float _rightLimit = 5;
    public float RightLimit { get { return _rightLimit; } set { _rightLimit = value; } }
    private float _leftLimit = 5;
    public float LeftLimit { get { return _leftLimit; } set { _leftLimit = value; } }

    private PlayerInput _playerInput;

    private Vector3 _moveVector;
    
    public delegate void OnDropDelegate(bool correct);
    public OnDropDelegate OnDrop;

    public bool IsInHardDrop { get; set; }

    // Start is called before the first frame update
    void Start()
    {
        _timeToNextDrop = 0;
        _playerInput = GetComponent<PlayerInput>();
    }

    // Update is called once per frame
    void Update()
    {
        bool pressedLeft = _playerInput.PressedLeft;
        bool pressedRight = _playerInput.PressedRight;
        bool pressedDrop = _playerInput.PressedDrop;

        _moveVector = Vector3.zero;

        if (!IsInHardDrop)
        {
            LateralMovement(pressedRight, pressedLeft);

            SlowDrop();
        }

        HardDrop(pressedDrop);

        transform.position += _moveVector;
    }

    private void OnTriggerEnter(Collider other)
    {
        PieceContainer container = other.GetComponent<PieceContainer>();
        if (container != null)
        {
            GoIntoContainer(container);
        }
    }

    private void LateralMovement(bool pressedRight,bool pressedLeft) {
        if (pressedRight)
        {
            if (CheckLimit(Vector3.right))
            {
                _moveVector = Vector3.right;
            }
        }
        else if (pressedLeft)
        {
            if (CheckLimit(Vector3.left))
            {
                _moveVector = Vector3.left;
            }
        }
        _moveVector *= _lateralGridSize;
    }

    private bool CheckLimit(Vector3 direction)
    {
        bool result = true;
        Vector3 pos = transform.position + (direction * _lateralGridSize);
        if (pos.x > _rightLimit || pos.x < _leftLimit)
        {
            result = false;
        }
        return result;
    }

    private void SlowDrop() {
        _timeToNextDrop -= Time.deltaTime;
        if (_timeToNextDrop <= 0)
        {
            _moveVector += Vector3.down * _dropGridSize;
            _timeToNextDrop = _dropInterval;
        }
    }

    private void HardDrop(bool pressedDrop) {
        if (pressedDrop)
        {
            IsInHardDrop = true;
        }
        if (IsInHardDrop)
        {
            _moveVector += Vector3.down * _hardDropSpeed * Time.deltaTime;
        }
    }

    private void GoIntoContainer(PieceContainer container) {
        if (container == null)
            return;

        Debug.Log("piece:" + _containerType + "  other:" + container._containerType);
        container.ReceivePiece();
        if (_containerType == container._containerType)
        {
            OnDrop.Invoke(true);
        }
        else
        {
            OnDrop.Invoke(false);
        }
        Destroy(gameObject);

    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawLine(transform.position, transform.position + (Vector3.down * 5));
        Gizmos.DrawLine(transform.position + (Vector3.left*_lateralGridSize), transform.position + (Vector3.down * 5)+ (Vector3.left * _lateralGridSize));
        Gizmos.DrawLine(transform.position + (Vector3.right * _lateralGridSize), transform.position + (Vector3.down * 5) + (Vector3.right * _lateralGridSize));
    }
}
