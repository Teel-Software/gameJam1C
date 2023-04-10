using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private GameObject _enemyPrefab;
    private void Start()
    {
        Instantiate(_enemyPrefab, GridController.Instance.GetRandomGridPositionToWorldPosition(), Quaternion.identity);
    }
}
