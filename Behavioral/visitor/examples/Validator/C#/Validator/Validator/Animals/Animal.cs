using System;
using System.Collections.Generic;
using System.Text;

namespace Validator.Animals
{
    abstract class Animal
    {
        public string Name { get; set; }

        public abstract bool Accept(ISecurity security);
    }
}
