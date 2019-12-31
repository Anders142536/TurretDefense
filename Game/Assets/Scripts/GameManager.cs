using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance = null;
    public Enemy Enemy;
    public int enemyCount;
    public float enemySpawnDelay;

    private Transform EnemiesParent;
    private List<Enemy> enemies;


    // Start is called before the first frame update
    void Start()
    {
        if (instance == null)
        {
            instance = this;
        } else if (instance != this)
        {
            Destroy(gameObject);
        }

        Debug.Log("starting game manager");
        enemies = new List<Enemy>();
        EnemiesParent = new GameObject("Board").transform;

        StartCoroutine(SpawnEnemies(Enemy, enemyCount, enemySpawnDelay));
        
    }

    // Update is called once per frame
    void Update()
    {
        foreach (Enemy enemy in enemies)
        {
            Vector2 position = enemy.transform.position;
            Vector2 newPosition = new Vector2(position.x + 1 * Time.deltaTime, position.y);
            enemy.transform.position = newPosition;
        }
    }

    public void addEnemy(Enemy toAdd)
    {
        toAdd.transform.SetParent(EnemiesParent);
        enemies.Add(toAdd);
    }

    private IEnumerator SpawnEnemies(Enemy enemy, int enemyCount, float enemySpawnDelay)
    {
        while (enemies.Count < enemyCount)
        {
            Debug.Log("spawning enemy");
            Instantiate(enemy, new Vector3(-17, -1, 0), Quaternion.identity);
            yield return new WaitForSeconds(enemySpawnDelay);
        }
    }
}
