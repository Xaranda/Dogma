﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class SaeraController : MonoBehaviour
{
	public float speed;
	public LayerMask solidObjectsLayer;
	public LayerMask EnemySpawner;

	public event Action OnEncountered;

	private bool isMoving;
	private Vector2 input;
	public static int SaeraMaxHealth = 10;
	public static int SaeraHealth=10;


	private Animator animator;
    // Start is called before the first frame update

	private void Awake()
    {
		animator = GetComponent<Animator>();
	}
    void Start()
    {

    }

    // Update is called once per frame
    public void HandleUpdate()
    {
		if (!isMoving)
		{
			input.x = Input.GetAxisRaw("Horizontal");
			input.y = Input.GetAxisRaw("Vertical");

			//sin movimiento diagonal
			if (input.x != 0) input.y = 0;

			if  (input != Vector2.zero)
            {
				animator.SetFloat("LookX", input.x);
				animator.SetFloat("LookY", input.y);

				var targetPos = transform.position;
				targetPos.x += input.x;
				targetPos.y += input.y;

				if (IsWalkable(targetPos))
					StartCoroutine(Move(targetPos));
            }
		}
		animator.SetBool("isMoving", isMoving);
    }

	IEnumerator Move (Vector3 targetPos)
    {
		isMoving = true;
		while ((targetPos - transform.position).sqrMagnitude > Mathf.Epsilon)
		{
			transform.position = Vector3.MoveTowards(transform.position, targetPos, speed * Time.deltaTime);
			yield return null;
        }
		transform.position = targetPos;
		isMoving = false;

		CheckForEncounters();
    }

	private bool IsWalkable(Vector3 targetPos)
    {
		if (Physics2D.OverlapCircle(targetPos , 0.3f , solidObjectsLayer) != null)
        {
			return false;
        }
		return true;
    }

	private void CheckForEncounters()
    {
		if (Physics2D.OverlapCircle(transform.position,0.5f, EnemySpawner) != null)
		{
			if (UnityEngine.Random.Range (1,100)<=10)
            {
				animator.SetBool("isMoving", false);
				OnEncountered();
				Debug.Log("Enemigo encontrado");
            }
        }
    }
}
