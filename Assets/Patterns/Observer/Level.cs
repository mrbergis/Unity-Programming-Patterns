using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class Level : MonoBehaviour {

    [SerializeField] int pointsPerLevel = 200;
    [SerializeField] UnityEvent onLevelUp;
    int _experiencePoints = 0;

    public event Action OnLevelUpAction;
    public event Action OnExperienceChange;

    public void GainExperience(int points)
    {
        int level = GetLevel();
        _experiencePoints += points;
        if (OnExperienceChange != null)
        {
            OnExperienceChange();
        }
        if (GetLevel() > level)
        {
            onLevelUp.Invoke();
            if (OnLevelUpAction != null)
            {
                OnLevelUpAction();
            }
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