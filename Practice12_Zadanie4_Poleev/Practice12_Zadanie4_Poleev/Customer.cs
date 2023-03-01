using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice12_Zadanie4_Poleev
{
    internal class Customer
    {
        private string surname;
        private string name;
        private string patronymic;
        private string address;
        private string creditCardNumber;
        private string bankAccountNumber;

        public Customer(string surname, string name, string patronymic, string address, string creditCardNumber, string bankAccountNumber)
        {
            this.surname = surname;
            this.name = name;
            this.patronymic = patronymic;
            this.address = address;
            this.creditCardNumber = creditCardNumber;
            this.bankAccountNumber = bankAccountNumber;
        }

        public string Surname
        {
            get { return surname; }
            set { surname = value; }
        }

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public string Patronymic
        {
            get { return patronymic; }
            set { patronymic = value; }
        }

        public string Address
        {
            get { return address; }
            set { address = value; }
        }

        public string CreditCardNumber
        {
            get { return creditCardNumber; }
            set { creditCardNumber = value; }
        }

        public string BankAccountNumber
        {
            get { return bankAccountNumber; }
            set { bankAccountNumber = value; }
        }

        public string GetInfo()
        {
            return @$"{surname} {name} {patronymic} {address},  {creditCardNumber},  {bankAccountNumber}";
        }
    }
}
