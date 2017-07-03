using System;
using System.Collections.Generic;
using System.Text;

namespace Validator.Animals
{
    class Cat: Animal
    {
        public override bool Accept(ISecurity security)
        {
            return security.Validate(this);
        }
    }
}
