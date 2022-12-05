using System;

namespace Model
{
    [Serializable]
    public class Customer
    {
        public string CustomerId { get; set; }
        public string CustomerName { get; set; }
        public string CompanyName { get; set; }
        public string CustomerTitle { get; set; }
        public string Address { get; set; }

    }
}