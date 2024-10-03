using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyContainerController : MonoBehaviour
{
    [SerializeField] GameManager gameManager;
    [SerializeField] GameObject enemyPrefab;
    [SerializeField] float speed;
    [SerializeField] float direction;
    [SerializeField] float timeGeneratorEnemy;
    private float CurrentTime = 0;

    private void Awake()
    {
        enemyPrefab = GetComponent<GameObject>();
        gameManager = GetComponent<GameManager>();
    }

    private void Update()
    {
        if (CurrentTime >= timeGeneratorEnemy) { 
        Instantiate(enemyPrefab,new Vector3( Random.Range(-96.7f,60.4f ), Random.Range(-13.8f,10.5f),80.6f),
            Quaternion.Euler(Random.Range(0,90), Random.Range(0, 90), 0));
            CurrentTime = 0;
        }
        CurrentTime = CurrentTime + Time.deltaTime;

    }

    private void FixedUpdate()
    {
        enemyPrefab.GetComponent<Rigidbody>().velocity = new Vector3(enemyPrefab.GetComponent<Rigidbody>().velocity.x,
            enemyPrefab.GetComponent<Rigidbody>().velocity.y, speed * direction);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other != null && other.gameObject.tag =="Player")
        {
            gameManager.SetLife(gameManager.CurrentLife - 1);
            Destroy(enemyPrefab);
        }
        else
        {
            Destroy(enemyPrefab,10);
        }
    }
}
