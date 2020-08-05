using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class heartCtrl : MonoBehaviour
{
    private Vector3 StartingPos = Vector3.zero;

    public float Speed;
    public float Sensitivity;
    private Vector2 MovePos;

    public int MaxX = 2;
    public int MaxY = 2;
    public int MinX = -2;
    public int MinY = -2;

    private void Start()
    {
        SetHeart();
    }

    public void SetHeart()
    {
        transform.position = StartingPos;
        MovePos = StartingPos;
    }

    private void FixedUpdate()
    {
        float horizontal = Input.GetAxis("Horizontal") * Sensitivity;
        float vertical = Input.GetAxis("Vertical") * Sensitivity;

        MovePos.x += horizontal;
        MovePos.y += vertical;

        MovePos.x = Mathf.Clamp(MovePos.x, MinX, MaxX);
        MovePos.y = Mathf.Clamp(MovePos.y, MinY, MaxY);

        transform.position = Vector2.Lerp(transform.position, MovePos, Speed * Time.deltaTime);
    }



}