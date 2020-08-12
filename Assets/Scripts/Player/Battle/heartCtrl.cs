using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class heartCtrl : MonoBehaviour
{
    private Vector3 StartingPos = Vector3.zero;

    private Vector2 MovePos;

    public float moveSpeed = 3f;
    public Rigidbody2D rb;
    Vector2 movement;
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

    void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        Vector3 pos = transform.position;
        pos.x = Mathf.Clamp(pos.x, MinX, MaxX);
        pos.y = Mathf.Clamp(pos.y, MinY, MaxY);
        transform.position = pos;
    }

    private void FixedUpdate()
    {
        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
    }



}