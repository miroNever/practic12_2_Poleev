using System.Text.RegularExpressions;
using Practice12_Zadanie4_Poleev;
namespace Practice12_Zadanie4_Poleev
{
    public partial class Form1 : Form
    {
        private List<Customer> customers;
        public Form1()
        {
            InitializeComponent();
            customers = new List<Customer>()
            {
                new Customer("Иванов", "Иван", "Иванович", "ул. Ленина 10", "1234567890123456", "123456789"),
                new Customer("Петров", "Петр", "Петрович", "ул. Первомайская 5", "2345678901234567", "234567890"),
                new Customer("Андреев", "Андрей", "Андреевич", "ул. Малышева 45", "3456789012345678", "345678901")
            };

            UpdateListBox();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void UpdateListBox()
        {
            listBox1.Items.Clear();
            foreach (var customer in customers)
            {
                listBox1.Items.Add(customer.GetInfo());
            }
        }


        private void button1_Click(object sender, EventArgs e)
        {
            listBox2.Items.Clear();
            customers.Sort((a, b) => string.Compare(a.Surname, b.Surname));
            foreach (var customer in customers)
            {
                listBox2.Items.Add(customer.GetInfo());
            }
        }



        private void button3_Click(object sender, EventArgs e)
        {
           
            var fromCardNumber = textBox7.Text;
            var toCardNumber = textBox8.Text;
            if (fromCardNumber.Length != 16 || toCardNumber.Length != 16)
            {
                MessageBox.Show("Некорректный номер кредитной карты", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            var result = customers.FindAll(c => string.Compare(c.CreditCardNumber, fromCardNumber) >= 0
                                              && string.Compare(c.CreditCardNumber, toCardNumber) <= 0);
            listBox3.Items.Clear();
            if (result.Count == 0)
            {
                listBox3.Items.Add("Нет покупателей в заданном диапазоне");
            }
            else
            {
                foreach (var customer in result)
                {
                    listBox3.Items.Add(customer.Surname + " - " + customer.CreditCardNumber);
                }
            }
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            string surname = textBox1.Text.Trim();
            string name = textBox2.Text.Trim();
            string patronymic = textBox3.Text.Trim();
            string address = textBox4.Text.Trim();
            string creditCardNumber = textBox5.Text.Trim();
            string bankAccountNumber = textBox6.Text.Trim();
            string error = "";
            if (string.IsNullOrEmpty(surname) || string.IsNullOrEmpty(name) || string.IsNullOrEmpty(patronymic)
                || string.IsNullOrEmpty(address) || string.IsNullOrEmpty(creditCardNumber) || string.IsNullOrEmpty(bankAccountNumber))
            {
                MessageBox.Show("Заполните все поля", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            foreach (char c in name)
            {
                if (!Char.IsLetter(c))
                {
                    error += "Неправильный ввод имени";
                    break;
                }
            }
            foreach (char c in surname)
            {
                if (!Char.IsLetter(c))
                {
                    error += "\nНеправильный ввод фамилии";
                    break;
                }
            }
            foreach (char c in patronymic)
            {
                if (!Char.IsLetter(c))
                {
                    error += "\nНеправильный ввод отчества";
                    break;
                }
            }
            if (creditCardNumber.Length != 16 )
            {
                error += "\nНекорректный номер кредитной карты";
            }
            if (bankAccountNumber.Length != 9)
            {
                error += "\nНекорректный номер счета банка";
            }

            if(error != "")
            {
                MessageBox.Show(error, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else
            {
                listBox1.Items.Add(new Customer(surname, name, patronymic, address, creditCardNumber, bankAccountNumber).GetInfo());
                textBox1.Clear();
                textBox2.Clear();
                textBox3.Clear();
                textBox4.Clear();
                textBox5.Clear();
                textBox6.Clear();
            }
        }
    }
}