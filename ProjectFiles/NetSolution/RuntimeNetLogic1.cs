#region Using directives
using System;
using UAManagedCore;
using OpcUa = UAManagedCore.OpcUa;
using FTOptix.UI;
using FTOptix.NativeUI;
using FTOptix.HMIProject;
using FTOptix.Retentivity;
using FTOptix.CoreBase;
using FTOptix.Core;
using FTOptix.NetLogic;
using System.IO;
using System.Runtime.InteropServices;
using System.Text.RegularExpressions;
using CalculatorEngine.Managed;
#endregion

public class RuntimeNetLogic1 : BaseNetLogic
{
    public override void Start()
    {

    }

    public override void Stop()
    {

    }

    [ExportMethod]
    public void EvaluateExpression(string expression)
    {
        try
        {
            expression = Regex.Replace(expression, @"\s+", "");
            string pattern = @"(\d+(\.\d+)?)(\+|\-|\*|\/)(\d+(\.\d+)?)";
            Match match = Regex.Match(expression, pattern);
            if (match.Success)
            {
                double a = double.Parse(match.Groups[1].Value);
                double b = double.Parse(match.Groups[4].Value);
                char op = match.Groups[3].Value[0];
                double result = 0.0;
                switch (op)
                {
                    case '+':
                        result = Calculator.Add(a, b);
                        break;
                    case '-':
                        result = Calculator.Subtract(a, b);
                        break;
                    case '*':
                        result = Calculator.Multiply(a, b);
                        break;
                    case '/':
                        result = Calculator.Divide(a, b);
                        break;
                }
                Project.Current.GetVariable("Model/Result").Value = $"Expression Result: {result}";
                Log.Info($"Expression Result: {result}");
            }
            else
            {
                Project.Current.GetVariable("Model/Result").Value = $"Invalid expression";
                throw new Exception("Invalid expression");
            }
        }
        catch (Exception ex)
        {
            Project.Current.GetVariable("Model/Result").Value = $"{this.ToString()} - {System.Reflection.MethodBase.GetCurrentMethod().Name} - Error: {ex.Message}";
            Log.Error($"{this.ToString()} - {System.Reflection.MethodBase.GetCurrentMethod().Name}", $"Error: {ex.Message}");
        }

    }
}
