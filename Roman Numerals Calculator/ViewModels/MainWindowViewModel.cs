using System;
using System.Collections.Generic;
using System.Text;
using System.Reactive;
using ReactiveUI;
using RomanNumCalculator.Models;

namespace RomanNumCalculator.ViewModels
{
    public class MainWindowViewModel : ViewModelBase
    {
        string secondNum;
        string _operation = " ";
        private RomanNumberExtend _result;
        private RomanNumberExtend _secondValue;
        public MainWindowViewModel()
        {
            AddNum = ReactiveCommand.Create<string, string>(AddNumTo);
            ExecuteOperationCommand = ReactiveCommand.Create<string>(Operations);
        }
        public string ShowValue
        {
            set
            {
                this.RaiseAndSetIfChanged(ref secondNum, value);
            }
            get
            {
                return secondNum;
            }
        }
        public ReactiveCommand<string, string> AddNum { get; }
        public ReactiveCommand<string, Unit> ExecuteOperationCommand { get; }

        private string AddNumTo(string str)
        {
            if (_operation == "n")
            {
                ShowValue = str;
                _operation = " ";
            }
            else
            {
                ShowValue += str;
            }
            return ShowValue;
        }
        private void Operations(string operation)
        {
            if (RomanNumberExtend.To_Int(secondNum) > 0)
                _secondValue = new RomanNumberExtend(secondNum);
            RomanNumber tmp;
            try
            {
                switch (_operation[0])
                {
                    case '+':
                        {
                            tmp = _result + _secondValue;
                            _result = new RomanNumberExtend(tmp.ToString());
                            break;
                        }
                    case '*':
                        {
                            tmp = _result * _secondValue;
                            _result = new RomanNumberExtend(tmp.ToString());
                            break;
                        }
                    case '/':
                        {
                            tmp = _result / _secondValue;
                            _result = new RomanNumberExtend(tmp.ToString());
                            break;
                        }
                    case '-':
                        {
                            tmp = _result - _secondValue;
                            _result = new RomanNumberExtend(tmp.ToString());
                            break;
                        }
                    case ' ':
                        {
                            if (RomanNumberExtend.To_Int(secondNum) > 0)
                                _result = new RomanNumberExtend(secondNum);
                            break;
                        }
                    case 'n':
                        {
                            if (RomanNumberExtend.To_Int(secondNum) > 0)
                                _result = new RomanNumberExtend(secondNum);
                            break;
                        }
                    default:
                        break;
                }
                if (operation == "=")
                {
                    if (_result != null)
                        ShowValue = _result.ToString();
                    _operation = "n";
                    _result = null;
                }
                else
                {
                    _operation = operation;
                    ShowValue = "";
                }
            }
            catch (RomanNumberException ex)
            {
                ShowValue = $"{ex.Message}";
            }
        }
    }
}