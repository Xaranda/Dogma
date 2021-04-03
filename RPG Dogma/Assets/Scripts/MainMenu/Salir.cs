using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Salir : MonoBehaviour
{
  public void QuitGame ()
  {
    Debug.Log ("Quit");
    Application.Quit();
  }
}
