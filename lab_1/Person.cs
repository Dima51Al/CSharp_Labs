using System;

namespace Lab1
{
    public class Person
    {
        private string Name = "";
        private string SecondName = "";
        private string FatherName = "";

        public Person(string name, string secondName, string fatherName)
        {
            Name = name;
            SecondName = secondName;
            FatherName = fatherName;
        }

        public string GetName() => Name;
        public string GetSecondName() => SecondName;
        public string GetFatherName() => FatherName;

        public void SetName(string name) => Name = name;
        public void SetSecondName(string secondName) => SecondName = secondName;
        public void SetFatherName(string fatherName) => FatherName = fatherName;
    }
}
