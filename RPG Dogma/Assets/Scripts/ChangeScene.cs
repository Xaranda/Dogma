using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour
{
    // Start is called before the first frame update
	public int numescena= 0;
    public void loadNextScene()
    {
        SceneManager.LoadScene (1);
    }
}
