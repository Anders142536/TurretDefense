using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject Enemy;
    private Transform EnemiesParent;
    private List<GameObject> enemies;


    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("starting game manager");
        enemies = new List<GameObject>();
        EnemiesParent = new GameObject("Board").transform;
        GameObject newEnemyInstance = Instantiate(Enemy, new Vector3(-15f, 0f, 0f), Quaternion.identity) as GameObject;

        enemies.Add(newEnemyInstance);
        newEnemyInstance.transform.SetParent(EnemiesParent);
    }

    // Update is called once per frame
    void Update()
    {
        foreach (GameObject enemy in enemies)
        {
            Vector2 position = enemy.transform.position;
            Vector2 newPosition = new Vector2(position.x + 1 * Time.deltaTime, position.y);
            enemy.transform.position = newPosition;
        }
    }
}
