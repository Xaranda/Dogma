using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;


public class SaeraController : MonoBehaviour, ISavable
{
	public float speed;
	public LayerMask solidObjectsLayer;
	public LayerMask interactableLayer;
	public LayerMask EnemySpawner;

	public event Action OnEncountered;

	private bool isMoving;
	private Vector2 input;

	private Animator animator;
	public float [] position;


	private void Awake()
    {
		animator = GetComponent<Animator>();
		gameObject.tag = "Player";
	}

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

						if (Input.GetKeyDown(KeyCode.R))
						{
							Interact();
						}
    	}

			public object CaptureState ()
			{
				var saveData = new PlayerSaveData()
				{
					position = new float [] {transform.position.x,transform.position.y},
					//enemigos = GetComponent<Grupo>().enemigos.Select(p => p.GetSaveData()).ToList()
				};
				return saveData;
			}
			public void RestoreState (object state)
			{
				var saveData = (PlayerSaveData)state;
				var pos = saveData.position;
				transform.position = new Vector3(pos[0],pos[1]);

				//GetComponent<Grupo>().enemigos = saveData.enemigos.Select(s => new Enemigos(s)).ToList();
			}

		void Interact()
		{
			var faceDir = new Vector3(animator.GetFloat("LookX"), animator.GetFloat("LookY"));
			var interactPos = transform.position + faceDir;

			// Debug.DrawLine(transform.position, interactPos,Color.green, 0.5f);

			var collider = Physics2D.OverlapCircle(interactPos,0.3f, interactableLayer);
			if (collider != null)
			{
				collider.GetComponent<Interactable>()?.Interact();
			}
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
		if (Physics2D.OverlapCircle(targetPos , 0.3f , solidObjectsLayer | interactableLayer) != null)
        {
			return false;
        }
		return true;
    }

	private void CheckForEncounters()
    {
		if (Physics2D.OverlapCircle(transform.position,0.1f, EnemySpawner) != null)
		{
			if (UnityEngine.Random.Range (1,100)<=5)
            {
				animator.SetBool("isMoving", false);
				OnEncountered();
				Debug.Log("Enemigo encontrado");
            }
        }
    }
}

[Serializable]
public class PlayerSaveData
{
	public float [] position;
	//public List <PjSaveData> enemigos;
}
