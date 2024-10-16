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
    public List<int> HpValues = new List<int> {  0 , 0 , 0 };
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
            HpValues[(int)TowerColors.Yellow] = health;
            HpValues[(int)TowerColors.Blue] = health;
        } else if (colorIndex == Colors.Purple)
        {
            HpValues[(int)TowerColors.Red] = health;
            HpValues[(int)TowerColors.Blue] = health;
        } else if (colorIndex == Colors.Orange)
        {
            HpValues[(int)TowerColors.Yellow] = health;
            HpValues[(int)TowerColors.Red] = health;
        } else
        {
            print("NoColorIndexException");
        }
        colorDevide = 4;//helth;
        
    }
    private void Update()
    {
        if (HpValues[(int)TowerColors.Red] == 0 && HpValues[(int)TowerColors.Yellow] == 0 && HpValues[(int)TowerColors.Blue] == 0)
        {
            EnemyWaves.EnemyDestroyed("Player", gameObject);
        }

        //if (Input.GetMouseButtonDown(0))
        //{
        //    print("pressed");
        //    TakeDamage(TowerColors.Yellow);  
        //}

        //if (Input.GetMouseButtonDown(1)) 
        //{
        //    print("pressed");
        //    TakeDamage(TowerColors.Red);
        //}
    }
    public void TakeDamage(TowerColors color)
    { 
        HpValues[(int)color] -= 1;
        print(HpValues[(int)color]);
        //HpValues[HpValues.ElementAt((int)color).Key] -= 1;
        //float flippedValue = colorDevide - HpValues[HpValues.ElementAt((int)color).Key];
        //Color colorMultiplier = (TowerColorList[(int)color] / colorDevide) * flippedValue;
        //currentColor = Color.Lerp(colorMultiplier, currentColor, 1);
        //inside.color = currentColor;
    }
}
