using System;
using System.Threading.Tasks;
using System.Windows.Input;
using xamarin.quest.course.Common.Navigation;
using xamarin.quest.course.Modules.History;
using Xamarin.Forms;

namespace xamarin.quest.course.Modules.Calculator
{
    public enum CalculatorState
    {
        PopulatingFirstNumber,
        PopulatingSecondNumber
    }

    public enum Operation
    {
        None,
        Add,
        Subtract,
        Divide,
        Multiply,
        Equal
    }

    public class CalculatorViewModel : BindableObject
    {
        private string _displayText;
        private string _firstNumber = string.Empty;
        private string _secondNumber = string.Empty;
        private CalculatorState _state;
        private Operation _currentOperation;
        private readonly INavigationService _navigation;

        public CalculatorViewModel(INavigationService navigation)
        {
            this._state = CalculatorState.PopulatingFirstNumber;
            this._currentOperation = Operation.None;
            this._navigation = navigation;
        }

        public string DisplayText
        {
            get => this._displayText;
            set
            {
                this._displayText = value;
                this.OnPropertyChanged();
            }
        }

        public ICommand ClearCommand => new Command(this.ClearText);
        public ICommand AddCharCommand => new Command<string>(this.AddChar);
        public ICommand OperationCommand => new Command<Operation>(this.PerformOperation);
        public ICommand ShowHistoryCommand => new Command(async () => await this.GoToHistory());

        private async Task GoToHistory()
        {
            await this._navigation.PushAsync<HistoryViewModel>();
        }

        private void AddChar(string character)
        {
            if (this._state == CalculatorState.PopulatingFirstNumber)
            {
                if (this._firstNumber.Contains(",") && character == ",")
                {
                    return;
                }
                this._firstNumber += character;
                DisplayText = this._firstNumber;
                return;
            }

            if (this._secondNumber.Contains(",") && character == ",")
            {
                return;
            }
            this._secondNumber += character;
            this.DisplayText = this._secondNumber;
        }

        private void ClearText()
        {
            this._firstNumber = string.Empty;
            this._secondNumber = string.Empty;
            this.DisplayText = string.Empty;
            this._state = CalculatorState.PopulatingFirstNumber;
        }

        private void PerformOperation(Operation operation)
        {
            if (operation == Operation.Equal &&
                !string.IsNullOrWhiteSpace(this._firstNumber) &&
                !string.IsNullOrWhiteSpace(this._secondNumber))
            {
                this.Calculate();
                return;
            }
            this._currentOperation = operation;
            this.DisplayText = string.Empty;
            this._state = CalculatorState.PopulatingSecondNumber;
        }

        private void Calculate()
        {
            var first = decimal.Parse(this._firstNumber);
            var second = decimal.Parse(this._secondNumber);
            var result = 0m;
            switch (this._currentOperation)
            {
                case Operation.Add:
                    result = first + second;
                    break;
                case Operation.Subtract:
                    result = first - second;
                    break;
                case Operation.Divide:
                    result = first / second;
                    break;
                case Operation.Multiply:
                    result = first * second;
                    break;
                default:
                    break;
            }
            this.DisplayText = result.ToString();
            this._currentOperation = Operation.None;
            this._state = CalculatorState.PopulatingFirstNumber;
            this._firstNumber = string.Empty;
            this._secondNumber = string.Empty;
        }
    }
}
