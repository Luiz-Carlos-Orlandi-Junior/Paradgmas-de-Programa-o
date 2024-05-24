using System;

namespace Trab_TF.Services.Exceptions
{
    public class NotFoundException : Exception
    {
        public NotFoundException(String message) : base(message) { }
    }
}