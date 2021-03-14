using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BattleHud : MonoBehaviour
{
    [SerializeField] Text nameText;
    [SerializeField] Text levelText;
    [SerializeField] HPBar hpBar;

    Enemigos _enemigo;

    public void SetData (Enemigos enemigo)
    {
        _enemigo = enemigo;
        nameText.text = enemigo.Base.Name;
        levelText.text = "Nivel " + enemigo.Level;
        hpBar.SetHP((float)enemigo.HP / enemigo.MaxHp);
    }

    public IEnumerator UpdateHP()
    {
        yield return hpBar.SetHPSmooth((float)_enemigo.HP / _enemigo.MaxHp);
    }
}
