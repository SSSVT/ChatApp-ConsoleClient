using ESChatConsoleClient.Data;
using ESChatConsoleClient.Models.Server;
using ESChatConsoleClient.ViewItems;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ESChatConsoleClient.Views
{
    public class RegisterView : View
    {
        private InputViewItem _usernameInput = new InputViewItem("Username");
        private InputViewItem _passwordInput = new PasswordInputViewItem("Password");
        private InputViewItem _emailInput = new InputViewItem("Email");
        private InputViewItem _firstnameInput = new InputViewItem("First Name");
        private InputViewItem _middlenameInput = new InputViewItem("Middle Name");
        private InputViewItem _lastnameInput = new InputViewItem("Last Name");
        private InputViewItem _genderInput = new InputViewItem("Gender");
        private InputViewItem _birthdateInput = new InputViewItem("Birthdate");

        private ActionViewItem _registerAction;

        public RegisterView(ClientEngine clientEngine) : base(clientEngine)
        {
            this._registerAction = new ActionViewItem("Register", () => { this.Register(); });

            this.AddViewItems(
                            this._usernameInput,
                            this._passwordInput,
                            this._emailInput,
                            this._firstnameInput,
                            this._middlenameInput,
                            this._lastnameInput,
                            this._genderInput,
                            this._birthdateInput,
                            this._registerAction
                            );

            this.SelectViewItem(0);
        }

        public async void Register()
        {
            RegistrationModel registrationModel = new RegistrationModel()
            {
                Username = this._usernameInput.Value,
                Password = this._passwordInput.Value,
                Email = this._emailInput.Value,
                FirstName = this._firstnameInput.Value,
                MiddleName = this._middlenameInput.Value,
                LastName = this._lastnameInput.Value,
                Gender = this._genderInput.Value,
                Birthdate = GetDateTime(this._birthdateInput.Value)
            };

            try
            {
                DataContext.GetInstance().User = await this.ClientEngine.RegistrationController.RegisterAsync(registrationModel);
            }
            catch (Exception e)
            {

            }            
        }

        private DateTime GetDateTime(string dateTime)
        {
                string yearMatchPattern = "^([0-9]{4})";
                string monthMatchPattern = ".(0[1-9]|1[0-2]).";
                string dayMatchPattern = "(0[1-9]|[1-2][0-9]|3[0-1])$";

                int year = Convert.ToInt32(Regex.Match(dateTime, yearMatchPattern).Value);
                int month = Convert.ToInt32(Regex.Match(dateTime, monthMatchPattern).Value.Replace(".", ""));
                int day = Convert.ToInt32(Regex.Match(dateTime, dayMatchPattern).Value);

                return new DateTime(year, month, day);
        }


    }
}
