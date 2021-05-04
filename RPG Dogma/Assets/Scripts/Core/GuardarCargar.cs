using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GuardarCargar : MonoBehaviour
{
  Enemigos _enemigo;
  public bool Cargado;
  public bool Guardado;
  [SerializeField] Player PlayerUnit;


  void Update ()
  {
    if (Input.GetKeyDown(KeyCode.G))
    {
      Guardar();
    }else if (Input.GetKeyDown(KeyCode.L)) {
      Cargar();
    }
  }

  public void Guardar()
  {
    Guardado = true;
    PlayerPrefs.SetInt("Nivel", PlayerUnit.saera.Level);
    //consigo guardar la variable, pero no cargarla luego, ya que solo modifico esa variable
    // y no el componente de nivel que maneja el juego.
  }
  public void Cargar ()
  {
    Cargado = true;
    PlayerUnit.saera.Level = PlayerPrefs.GetInt ("Nivel");
  }
}
