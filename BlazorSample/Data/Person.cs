using System;

namespace BlazorSample.Data
{
    public class Person
    {
        public Int64 ID { get; set; }
        public string First_Name { get; set; }
        public string Last_Name { get; set; }
        public string Perm_Street { get; set; }
        public string Perm_City { get; set; }
        public string Perm_State { get; set; }
        public string Perm_Zip { get; set; }
        public string Perm_Country { get; set; }
        public string Street { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Zip { get; set; }
        public Double Phone { get; set; }
        public string Emergency_Phone { get; set; }
        public bool Unlisted { get; set; }
        public DateTime Date_Of_Birth { get; set; }
        public string Email_Address { get; set; }
        public bool Sex { get; set; }
        public string Citizenship { get; set; }
        public bool Survey { get; set; }
        public bool Smoker { get; set; }
        public bool Married { get; set; }
        public bool Children { get; set; }
        public bool Disability { get; set; }
        public bool Scholarship { get; set; }
        public string Comments { get; set; }
    }

}
