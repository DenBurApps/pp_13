using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CashoutShower : MonoBehaviour
{
    [SerializeField] private ItemsContainer _itemsContainer;
    [SerializeField] private TMP_Text _totalPrise;
    [SerializeField] private TMP_InputField _numberInput;
    [SerializeField] private TMP_InputField _firstNameInput;
    [SerializeField] private TMP_InputField _lastNameInput;
    [SerializeField] private TMP_InputField _adressInput;
    [SerializeField] private TMP_InputField _streetInput;
    [SerializeField] private TMP_InputField _cityInput;
    [SerializeField] private TMP_InputField _stateInput;
    [SerializeField] private TMP_InputField _zipInput;
    [SerializeField] private Toggle _saveAdressToggle;

    private void OnEnable()
    {
        _numberInput.onEndEdit.AddListener(OnNumberEndEdit);
        UpdateTotalPrise();
        SetSavedCustumerInfo();
    }

    private void OnDisable()
    {
        _numberInput.onEndEdit.RemoveListener(OnNumberEndEdit);
    }

    public void ShowCashout()
    {
        gameObject.SetActive(true);
    }

    public void HideCashout()
    {
        gameObject.SetActive(false);
    }

    private void UpdateTotalPrise()
    {
        int total = 0;
        var basket = SaveSystem.LoadData<BasketSaveData>();
        for (int i = 0; i < basket.ItemsCode.Count; i++)
        {
            ClothesSO clothes = _itemsContainer.GetClothesSO(basket.ItemsCode[i]);
            total += basket.ItemsCount[i] * clothes.Cost;
        }
        _totalPrise.text = total + "$";
    }

    private void SetSavedCustumerInfo()
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
    }

    private void OnNumberEndEdit(string number)
    {
        string cleanInput = System.Text.RegularExpressions.Regex.Replace(number, "[^0-9]", "");

        if (cleanInput == "")
        {
            _numberInput.text = "";
            return;
        }
        // Если строка не начинается с "+", добавьте его
        if (!cleanInput.StartsWith("+"))
        {
            cleanInput = "+" + cleanInput;
        }

        _numberInput.text = cleanInput;
    }

    public void OnCashoutButtonClick()
    {
        if (_saveAdressToggle.isOn)
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
        BasketController.ClearBasket();       
        HideCashout();
    }

}
