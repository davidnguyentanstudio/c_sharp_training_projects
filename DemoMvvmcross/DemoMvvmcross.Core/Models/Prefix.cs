using System;
namespace DemoMvvmcross.Core.Models
{
    public class Prefix: IPrefix
    {
        string _text;
        public string Text
        {
            get => _text;
            set => _text = value;
        }

        public Prefix(string text)
        {
            this._text = text;
        }


    }
}
