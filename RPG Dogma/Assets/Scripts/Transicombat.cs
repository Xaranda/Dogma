using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Transicombat : MonoBehaviour
{
	public float count = 0.0f;
	private bool restart = false;
	string enemy;
	int valor =11;

	
	
    // Start is called before the first frame update
    void Start()
    {
        count=0.0f;
		restart=false;
    }

    // Update is called once per frame
    void Update()
    {
		if (restart == true) 
		{
			count += Time.deltaTime;
		if ( count < 5.0f){
				valor = Random.Range(0,10);
		}else if (count > 7.0f)
			{
					Debug.Log (valor);
					if (valor == 2)
					{
						SceneManager.LoadScene (2);
						enemy = "Perro1";
						Debug.Log (enemy);
					}else if (valor == 5){
						SceneManager.LoadScene (2);
						enemy = "Amazona1";
						Debug.Log (enemy);
					}else {
						count = 5.0f;
					}
				
			}
		}
    }
	void OnTriggerEnter2D(Collider2D col)
    {
        restart = true;
    }
	void OnTriggerExit2D(Collider2D col)
	{
		restart = false;
	}
}
