using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
public class PieceSpawner : MonoBehaviour
{
    public AudioClip _correctClip;
    public AudioClip _incorrectClip;

    private AudioSource _audioSource;

    public TetrisPiece[] _pieces;
    public Transform _spawnPoint;
    public Transform _leftLimit;
    public Transform _rightLimit;

    [SerializeField]
    private float _pieceDropSpeed = 1;
    public float PieceDropSpeed { get { return _pieceDropSpeed; } set { _pieceDropSpeed = value; } }


    private int _lastPieceIndex;

    public delegate void OnCreatedNewPieceDelegate(bool wasLastPieceSuccess);
    public OnCreatedNewPieceDelegate OnCreatedNewPiece;

    private TetrisPiece _spawnedPiece;

    // Start is called before the first frame update
    void Start()
    {
        _audioSource = GetComponent<AudioSource>();
        int index = Random.Range(0, _pieces.Length);
        while (index == _lastPieceIndex && _pieces.Length > 1)
        {
            index = Random.Range(0, _pieces.Length);
        }
        _spawnedPiece = Instantiate(_pieces[index], _spawnPoint.position, Quaternion.identity);
        _lastPieceIndex = index;
        _spawnedPiece.LeftLimit = _leftLimit.position.x;
        _spawnedPiece.RightLimit = _rightLimit.position.x;
        _spawnedPiece.DropInterval = _pieceDropSpeed;
        _spawnedPiece.OnDrop += CreateNewPiece;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    

    private void CreateNewPiece(bool correct) {
        int index = Random.Range(0, _pieces.Length);
        while (index == _lastPieceIndex && _pieces.Length > 1)
        {
            index = Random.Range(0, _pieces.Length);
        }
        _spawnedPiece = Instantiate(_pieces[index], _spawnPoint.position, Quaternion.identity);
        _lastPieceIndex = index;
        _spawnedPiece.LeftLimit = _leftLimit.position.x;
        _spawnedPiece.RightLimit = _rightLimit.position.x;
        _spawnedPiece.DropInterval = _pieceDropSpeed;
        _spawnedPiece.OnDrop += CreateNewPiece;

        if (correct)
        {
            _audioSource.PlayOneShot(_correctClip);
        }
        else {
            _audioSource.PlayOneShot(_incorrectClip);
        }
        

        if (OnCreatedNewPiece != null)
        {
            OnCreatedNewPiece.Invoke(correct);
        }
    }

    public void DestroySpawner() {
        Destroy(_spawnedPiece.gameObject);
        Destroy(gameObject);
    }

}
