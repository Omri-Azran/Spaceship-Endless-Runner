using System.Collections;
using UnityEngine;

public class SpaceshipOnCollision : MonoBehaviour
{
    [SerializeField] GameObject ExplosionEffectChild;
    [SerializeField] GameObject FlameEffectChild;
    [SerializeField] GameObject PointWall;
    Renderer _Renderer;
    Collider SpaceshipCollider;
    const int AsteroidsCollisionLayer = 6;

    [SerializeField] EffectManager _EffectManager;
    [SerializeField] SceneMover _SceneMover;
    private void Awake()
    {
        _Renderer = GetComponent<Renderer>();
        SpaceshipCollider = GetComponent<Collider>();
    }
    //lose on collision with asteroid
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer==AsteroidsCollisionLayer)
        {
            //StartCoroutine(EndGame());
            EndGame();
        }
    }
    
    void EndGame()
    {
        if (AudioManager.Instance)
            AudioManager.Instance.PlayOnCollision();
        else
            Debug.Log("No Audio Manager in the scene. Please start game from Main Menu");
        _EffectManager.CreateEffect(transform.position);        
        _SceneMover.EndGameOnLoss();
        Destroy(gameObject);
    }
}
