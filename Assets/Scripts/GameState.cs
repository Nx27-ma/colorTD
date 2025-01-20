using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class GameState : MonoBehaviour
{
    public List<GameObject> Enemies;
    float TrackLenght;

    void Start()
    {
        EnemyTrackData.EndReached += EndReached;
    }

    void Update()
    {
        
    }

    void EndReached(GameObject GameObject)
    {
        Enemies.Remove(GameObject);
    }
}
