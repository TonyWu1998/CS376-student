using UnityEngine;

/// <summary>
/// Periodically spawns the specified prefab in a random location.
/// </summary>
public class Spawner : MonoBehaviour
{
    /// <summary>
    /// Object to spawn
    /// </summary>
    public GameObject Prefab;

    /// <summary>
    /// Seconds between spawn operations
    /// </summary>
    public float SpawnInterval = 20;

    /// <summary>
    /// How many units of free space to try to find around the spawned object
    /// </summary>
    public float FreeRadius = 10;

    //public float spawn_speed = 10.0f;
    private float spawn_next = 0.0f;

    /// <summary>
    /// Check if we need to spawn and if so, do so.
    /// </summary>
    // ReSharper disable once UnusedMember.Local
    void Update()
    {
        // TODO
        
        if (Time.time > spawn_next)
        {
            Vector2 spawn_p = SpawnUtilities.RandomFreePoint(FreeRadius);
            spawn_next = Time.time + SpawnInterval;
            Instantiate(Prefab, new Vector3(spawn_p.x, spawn_p.y, 0), this.transform.rotation);
            Prefab.name = "spawn";
        }
    }
}
