using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;


public class EnemyData : MonoBehaviour
{
    public Color[] TowerColorList { get; } = { new Color(1, 0, 0), new Color(1, 1, 0), new Color(0, 0, 1) };
    public Color[] EnemyColorList { get; } = { new Color(0, 1, 0), new Color(1, 0.6f, 0), new Color(0.6f, 0, 1) };
    public TypeEnemy Type { get; private set; }
    public Color TargetColor { get; private set; } //the color of the enemy
    public Dictionary<string, float> HpValues = new Dictionary<string, float> { {"RedHp", 1f }, { "YellowHp", 1f }, { "BlueHp", 1f } };
    public float Speed { get; private set; }  //movementSpeed of the enemy
    SpriteRenderer border;
    SpriteRenderer inside;
    float healthRemoveAmount;
    Color currentColor;
    Color tempColor;
    float[] coloredHealth;
    private int colorDevide;
    private int TEMPORARYINTFORDEBUG = 10;
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
                Speed = 2f * TEMPORARYINTFORDEBUG;
                health = 2;
                break;
            case TypeEnemy.Big:
                Speed = 1f * TEMPORARYINTFORDEBUG;
                health = 4;
                break;
            case TypeEnemy.Small:
                Speed = 3f * TEMPORARYINTFORDEBUG;
                health = 1;
                break;
            default:
                Debug.LogError($"invalid enemyType:{Type}");
                break;
        }
        if (colorIndex == Colors.Green)
        {
            HpValues["YellowHp"] = health;
            HpValues["BlueHp"] = health;
        } else if (colorIndex == Colors.Purple)
        {
            HpValues["RedHp"] = health;
            HpValues["BlueHp"] = health;
        } else if (colorIndex == Colors.Orange)
        {
            HpValues["YellowHp"] = health;
            HpValues["RedHp"] = health;
        } else
        {
            print("NoColorIndexException");
        }
        colorDevide = 4;//helth;
        
    }
    private void Update()
    {
        if (HpValues["RedHp"] == 0 && HpValues["YellowHp"] == 0 && HpValues["BlueHp"] == 0)
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
        HpValues[HpValues.ElementAt((int)color).Key] -= 1;
        float flippedValue = colorDevide - HpValues[HpValues.ElementAt((int)color).Key];
        Color colorMultiplier = (TowerColorList[(int)color] / colorDevide) * flippedValue;
        currentColor = Color.Lerp(colorMultiplier, currentColor, 1);
        inside.color = currentColor;
    }
}
