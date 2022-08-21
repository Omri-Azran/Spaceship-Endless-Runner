using UnityEngine;

public class PointRewarder : MonoBehaviour
{
    const int AsteroidsCollisionLayer = 6;
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.layer==AsteroidsCollisionLayer)
            Score.AddScore();
    }
}
