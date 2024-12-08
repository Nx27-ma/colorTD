using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Enemy;
public class GameState : MonoBehaviour
{
    public List<GameObject> Enemies;
    float TrackLenght;

    void Start()
    {
        EnemyState.EndReached += EndReached;
    }

    void Update()
    {
        
    }

    void EndReached(GameObject GameObject)
    {
        Enemies.Remove(GameObject);
    }
}
