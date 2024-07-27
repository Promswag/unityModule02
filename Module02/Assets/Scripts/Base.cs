using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using UnityEngine.TextCore.Text;

public class Base : MonoBehaviour
{
    [SerializeField] private int healthPoints = 5;

    public void TakeDamage(int damage)
    {
        healthPoints -= damage;

        if (healthPoints > 0)
        {
            StringBuilder text = new StringBuilder();
            text.Append(healthPoints);
            text.Append(" HP remaining!");
            Debug.Log(text);
        }
        else
        {
            GameManager.instance.GameOver();
        }
    }
}
