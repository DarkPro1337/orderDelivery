using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace orderDelivery.ViewModels
{
    public class CreateOrderViewModel
    {
        [Required(ErrorMessage = "Город отправителя не введён!")]
        [Display(Name = "Город отправителя")]
        public string SenderCity { get; set; }
        [Required(ErrorMessage = "Адрес отправителя не введён!")]
        [Display(Name = "Адрес отправителя")]
        public string SenderAddress { get; set; }
        [Required(ErrorMessage = "Город получателя не введён!")]
        [Display(Name = "Город получателя")]
        public string RecipientCity { get; set; }
        [Required(ErrorMessage = "Адрес получателя не введён!")]
        [Display(Name = "Адрес получателя")]
        public string RecipientAddress { get; set; }
        [Required(ErrorMessage = "Вес посылки не введён!")]
        [Display(Name = "Вес посылки")]
        public double PackageWeight { get; set; }
        [Required(ErrorMessage = "Дата забора не введена!")]
        [Display(Name = "Дата забора")]
        public DateTime PickupDate { get; set; }
    }
}
