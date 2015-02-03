using System;

namespace MultimediaShop.Exceptions
{
    class InsufficientSuppliesException : SystemException
    {
        public override string Message
        {
            get
            {
                return "Insufficient quantity of the desired product";
            }
        }
    }
}
