using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "ScriptableObject/EnemySO")]
public class EnemyManager : ScriptableObject
{
    private List<int> _points = new List<int>(); // We’ll have to finish if we have time
    public int countEnemyes = 3;
    public float walkSpeed = 5f;
}
