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
            if (string.IsNullOrEmpty(Name)) return new Tuple<bool, string>(false, "É necessário um Nome");

            if (string.IsNullOrEmpty(Email)) return new Tuple<bool, string>(false, "É necessário um Email");

            if (string.IsNullOrEmpty(PhoneNumber)) return new Tuple<bool, string>(false, "É necessário um Telefone");

            if (string.IsNullOrEmpty(Body)) return new Tuple<bool, string>(false, "É necessário uma mensagem");

            return new Tuple<bool, string>(true, "Conteúdo ok");
        }
    }
}
