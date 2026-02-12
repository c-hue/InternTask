// Randomly spawns hazards that slows player down
using UnityEngine;

public class Hazards : MonoBehaviour
{
    [SerializeField] GameObject[] hazardPrefabs;

    [Header("Spawn Settings")]
    [SerializeField] public Collider2D spawnArea;
    [SerializeField] public LayerMask blockedArea;
    [SerializeField] float offset = 1f;
    [SerializeField] float spawnInterval = 15f;
    [SerializeField] float hazardLifetime = 15f;

    float timer = 0f;

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (timer >= spawnInterval)
        {
            timer = 0f;
            SpawnHazard();
        }
    }

    private void SpawnHazard()
    {
        Bounds b = spawnArea.bounds;
        while (true)
        {
            float x = Random.Range(b.min.x, b.max.x);
            float y = Random.Range(b.min.y, b.max.y);
            Vector2 location = new Vector2(x, y);

            // reject if inside blocked area
            if (Physics2D.OverlapCircle(location, offset, blockedArea) != null)
                continue;

            // reject if overlapping with another hazard
            if (Physics2D.OverlapCircle(location, offset, LayerMask.GetMask("Hazard")) != null)
                continue;

            // choose between spill or paper pile
            GameObject hazard = Instantiate(hazardPrefabs[Random.Range(0,2)], location, Quaternion.identity);
            Destroy(hazard, hazardLifetime);
            break;
        }
    }
}
