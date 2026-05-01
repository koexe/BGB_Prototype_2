using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;

public class InputReciver : MonoBehaviour
{
    Vector2 inputVec2;
    [SerializeField] Vector2 moveDirection;
    [SerializeField] float speed = 1f;
    [SerializeField] int currentCount;
    [SerializeField] RotateUI rotateUI;

    void OnMove(InputValue value)
    {
        inputVec2 = value.Get<Vector2>();

        if (inputVec2 != null)
        {
            moveDirection = new Vector2(inputVec2.x, inputVec2.y);
        }
    }

    void OnAttack(InputValue value)
    {
        if (value.isPressed)
        {
            Debug.Log("Attack");
            if (this.currentCount < 6)
            {
                if (this.rotateUI.RotateStep(true))
                    this.currentCount++;
            }
            else
            {
                this.currentCount = 0;
                this.rotateUI.RotateFull(1.0f);
            }
        }
    }

    private void FixedUpdate()
    {
        if (this.moveDirection != Vector2.zero)
        {
            Vector3 t_movement = this.moveDirection * Time.fixedDeltaTime * this.speed;
            this.transform.position += t_movement;
        }
    }
}

