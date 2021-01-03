using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiEmails.Domain.Utils
{
    public class ErrorMessages
    {
        public const string NameNecessary = "<li>É necessário um nome</li>";
        public const string EmailNecessary = "<li>É necesário um E-mail</li>";
        public const string PhoneNecessary = "<li>É necesário um telefone</li>";
        public const string BodyNecessary = "<li>É necesário uma mensagem</li>";
    }
}
