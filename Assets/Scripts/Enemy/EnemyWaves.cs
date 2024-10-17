using System;
using System.Collections.Generic;
using UnityEngine;

public class EnemyWaves : MonoBehaviour
{
    public static List<GameObject> Enemies = new List<GameObject>();
    public static Action<string, GameObject> EnemyDestroyed;
    public static Action StartWave;

    public int WaveNumber { get; private set; } = 0;

    int waveWeight;
    [SerializeField] GameObject pathPoint;
    GameObject generalEnemy;
    PlayerData playerData;
    void Start()
    {
        playerData = GameObject.Find("DEFAULT").GetComponent<PlayerData>();
        StartWave = generateWave;
        EnemyDestroyed += killEnemy;
        generalEnemy = Resources.Load("Prefabs/Enemies/NormalEnemy") as GameObject;
    }

    private void Update()
    {
        //check how far enemy is on list
    }

    void generateWave()
    {
        if (Enemies.Count == 0)
        {
            WaveNumber++;
            waveWeight = (int)(WaveNumber * 1.5f);

            for (int i = 0; i < waveWeight; i++)
            {
                Invoke("createEnemy", i);
            }
        }
    }
    
    void createEnemy()
    {
        GameObject newEnemy = Instantiate(generalEnemy, pathPoint.transform.position, new Quaternion(pathPoint.transform.eulerAngles.x, pathPoint.transform.eulerAngles.y, pathPoint.transform.eulerAngles.z, 1));
        Enemies.Add(newEnemy);
       
    }

    void fixOrder()
    {
        GameObject tempAscended;
        GameObject tempDescended;


       // TowerShoot.orderChanged(tempAscended, tempDescended);
    }

    void killEnemy(string causeOfDeath, GameObject target)
    {
        print("Whoops delegate called!");
        if(causeOfDeath == "Player")
        {
            //EconomyAction
        } 
        else if (causeOfDeath == "EndOfTrack")
        {
            playerData.DeminishLives();
        }

        Enemies.Remove(target);

        Destroy(target);
    }



}
