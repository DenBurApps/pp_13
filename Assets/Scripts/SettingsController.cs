using Assets.SimpleLocalization.Scripts;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class SettingsController : MonoBehaviour
{
    [SerializeField] private GameObject _deliveryCanvas;
    [SerializeField] private GameObject _termsCanvas;
    [SerializeField] private GameObject _privacyCanvas;
    [SerializeField] private GameObject _languageCanvas;

    [SerializeField] private TMP_InputField _numberInput;
    [SerializeField] private TMP_InputField _firstNameInput;
    [SerializeField] private TMP_InputField _lastNameInput;
    [SerializeField] private TMP_InputField _adressInput;
    [SerializeField] private TMP_InputField _streetInput;
    [SerializeField] private TMP_InputField _cityInput;
    [SerializeField] private TMP_InputField _stateInput;
    [SerializeField] private TMP_InputField _zipInput;

    public void OnOpenTermsClick()
    {
        _termsCanvas.SetActive(true);
    }

    public void OnCloseTermsClick()
    {
        _termsCanvas.SetActive(false);
    }

    public void OnOpenPrivacyClick()
    {
        _privacyCanvas.SetActive(true);
    }

    public void OnClosePrivacyClick()
    {
        _privacyCanvas.SetActive(false);
    }

    public void OnOpenLanguageClick()
    {
        _languageCanvas.SetActive(true);
    }

    public void OnCloseLanguageClick()
    {
        _languageCanvas.SetActive(false);
    }

    public void SetLanguage(string key)
    {
        var local = SaveSystem.LoadData<LocalizationSaveData>();
        local.Language = key;
        LocalizationManager.Language = key;
    }

    public void OnOpenDeliveryClick()
    {
        var customer = SaveSystem.LoadData<CustomerSaveData>();
        _numberInput.text = customer.Number;
        _firstNameInput.text = customer.FirstName;
        _lastNameInput.text = customer.LastName;
        _adressInput.text = customer.Adress;
        _streetInput.text = customer.Street;
        _stateInput.text = customer.State;
        _zipInput.text = customer.Zip;
        _cityInput.text = customer.City;

        _deliveryCanvas.SetActive(true);

        _numberInput.onEndEdit.AddListener(DeliveryDataUpdated);
        _firstNameInput.onEndEdit.AddListener(DeliveryDataUpdated);
        _lastNameInput.onEndEdit.AddListener(DeliveryDataUpdated);
        _adressInput.onEndEdit.AddListener(DeliveryDataUpdated);
        _streetInput.onEndEdit.AddListener(DeliveryDataUpdated);
        _stateInput.onEndEdit.AddListener(DeliveryDataUpdated);
        _zipInput.onEndEdit.AddListener(DeliveryDataUpdated);
        _cityInput.onEndEdit.AddListener(DeliveryDataUpdated);
    }

    private void DeliveryDataUpdated(string text)
    {
        var customer = SaveSystem.LoadData<CustomerSaveData>();
        customer.Number = _numberInput.text;
        customer.FirstName = _firstNameInput.text;
        customer.LastName = _lastNameInput.text;
        customer.Adress = _adressInput.text;
        customer.Street = _streetInput.text;
        customer.State = _stateInput.text;
        customer.City = _cityInput.text;
        customer.Zip = _zipInput.text;
        SaveSystem.SaveData(customer);
    }

    public void OnCloseDeliveryClick()
    {
        _numberInput.onEndEdit.RemoveListener(DeliveryDataUpdated);
        _firstNameInput.onEndEdit.RemoveListener(DeliveryDataUpdated);
        _lastNameInput.onEndEdit.RemoveListener(DeliveryDataUpdated);
        _adressInput.onEndEdit.RemoveListener(DeliveryDataUpdated);
        _streetInput.onEndEdit.RemoveListener(DeliveryDataUpdated);
        _stateInput.onEndEdit.RemoveListener(DeliveryDataUpdated);
        _zipInput.onEndEdit.RemoveListener(DeliveryDataUpdated);
        _cityInput.onEndEdit.RemoveListener(DeliveryDataUpdated);
        _deliveryCanvas.SetActive(false);
    }
}
