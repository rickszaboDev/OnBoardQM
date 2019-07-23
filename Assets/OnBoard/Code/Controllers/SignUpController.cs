using System;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

using OnBoard.Utils;
using OnBoard.Services;

using OnBoard.Services.Model;

public class SignUpController : MonoBehaviour
{
    public string regexKey;

    public TMP_InputField usernameField;
    public TMP_InputField emailField;
    public TMP_InputField passwordField;
    public TMP_InputField confirmPasswordField;
    public TMP_InputField fullnameField;
    public TMP_InputField birthdayField;

    public string userName;
    public string email;
    public string password;
    public string confirmPassword;
    public string fullName;
    public DateTime birthday;

    PlayerCreateInModel PlayerCreateInModel;

    private void Update()
    {

        this.userName = this.usernameField.text;
        this.email = this.emailField.text;
        this.password = this.passwordField.text;
        this.confirmPassword = this.confirmPasswordField.text;
        this.fullName = this.fullnameField.text;
        //this.userName = this.usernameField.text;
    }

   void SubmitData()
   {
        PlayerCreateInModel = new PlayerCreateInModel
        {
            username = this.userName,
            password = this.password,
            full_name = this.fullName,
            gender = "NI",
            email = this.email,
            mobile_ddd_number = "11",
            mobile_number = "0",
            zipcode = "0",
            address = "Bairro sem nome, Rua nulo",
            address_number = "123",
            state = "SP",
            city = "Santana de Parnaiba"
        };

        var data = APIService.SetRawData(PlayerCreateInModel);
        APIService.RequestCreateUser(data);
   }

   public void CheckValidations()
    {
        bool validate;

        validate = Validation.ValidateEmail(this.email, this.regexKey) &&
        Validation.ValidatePasswordLength(this.password) &&
        Validation.ValidatePasswordConfirmation(this.password, this.confirmPassword) &&
        Validation.ValidateAgeToSignIn(birthday);

        if (validate) APIService.RequestUsernameExists(this.userName, this.email, (res) =>
        {
            SubmitData();
        });
    }
}
