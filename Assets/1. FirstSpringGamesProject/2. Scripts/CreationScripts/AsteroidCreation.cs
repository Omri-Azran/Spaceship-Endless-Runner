using System.Collections.Generic;
using UnityEngine;

public class AsteroidCreation : ObjectCreation
{
    [SerializeField] Transform LeftPosition, CenterPosition, RightPosition;
    List<Transform> PossiblePositions = new List<Transform>();
    [SerializeField] int DistanceBetweenAsteroids = 5;
    LinkedList<Vector3> AstreroidCreatedQueue = new LinkedList<Vector3>();
    Vector3 CurrentPosition;

    protected bool CanCreateAnother = false;
    void Awake()
    {
        //create asteroids
        CreateObjectsOfPool();

        //populate list with positions
        PossiblePositions.Add(RightPosition);
        PossiblePositions.Add(CenterPosition);
        PossiblePositions.Add(LeftPosition);

        //assign random position at start
        CurrentPosition = PossiblePositions[Random.Range(0, PossiblePositions.Count)].transform.position;

        //add above position to a list.
        AstreroidCreatedQueue.AddLast(CurrentPosition);

        //position randomly for X amount of rows
        for (int i = 0; i < PoolSize; i++)
        {
            CreateAsteroid();
        }

    }

    private void OnTriggerExit(Collider other)
    {
        if (other.GetComponent<SpaceshipOnCollision>())
        {
            CreateAsteroid();
        }
    }
   
    private void CreateAsteroid()
    {
        //assign random position for the asteroid
        CurrentPosition = CreateRandomPosition(CurrentPosition);

        //Create asteroid
        SpawnFromPool(CurrentPosition, Quaternion.identity);

        //initialize the possible positions to allow all 3 positions
        PossiblePositions = new List<Transform> { RightPosition, CenterPosition, LeftPosition };

        //apply distance between asteroids
        CurrentPosition += new Vector3(0, 0, DistanceBetweenAsteroids);

        //add last positions to a list.
        AstreroidCreatedQueue.AddLast(CurrentPosition);

        //keep the list size at 1
        AstreroidCreatedQueue.RemoveFirst();
    }
    private Vector3 CreateRandomPosition(Vector3 CurrentPosition)
    {

        //handle cases where astroid in center blocks progress.
        if (CurrentPosition.x == CenterPosition.transform.position.x)
        {
            if (AstreroidCreatedQueue.Last.Value.x == RightPosition.transform.position.x)
            {
                PossiblePositions.Remove(LeftPosition);
            }
            else if (AstreroidCreatedQueue.Last.Value.x == LeftPosition.transform.position.x)
            {
                PossiblePositions.Remove(RightPosition);
            }
            else
            {
                CurrentPosition += new Vector3(0, 0, DistanceBetweenAsteroids);
            }
        }

        //randomize position from possible positions left
        CurrentPosition = new Vector3(PossiblePositions[Random.Range(0, PossiblePositions.Count)].transform.position.x, CurrentPosition.y, CurrentPosition.z);

        return CurrentPosition;
    }
}