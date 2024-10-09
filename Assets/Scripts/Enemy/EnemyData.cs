using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class EnemyData : MonoBehaviour
{
    public Color[] ColorConversionList { get; } = { new Color(0, 255, 0), new Color(150, 0, 255), new Color(255, 150, 0) };
    public TypeEnemy Type { get; private set; }
    public Color MainColor { get; private set; } //the color of the enemy
    public float Color1 { get; private set; }    //the amount of color needed to mix the right color
    public float Color2 { get; private set; }   //the amount of color needed to mix the right color
    public float Speed   { get; private set; }  //movementSpeed of the enemy

    public enum TypeEnemy
    {
        Normal, Big, Small
    }

    public enum Colors  //for the color array
    {
        Green, Purple, Orange
    }

    private void Start()
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
    private void Update()
    {
        if (Color1 == 0 && Color2 == 0)
        {
            EnemyWaves.EnemyDestroyed("Player", gameObject);
        }
    }
}
