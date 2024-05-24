using System;

namespace Trab_TF.Services.Exceptions
{
    public class BadRequestException : Exception
    {
        public BadRequestException(String message) : base(message) { }

    }
}