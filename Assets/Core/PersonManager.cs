using System.Collections;
using System.Collections.Generic;
using SimpleInputNamespace;
using UnityEngine;

public class PersonManager : MonoBehaviour
{
    [SerializeField] private float moveSpeed;

    [SerializeField] private Joystick joystick;
    [SerializeField] private PersonAnimation personAnimation;
    

    private void Awake() => personAnimation = GetComponent<PersonAnimation>();

    private void Update() => CharacterJoystick();

    private void CharacterJoystick()
    {
        var inputHorizontal = SimpleInput.GetAxis("Horizontal");
        transform.position += new Vector3(inputHorizontal, 0, 0) * Time.deltaTime * moveSpeed;

        var rotationVector = transform.eulerAngles;
        rotationVector.y = joystick.m_value.x < 0 ? -180 : 0;
        transform.eulerAngles = rotationVector;

        if(joystick.m_value.x != 0 && joystick.m_value.x != 0)
            personAnimation.SetCharacterState("Walking");
        else
            personAnimation.SetCharacterState("Idle");
    }
}
