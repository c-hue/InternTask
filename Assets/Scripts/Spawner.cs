// Randomly spawns hazards and boosts that affect player movement speed
using UnityEngine;

public class Hazards : MonoBehaviour
{
    [SerializeField] GameObject[] hazardPrefabs;
    [SerializeField] GameObject boostPrefab;

    [Header("Spawn Settings")]
    [SerializeField] Collider2D spawnArea;
    [SerializeField] LayerMask blockedArea;
    [SerializeField] float offset = 1f;

    [Header("Hazard Settings")]
    [SerializeField] float hazardInterval = 5f;
    [SerializeField] float hazardLifetime = 15f;
    float hazardTimer = 0f;

    [Header("Boost Settings")]
    [SerializeField] float boostInterval = 20f;
    [SerializeField] float boostLifetime = 50f; 
    float boostTimer = 0f;

    // Update is called once per frame
    void Update()
    {
        // Spawn hazards
        hazardTimer += Time.deltaTime;
        int num = 0;
        if (hazardTimer >= hazardInterval)
        {
            hazardTimer = 0f;
            num = Random.Range(0,2); // choose between spill or paper pile
            Spawn(hazardPrefabs[num], hazardLifetime);
        }

        // Spawn boosts
        boostTimer += Time.deltaTime;
        if (boostTimer >= boostInterval)
        {
            boostTimer = 0f;
            Spawn(boostPrefab, boostLifetime);
        }

    }

    // spawn at random location on map
    private void Spawn(GameObject prefab, float lifetime)
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

            // reject if overlapping with another boost
            if (Physics2D.OverlapCircle(location, offset, LayerMask.GetMask("Boost")) != null)
                continue;

            // set spawn and despawn
            GameObject spawned = Instantiate(prefab, location, Quaternion.identity);
            Destroy(spawned, lifetime);
            break;
        }
    }
}
