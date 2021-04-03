using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BattleHud : MonoBehaviour
{
    [SerializeField] Text nameText;
    [SerializeField] Text levelText;
    [SerializeField] HPBar hpBar;
    [SerializeField] GameObject expBar;

    Enemigos _enemigo;

    public void SetData (Enemigos enemigo)
    {
        _enemigo = enemigo;
        nameText.text = enemigo.Base.Name;
        SetLevel();
        hpBar.SetHP((float)enemigo.HP / enemigo.MaxHp);
        SetExp();
    }
    public void SetLevel()
    {
      levelText.text = "Nivel " + _enemigo.Level;
    }

    public void SetExp(bool reset=false)
    {
      if (expBar==null) return;

      if (reset)
      {
        expBar.transform.localScale = new Vector3 (0, 1, 1);
      }
      float normalizedExp=GetNormalizeExp();
      expBar.transform.localScale = new Vector3 (normalizedExp, 1, 1);
    }

    float GetNormalizeExp()
    {
      int currLevelExp = _enemigo.Base.GetExpForLevel(_enemigo.Level);
      int nextLevelExp = _enemigo.Base.GetExpForLevel(_enemigo.Level + 1);



      float normalizedExp = (float)(_enemigo.Exp - currLevelExp) / (nextLevelExp - currLevelExp);
      return Mathf.Clamp01(normalizedExp);

    }



    public void UpdateHP()
    {
        hpBar.SetHP((float)_enemigo.HP / _enemigo.MaxHp);
    }
}
