namespace Reflections
{
    using System;

    public class ClassForReflection
    {
        public string username = "securityGod82";
        private string password = "mySuperSecretPassw0rd";

        public string Password
        {
            get => this.password;
            set => this.password = value;
        }

        private int Id { get; set; }

        public double BankAccountBalance { get; private set; }

        public void DownloadAllBankAccountsInTheWorld(string username,string password,double money,DateTime time)
        {
        }
    }
}
