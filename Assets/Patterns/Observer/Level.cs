using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class Level : MonoBehaviour {

    [SerializeField] int pointsPerLevel = 200;
    [SerializeField] private UnityEvent onLevelUp;
    int _experiencePoints = 0;


    //public delegate void CallbackType();
    //public event CallbackType OnLevelUpAction;
    public event Action OnLevelUpAction;
    
    IEnumerator Start()
    {
        while (true)
        {
            yield return new WaitForSeconds(.2f);
            GainExperience(10);
        }
    }

    public void GainExperience(int points)
    {
        int level = GetLevel();
        _experiencePoints += points;
        if (GetLevel() > level)
        {
            onLevelUp.Invoke();
            OnLevelUpAction?.Invoke();
        }
    }

    public int GetExperience()
    {
        return _experiencePoints;
    }

    public int GetLevel()
    {
        return _experiencePoints / pointsPerLevel;
    }
}