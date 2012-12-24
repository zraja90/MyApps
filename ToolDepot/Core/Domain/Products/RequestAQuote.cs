﻿namespace ToolDepot.Models
{
    public class RequestAQuote
    {
        public string Email { get; set; }   
        public string CompanyName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string ZipCode { get; set; }
        public string PhoneNumber { get; set; }
        public string FaxNumber { get; set; }        
    }
}