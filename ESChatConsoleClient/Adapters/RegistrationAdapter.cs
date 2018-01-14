using ESChatConsoleClient.Controllers;
using ESChatConsoleClient.Models.Server;
using System;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ESChatConsoleClient.Adapters
{
    public class RegistrationAdapter : Adapter
    {
        protected RegistrationController RegistrationController { get; set; }

        public RegistrationAdapter(RegistrationController controller)
        {
            this.RegistrationController = controller;
        }

        public override async Task Execute(string key, string input)
        {
            input = input.Replace($"{key} ", "");
            string firstNameMatchPattern = "^((-F|--firstname) ([A-Z][a-z]{2,}))";
            string middleNameMatchPattern = "( (-M|--middlename) ([A-Z][a-z]{2,}))?";
            string lastNameMatchPattern = "((-L|--lastname) ([A-Z][a-z]{2,}))";
            string birthdateMatchPattern = "((-B|--birthdate) ([0-9]{4})-(0[1-9]|1[0-2])-(0[1-9]|[1-2][0-9]|3[0-1]))";
            string genderMatchPattern = "((-G|--gender) [M|F])";
            string emailMatchPattern = @"((-E|--email) ([a-z0-9]+(\.?[a-z0-9]+)*@([a-z0-9]+\.)+[a-z0-9]{2,}))";
            string userMatchPattern = "((-U|--username) ([a-zA-Z0-9]{4,64}))";
            string passMatchPattern = "((-P|--password) (.+))$";

            if (Regex.IsMatch(input, $"{firstNameMatchPattern}{middleNameMatchPattern} {lastNameMatchPattern} {birthdateMatchPattern} {genderMatchPattern} {emailMatchPattern} {userMatchPattern} {passMatchPattern}"))
            {
                Match firstNameMatch = Regex.Match(input, firstNameMatchPattern);
                Match middleNameMatch = Regex.Match(input, middleNameMatchPattern);
                Match lastNameMatch = Regex.Match(input, lastNameMatchPattern);
                Match birthdateMatch = Regex.Match(input, birthdateMatchPattern);
                Match genderMatch = Regex.Match(input, genderMatchPattern);
                Match emailMatch = Regex.Match(input, emailMatchPattern);
                Match userMatch = Regex.Match(input, userMatchPattern);
                Match passMatch = Regex.Match(input, passMatchPattern);

                string mdname = middleNameMatch.Value.Replace("-M ", "").Replace("--middlename ", "");

                RegistrationModel registration = new RegistrationModel()
                {
                    FirstName = firstNameMatch.Value.Replace("-F ", "").Replace("--firstname ", ""),
                    MiddleName = (!string.IsNullOrWhiteSpace(mdname)) ? mdname : null,
                    LastName = lastNameMatch.Value.Replace("-L ", "").Replace("--lastname ", ""),
                    Birthdate = this.GetDateTime(birthdateMatch.Value.Replace("-B ", "").Replace("--birthdate ", "")),
                    Gender = genderMatch.Value.Replace("-G ", "").Replace("--gender ", ""),
                    Email = emailMatch.Value.Replace("-E ", "").Replace("--email ", ""),
                    Username = userMatch.Value.Replace("-U ", "").Replace("--username ", ""),
                    Password = passMatch.Value.Replace("-P ", "").Replace("--password ", "")
                };

                User user = await this.RegistrationController.RegisterAsync(registration);

                throw new NotImplementedException();
            }
            else
            {
                throw new ArgumentException($"Registration: { _InvalidParams }.");
            }
        }

        protected DateTime GetDateTime(string datetime)
        {
            string yearMatchPattern = "^([0-9]{4})";
            string monthMatchPattern = "-(0[1-9]|1[0-2])-";
            string dayMatchPattern = "(0[1-9]|[1-2][0-9]|3[0-1])$";

            int year = Convert.ToInt32(Regex.Match(datetime, yearMatchPattern).Value);
            int month = Convert.ToInt32(Regex.Match(datetime, monthMatchPattern).Value.Replace("-", ""));
            int day = Convert.ToInt32(Regex.Match(datetime, dayMatchPattern).Value);

            return new DateTime(year, month, day);
        }
    }
}
