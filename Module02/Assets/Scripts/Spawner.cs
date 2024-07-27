using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private Base target;
    [SerializeField] private Enemy enemyPrefab;
    [SerializeField] private float spawnDelay = 1;
    [SerializeField] private int enemyCount = 1;
    private int count = 0;
    private float elapsedTime = 0;

    void Update()
    {
        if (count == enemyCount)
        {
            enabled = false;
        }

        elapsedTime += Time.deltaTime;

        if (elapsedTime >= spawnDelay)
        {
            elapsedTime -= spawnDelay;
            count++;
            Instantiate(enemyPrefab, transform).SetTarget(target);
        }
    }
}
