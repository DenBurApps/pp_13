using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SaveDataInstaller : MonoBehaviour
{
    [SerializeField] private bool _fromTheBeginning;
    [SerializeField] private MultiLanguage _multiLanguage;

    private void Start()
    {
        InstallBindings();
    }

    private void InstallBindings()
    {
        BindFileNames();
        BindRegistration();
        BindSettings();
        BindFavorites();
        BindBasket();
        BindCustomer();
        BindLocalization();
        _multiLanguage.Localize();
        LoadScene();
    }

    private void LoadScene()
    {
        if (PlayerPrefs.HasKey("Onboarding"))
        {
            SceneManager.LoadScene("MainMenu");
        }
        else
        {
            SceneManager.LoadScene("Onboarding");
        }
    }

    private void BindRegistration()
    {
        {
            var reg = SaveSystem.LoadData<RegistrationSaveData>();

#if UNITY_EDITOR
            if (_fromTheBeginning)
            {
                reg = null;
            }
#endif

            if (reg == null)
            {
                reg = new RegistrationSaveData("", false);
                SaveSystem.SaveData(reg);
            }

        }
    }

    private void BindSettings()
    {
        {
            var settings = SaveSystem.LoadData<SettingSaveData>();

#if UNITY_EDITOR
            if (_fromTheBeginning)
            {
                settings = null;
            }
#endif

            if (settings == null)
            {
                settings = new SettingSaveData(true, true);
                SaveSystem.SaveData(settings);
            }

        }
    }

    private void BindFavorites()
    {
        {
            var fav = SaveSystem.LoadData<FavoritesSaveData>();

#if UNITY_EDITOR
            if (_fromTheBeginning)
            {
                fav = null;
            }
#endif

            if (fav == null)
            {
                fav = new FavoritesSaveData(new List<int>(), new List<int>());
                SaveSystem.SaveData(fav);
            }

        }
    }

    private void BindBasket()
    {
        {
            var basket = SaveSystem.LoadData<BasketSaveData>();

#if UNITY_EDITOR
            if (_fromTheBeginning)
            {
                basket = null;
            }
#endif

            if (basket == null)
            {
                basket = new BasketSaveData(new List<int>(), new List<int>(), new List<int>());
                SaveSystem.SaveData(basket);
            }

        }
    }

    private void BindCustomer()
    {
        {
            var customer = SaveSystem.LoadData<CustomerSaveData>();

#if UNITY_EDITOR
            if (_fromTheBeginning)
            {
                customer = null;
            }
#endif

            if (customer == null)
            {
                customer = new CustomerSaveData("", "", "", "", "", "", "", "");
                SaveSystem.SaveData(customer);
            }

        }
    }

    private void BindLocalization()
    {
        {
            var local = SaveSystem.LoadData<LocalizationSaveData>();

#if UNITY_EDITOR
            if (_fromTheBeginning)
            {
                local = null;
            }
#endif

            if (local == null)
            {
                local = new LocalizationSaveData("English");
                SaveSystem.SaveData(local);
            }

        }
    }

    private void BindFileNames()
    {
        FileNamesContainer.Add(typeof(RegistrationSaveData), FileNames.RegData);
        FileNamesContainer.Add(typeof(SettingSaveData), FileNames.SettingsData);
        FileNamesContainer.Add(typeof(FavoritesSaveData), FileNames.FavoritesData);
        FileNamesContainer.Add(typeof(BasketSaveData), FileNames.BasketData);
        FileNamesContainer.Add(typeof(CustomerSaveData), FileNames.CustomerData);
        FileNamesContainer.Add(typeof(LocalizationSaveData), FileNames.LanguageData);
    }

}