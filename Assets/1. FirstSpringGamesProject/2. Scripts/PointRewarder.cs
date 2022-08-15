using UnityEngine;

public class PointRewarder : MonoBehaviour
{
    private void OnTriggerExit(Collider other)
    {
        if (other.GetComponent<AsteroidBehaviour>())
            Score.AddScore();
    }
}
