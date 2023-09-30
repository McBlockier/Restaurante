using System;

namespace Palacio_el_restaurante.src.Conection
{
    public class Persona
    {
        private String name, lastNameP, lastNameM, primaryStreet,
            secondaryStreet, Settlement_type, password, idUser, phoneNumber;

        public string Name
        {
            get => name;
            set => name = value;
        }
        public string LastNameP { get => lastNameP; set => lastNameP = value; }
        public string LastNameM { get => lastNameM; set => lastNameM = value; }
        public string PrimaryStreet { get => primaryStreet; set => primaryStreet = value; }
        public string SecondaryStreet { get => secondaryStreet; set => secondaryStreet = value; }
        public string Settlement_type1 { get => Settlement_type; set => Settlement_type = value; }
        public string Password { get => password; set => password = value; }
        public string PhoneNumber { get => phoneNumber; set => phoneNumber = value; }
        public string IdUser { get => idUser; set => idUser = value; }

    }
}
