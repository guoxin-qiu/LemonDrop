using TechTalk.SpecFlow;
using FluentAssertions;

namespace LemonDrop.AcceptanceTests.StepDefinitions
{
    [Binding]
    public class CalculatorSteps
    {
        public class Calculator
        {
            public int FirstNumber { get; set; }
            public int SecondNumber { get; set; }
            public int Add()
            {
                return FirstNumber + SecondNumber;
            }
        }

        private Calculator calculator = new Calculator();
        private int result;

        [Given(@"I have entered (.*) into the calculator")]
        public void GivenIHaveEnteredIntoTheCalculator(int firstNumber)
        {
            calculator.FirstNumber = firstNumber;
        }
        
        [Given(@"I have also entered (.*) into the calculator")]
        public void GivenIHaveAlsoEnteredIntoTheCalculator(int secondNumber)
        {
            calculator.SecondNumber = secondNumber;
        }
        
        [When(@"I press add")]
        public void WhenIPressAdd()
        {
            result = calculator.Add();
        }
        
        [Then(@"the result should be (.*) on the screen")]
        public void ThenTheResultShouldBeOnTheScreen(int expectResult)
        {
            result.Should().Equals(expectResult);
        }
    }
}
