using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PieceContainer : MonoBehaviour
{    
    public enum ContainerType
    {
        Clothes,
        Shoes,
        Decorations,
        Toys,
        School,
        Cutlery,
        Glassware,
        Pans,
        Plates
    }
    public ContainerType _containerType = ContainerType.Clothes;

    private PieceSpawner _spawner;
    private Animator _animator;

    // Start is called before the first frame update
    void Start()
    {
        _animator = GetComponentInChildren<Animator>();
        _spawner = FindObjectOfType<PieceSpawner>();        
    }

    public void ReceivePiece() {
        _animator.SetTrigger("squash");
    }
}
