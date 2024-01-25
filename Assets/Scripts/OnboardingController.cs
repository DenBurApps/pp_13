using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class OnboardingController : MonoBehaviour
{
    [SerializeField] private List<GameObject> _steps;
    private int _currentStep = 0;

    public void GoToNextStep()
    {
        _currentStep++;
        if(_currentStep > _steps.Count - 1)
        {
            PlayerPrefs.SetInt("Onboarding", 1);
            SceneManager.LoadScene("MainMenu");
            return;
        }
        foreach (var item in _steps)
        {
            item.SetActive(false);
        }
        _steps[_currentStep].SetActive(true);
    }

    public void GoToPreviousStep()
    {
        _currentStep--;
        foreach (var item in _steps)
        {
            item.SetActive(false);
        }
        _steps[_currentStep].SetActive(true);
    }
}
