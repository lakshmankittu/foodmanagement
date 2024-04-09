using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodManagement.Models
{
    public enum OrderStatus
    {
        NEW,
        PAYED,
        SHIPPED,
        CANCELED,
        REFUNDED
    }

    public class Order
    {
        public string Id { get; set; } 
        public decimal TotalPrice { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string AddressLatLng { get; set; }
        public string PaymentId { get; set; }
        public OrderStatus Status { get; set; }
        public string UserId { get; set; } 
        public User User { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }

}
