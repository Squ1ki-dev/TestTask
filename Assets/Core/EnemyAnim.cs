using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAnim : MonoBehaviour
{
    [SerializeField] private EnemyMovement enemyMovement;
    [SerializeField] private PersonAnimation personAnimation;

    private void Awake() => personAnimation = GetComponent<PersonAnimation>();

    private void Update() => EnemyController();

    private void EnemyController()
    {
        if(enemyMovement.isMove == true)
            personAnimation.SetCharacterState("Walking");
        else
            personAnimation.SetCharacterState("Idle");
    }
}
