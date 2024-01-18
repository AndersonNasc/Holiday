using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Notifications
{
    public class Validation
    {
        public Validation()
        {
            Notifications = new List<Validation>();
        }

        [NotMapped]
        public string NameProperties { get; set; }
        [NotMapped]
        public string Message { get; set; }
        [NotMapped]
        public List<Validation> Notifications { get; set; }

        public bool ValidationPropertiesString(string value,string nameProperties)
        {
            if (string.IsNullOrWhiteSpace(value) || string.IsNullOrWhiteSpace(nameProperties))
            {
                Notifications.Add(new Validation { Message = "Campo Obrigatório", NameProperties = nameProperties });

                return false;
            }
            return true;
        }

        public bool ValidationPropertiesCPF(string cpf)
        {
            int[] multiplier1 = { 10, 9, 8, 7, 6, 5, 4, 3, 2 };
            int[] multiplier2 = { 11, 10, 9, 8, 7, 6, 5, 4, 3, 2 };

            cpf = cpf.Trim().Replace(".", "").Replace("-", "");

            if (cpf.Length != 11)
            {
                return false;
            }

            string tempCpf = cpf.Substring(0, 9);
            int sum = 0;

            for (int i = 0; i < 9; i++)
            {
                sum += int.Parse(tempCpf[i].ToString()) * multiplier1[i];
            }

            int remainder = sum % 11;

            if (remainder < 2)
            {
                remainder = 0;
            }
            else
            {
                remainder = 11 - remainder;
            }

            string digit = remainder.ToString();
            tempCpf += digit;
            sum = 0;

            for (int i = 0; i < 10; i++)
            {
                sum += int.Parse(tempCpf[i].ToString()) * multiplier2[i];
            }

            remainder = sum % 11;

            if (remainder < 2)
            {
                remainder = 0;
            }
            else
            {
                remainder = 11 - remainder;
            }

            digit += remainder.ToString();
            return cpf.EndsWith(digit);
        }
    }
}
