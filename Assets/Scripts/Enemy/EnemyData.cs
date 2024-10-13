using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class EnemyData : MonoBehaviour
{
    public Color[] TowerColorList { get; } = { new Color(1, 0, 0), new Color(1, 1, 0), new Color(0, 0, 1) };
    public Color[] EnemyColorList { get; } = { new Color(0, 1, 0), new Color(1, 0.6f, 0), new Color(0.6f, 0, 1) };
    public TypeEnemy Type { get; private set; }
    public Color TargetColor { get; private set; } //the color of the enemy
    public float RedColorHealth { get; private set; }    //the amount of color needed to mix the right color
    public float YellowColorHealth { get; private set; }   //the amount of color needed to mix the right color
    public float BlueColorHealth { get; private set; }
    public float Speed { get; private set; }  //movementSpeed of the enemy
    SpriteRenderer border;
    SpriteRenderer inside;
    float healthRemoveAmount;
    Color currentColor;
    Color tempColor;
    float[] coloredHealth;

    public enum TypeEnemy
    {
        Normal, Big, Small
    }

    public enum Colors  //for the color array
    {
        Green, Purple, Orange
    }

    public enum TowerColors  //for the color array
    {
        Red, Yellow, Blue
    }

    private void Start()
    {
        coloredHealth = new float[3] {RedColorHealth, YellowColorHealth, BlueColorHealth};
        border = transform.Find("Border").GetComponent<SpriteRenderer>();
        inside = transform.Find("Inside").GetComponent<SpriteRenderer>();

        Colors colorIndex = (Colors)UnityEngine.Random.Range(0, EnemyColorList.Length);
        TargetColor = EnemyColorList[(int)colorIndex];

        inside.color = currentColor = Color.white;
        border.color = TargetColor;

        Type = (TypeEnemy)UnityEngine.Random.Range(0, 3);
        int health = 0;
        switch (Type)
        {
            
            case TypeEnemy.Normal:
                Speed = 0.25f;
                health = 2;
                break;
            case TypeEnemy.Big:
                Speed = 0.10f;
                health = 4;
                break;
            case TypeEnemy.Small:
                Speed = 0.5f;
                health = 1;
                break;
            default:
                Debug.LogError($"invalid enemyType:{Type}");
                break;
        }
        if (colorIndex == Colors.Green)
        {
            YellowColorHealth = health;
            BlueColorHealth = health;
        } else if (colorIndex == Colors.Purple)
        {
            RedColorHealth = health;
            BlueColorHealth = health;
        } else if (colorIndex == Colors.Orange)
        {
            YellowColorHealth = health;
            RedColorHealth = health;
        } else
        {
            print("NoColorIndexException");
        }
        RedColorHealth = -1;
        print($"{RedColorHealth}, {coloredHealth[0]} ");
    }
    private void Update()
    {
        if (RedColorHealth == 0 && YellowColorHealth == 0 && BlueColorHealth == 0)
        {
            EnemyWaves.EnemyDestroyed("Player", gameObject);
        }

        if (Input.GetMouseButtonDown(0))
        {
            print("pressed");
            TakeDamage(TowerColors.Yellow);  
        }

        if (Input.GetMouseButtonDown(1)) 
        {
            print("pressed");
            TakeDamage(TowerColors.Red);
        }
    }
    public void TakeDamage(TowerColors color)
    {

        tempColor = TowerColorList[(int)color];
        currentColor = Color.Lerp(currentColor, tempColor, 1);
        inside.color = currentColor;
    }
}
