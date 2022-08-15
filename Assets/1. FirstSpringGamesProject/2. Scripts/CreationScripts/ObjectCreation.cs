using System.Collections.Generic;
using UnityEngine;

public abstract class ObjectCreation : MonoBehaviour
{
    [SerializeField] protected GameObject PrefabToCreate;
    [SerializeField] protected int PoolSize;
    protected Queue<GameObject> Pool = new Queue<GameObject>();
    protected LinkedList<Transform> PositionQueue = new LinkedList<Transform>();
    protected virtual void CreateObjectsOfPool()
    {
        for (int i = 0; i < PoolSize; i++)
        {
            GameObject PB = Instantiate(PrefabToCreate, Vector3.zero, Quaternion.Euler(Vector3.zero), transform);
            PB.SetActive(false);
            Pool.Enqueue(PB);
        }
    }
    protected GameObject SpawnFromPool(Vector3 Position, Quaternion Rotation)
    {
        GameObject ObjToSpawn = Pool.Dequeue();

        ObjToSpawn.SetActive(true);
        ObjToSpawn.transform.position = Position;
        ObjToSpawn.transform.rotation = Rotation;

        Pool.Enqueue(ObjToSpawn);
        PositionQueue.AddLast(ObjToSpawn.transform);
        return ObjToSpawn;
    }

}