using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_MTP_3
{
    class Contact
    {
        private string name = null;
        private string address = null;
        private string phoneNumber = null;
        private string categorie = "others";

        public Contact (string name, string address, string phoneNumber, string categorie)
        {
            this.name = name;
            this.address = address;
            this.phoneNumber = phoneNumber;
            this.categorie = categorie;
        }
        /**************Setter***************/
        public void setName(string name)
        {
            this.name = name;
        }
        public void setAddress(string address)
        {
            this.address = address;
        }
        public void setPhoneNumber(string phoneNumber)
        {
            this.phoneNumber = phoneNumber;
        }
        public void setCategorie(string categorie)
        {
            this.categorie = categorie;
        }
        /**************Getter***************/

        public string getName()
        {
            return this.name;
        }
        public string getAddress()
        {
            return this.address;
        }
        public string getPhoneNumber()
        {
            return this.phoneNumber;
        }
        public string getCategorie()
        {
            return this.categorie;
        }
    }
}
