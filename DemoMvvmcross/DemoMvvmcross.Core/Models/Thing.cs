using System;
namespace DemoMvvmcross.Core.Models
{
    public class Thing: IThing
    {
        string _name;
        public string Name
        {
            get => _name;
            set => _name = value;
        }

        public Thing(string name)
        {
            this._name = name;
        }


    }
}
