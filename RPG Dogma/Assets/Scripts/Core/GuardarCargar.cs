using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GuardarCargar : MonoBehaviour
{
  [SerializeField] BattleSystem info;
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
    PlayerPrefs.SetInt("Nivel", info.lvl);
    //consigo guardar la variable, pero no cargarla luego, ya que solo modifico esa variable
    // y no el componente de nivel que maneja el juego.
  }
  public void Cargar ()
  {
    info.lvlcargado = PlayerPrefs.GetInt ("Nivel");
  }
}
