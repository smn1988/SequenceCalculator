using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
using System.Collections.Generic;
using SequenceCalculator.Models;

namespace SequenceCalculator.Models
{
    public class CalculatorModel
    {

        [Required(ErrorMessage = "Input is required")]
        [PositiveNumberValidation(ErrorMessage = "Please enter positive number greater than 0")]
        public int number { get; set; }

        public List<int> oddNumbers;
        public List<int> evenNumbers;
        public List<int> fibonacci;
        public List<string> special;

    }
}