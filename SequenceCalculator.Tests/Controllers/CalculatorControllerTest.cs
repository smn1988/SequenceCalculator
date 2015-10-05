using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SequenceCalculator;
using SequenceCalculator.Controllers;
using SequenceCalculator.Models;
using System.ComponentModel.DataAnnotations;

namespace SequenceCalculator.Tests.Controllers
{
    [TestClass]
    public class CalculatorControllerTest
    {
        [TestMethod]
        public void Index()
        {
            // Arrange
            CalculatorController controller = new CalculatorController();

            // Act
            ViewResult result = controller.Index() as ViewResult;

            // Assert
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void Calculator_AddNegativeValue_ReturnError()
        {
            // Arrange
            CalculatorModel calculateModel = new CalculatorModel();
            calculateModel.number = -10;            
            // Act
            var validationResult = Validator.TryValidateObject(calculateModel, new ValidationContext(calculateModel, null, null), null, true);
            // Assert
            Assert.IsFalse(validationResult);
        }

        [TestMethod]
        public void Calculator_AddNegativeValue_GetView()
        {
            // Arrange
            CalculatorModel calculateModel = new CalculatorModel();
            calculateModel.number = 10;
            ActionResult result = null;
            // Act
            var validationResult = Validator.TryValidateObject(calculateModel, new ValidationContext(calculateModel, null, null), null, true);
            Assert.IsTrue(validationResult);

            CalculatorController calculateCnt = new CalculatorController();
            result = calculateCnt.Calculate(calculateModel);
            ViewResult viewResult = (ViewResult)result;
            calculateModel = (CalculatorModel)viewResult.Model;

            Assert.IsNotNull(calculateModel.evenNumbers);
        }
    }
}
