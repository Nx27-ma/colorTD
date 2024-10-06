using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class  EnemyData : MonoBehaviour
{
    EnemyStats stats;
    private void Start()
    {
        stats = new EnemyStats();
    }
}





public class EnemyStats
{
    public TypeEnemy Type { get; }
    public Color MainColor; //the color of the enemy
    public float Color1;    //the amount of color needed to mix the right color
    public float Color2;    //the amount of color needed to mix the right color
    public float Speed;     //movementspeed of the enemy
    public enum TypeEnemy
    {
        Normal, Big, Small
    }

    public enum Colors  //for the color array
    {
        Green, Purple, Orange
    }

    public Color[] ColorConversionList = { new Color(0, 255, 0), new Color(150, 0, 255), new Color(255, 150, 0) };

    public EnemyStats()
    {
        MainColor = ColorConversionList[UnityEngine.Random.Range(0, ColorConversionList.Length)];

        Type = (TypeEnemy)UnityEngine.Random.Range(0, 3);
        
        switch (Type)
        {
            case TypeEnemy.Normal:
                Speed = 0.025f;
                Color1 = 2;
                break;
            case TypeEnemy.Big:
                Speed = 0.010f;
                Color1 = 4;
                break;
            case TypeEnemy.Small:
                Speed = 0.05f;
                Color1 = 1;
                break;
            default:
                Debug.LogError($"invalid enemyType:{Type}");
                break;
        }
        Color2 = Color1;
    }
}
