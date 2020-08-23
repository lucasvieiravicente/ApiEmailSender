using Newtonsoft.Json;
using System;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace ApiEmails.Domain
{       
    public class EmailViewModel
    {        
        public string Name { get; set; }      
        public string Email { get; set; }        
        public string PhoneNumber { get; set; }        
        public string Subject { get; set; }        
        public string Body { get; set; }

        public Tuple<bool, string> IsValid()
        {
            string messageError = "";

            if (string.IsNullOrEmpty(Name)) messageError += "<li>É necessário um nome</li>";

            if (string.IsNullOrEmpty(Email)) messageError += "<li>É necesário um E-mail</li>";

            if (string.IsNullOrEmpty(PhoneNumber)) messageError += "<li>É necesário um telefone</li>";

            if (string.IsNullOrEmpty(Body)) messageError += "<li>É necesário uma mensagem</li>";

            if(!string.IsNullOrEmpty(messageError)) return new Tuple<bool, string>(false, messageError);

            return new Tuple<bool, string>(true, "Conteúdo ok");
        }
    }
}
