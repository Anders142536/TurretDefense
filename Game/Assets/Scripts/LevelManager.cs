using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    public static LevelManager instance = null;
    public Enemy Enemy;
    public int enemyCount;
    public float enemySpawnDelay;
    public int sizeFirstWave;   //currently unused
    public int waveSizeGrowth;  //currently unused

    private Transform EnemiesParent;
    private List<Enemy> enemies;


    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("starting game manager");

        if (instance == null) instance = this;
        else if (instance != this) Destroy(gameObject);

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

    public void Pause()
    {

    }

    public void backToMainMenu()
    {
        Debug.Log("back to main menu");
        SceneManager.LoadScene(0);
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
