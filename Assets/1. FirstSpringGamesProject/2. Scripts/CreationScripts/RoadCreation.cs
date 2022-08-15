using UnityEngine;

public class RoadCreation : ObjectCreation
{
    float DistanceBetweenRoadBlocks;
    Vector3 SpawnDistance;

    private void Awake()
    {
        CreateObjectsOfPool();
        SpawnDistance = transform.position;
        for (int i = 0; i < PoolSize; i++)
        {
            SpawnAtPosition();
        }
    }

    private void SpawnAtPosition()
    {
        SpawnFromPool(SpawnDistance, Quaternion.identity);

        //spawn right after previous one - current position + size in unity units * unity Plane-units (10)
        SpawnDistance.z += transform.GetChild(0).localScale.z * 10;
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.GetComponent<SpaceshipOnCollision>())
        {
            SpawnAtPosition();
        }
    }
}
