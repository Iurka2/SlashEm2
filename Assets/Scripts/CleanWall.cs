using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CleanWall : MonoBehaviour
{

    [SerializeField] private Transform M1911Prefab;
    [SerializeField] private Transform SpawnPoint;
    public void Interact()
    {
       Transform M1911Transform =  Instantiate(M1911Prefab, SpawnPoint);
        M1911Transform.localPosition = Vector3.zero;
    }
}
