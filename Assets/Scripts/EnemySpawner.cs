using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    Enemy spawnEnemy;
    [SerializeField] Enemy enemyPrefab;

    private void Start()
    {
        spawnEnemy = Instantiate(enemyPrefab, transform.position, Quaternion.identity); // zostaw domyœln¹ rotacjê
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        Movment target = other.GetComponent<Movment>();
        if (target == null)
        {
            return;
        }
        spawnEnemy.SetTarget(target.transform);

    }
    void OnTriggerExit2D(Collider2D other)
    {
        Movment target = other.GetComponent<Movment>();
        if (target == null)
        {
            return;
        }
        spawnEnemy.SetTarget(this.transform);

    }


}
