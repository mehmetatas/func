using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace Antlr.Tests.Program
{
    public enum FuncType
    {
        Void,
        Number,
        String,
        Bool,
        Date,
        Time,
        DateTime
    }

    public class ProgramContext
    {
        private static readonly IFormatProvider Format = new CultureInfo("en-GB");

        private readonly IDictionary<string, Function> _functions = new Dictionary<string, Function>();
        private readonly IList<IExpression> _expressions = new List<IExpression>();

        public ProgramContext()
        {
            AddFunction(new PrintFunction());
            AddFunction(new SubstrFunction());
            AddFunction(new LengthFunction());
        }

        public void AddFunction(Function function)
        {
            _functions.Add(function.Name.TrimStart('$'), function);
        }

        public void AddExpression(IExpression expression)
        {
            _expressions.Add(expression);
        }

        public Function GetFunction(string functionName)
        {
            return _functions[functionName];
        }

        public void Run()
        {
            foreach (var expression in _expressions)
            {
                using (var context = new EvaluationContext(this))
                {
                    expression.Evaluate(context);
                }
            }
        }

        public static ProgramContext Create(ProgramNode node)
        {
            var program = new ProgramContext();

            foreach (var programNode in node.ChildNodes)
            {
                switch (programNode.Type)
                {
                    case FuncLexer.FUNC:
                        if (programNode.Text == "function")
                        {
                            var it = programNode.ChildNodes.GetEnumerator();

                            it.MoveNext();
                            var child = it.Current;

                            var func = new Function
                            {
                                Name = child.Text
                            };

                            it.MoveNext();
                            child = it.Current;

                            func.ReturnType = FuncType.Void;
                            if (!child.ChildNodes.Any())
                                func.ReturnType = GetFuncType(child.Text);

                            while (it.MoveNext())
                            {
                                child = it.Current;

                                if (child.Text == "body")
                                {
                                    func.Body = new FunctionBody();
                                    foreach (var childNode in child.ChildNodes)
                                        func.Body.Expressions.Add(CreateExpression(childNode));
                                    break;
                                }

                                var cn = child.ChildNodes.ToArray();
                                var arg = new Variable
                                {
                                    Name = cn[0].Text,
                                    Type = GetFuncType(child.Text)
                                };

                                func.Args.Add(arg);
                            }

                            program.AddFunction(func);
                        }
                        else
                        {
                            program.AddExpression(CreateExpression(programNode));
                        }
                        break;
                    case FuncLexer.METHOD:
                        break;
                    default:
                        throw new InvalidProgramException("Unexpected program node type: " + programNode.Type);
                }
            }

            return program;
        }

        private static IExpression CreateExpression(ProgramNode node)
        {
            IExpression expression;
            if (node.Type == FuncLexer.FUNC)
            {
                if (node.Text == "if")
                {
                    var ifExp = new IfExpression();

                    foreach (var childNode in node.ChildNodes)
                    {
                        if (childNode.Text == "case")
                            ifExp.CaseExpressions.Add((CaseExpression)CreateExpression(childNode));
                        else if (childNode.Text == "default")
                            ifExp.DefaultExpression = (DefaultExpression)CreateExpression(childNode);
                        else
                            throw new InvalidProgramException();
                    }

                    expression = ifExp;
                }
                else if (node.Text == "case")
                {
                    var cn = node.ChildNodes.ToArray();

                    var caseExp = new CaseExpression
                    {
                        LogicalExpression = (LogicalExpression)CreateExpression(cn[0])
                    };

                    for (var i = 1; i < cn.Length; i++)
                        caseExp.Expressions.Add(CreateExpression(cn[i]));

                    expression = caseExp;
                }
                else if (node.Text == "default")
                {
                    var defExp = new DefaultExpression();

                    foreach (var childNode in node.ChildNodes)
                        defExp.Expressions.Add(CreateExpression(childNode));

                    expression = defExp;
                }
                else if (node.Text == "lt")
                {
                    var cn = node.ChildNodes.ToArray();

                    var ltExp = new LessThanExpression
                    {
                        LeftExpression = CreateExpression(cn[0]),
                        RightExpression = CreateExpression(cn[1])
                    };

                    expression = ltExp;
                }
                else if (node.Text == "return")
                {
                    var retExp = new ReturnExpression
                    {
                        Expression = CreateExpression(node.ChildNodes.First())
                    };

                    expression = retExp;
                }
                else if (node.Text == "set")
                {
                    var cn = node.ChildNodes.ToArray();

                    var setExp = new SetExpression
                    {
                        TargetVariable = cn[0].Text,
                        SourceExpression = CreateExpression(cn[1])
                    };

                    expression = setExp;
                }
                else if (node.Text == "string" ||
                         node.Text == "number" ||
                         node.Text == "bool" ||
                         node.Text == "date" ||
                         node.Text == "time" ||
                         node.Text == "datetime")
                {
                    var cn = node.ChildNodes.ToArray();

                    var decExp = new VariableDeclerationExpression
                    {
                        Variable = new Variable
                        {
                            Name = cn[0].Text,
                            Type = GetFuncType(node.Text)
                        }
                    };

                    if (cn.Length == 2)
                    {
                        var valueExp = CreateExpression(cn[1]);
                        decExp.Variable.Value = valueExp.Evaluate(null);
                    }

                    expression = decExp;
                }
                else
                {
                    var callExp = new CallExpression
                    {
                        TargetPath = node.Text
                    };

                    foreach (var childNode in node.ChildNodes)
                        callExp.Parameters.Add(CreateExpression(childNode));

                    expression = callExp;
                }
            }
            else if (node.Type == FuncLexer.METHOD)
            {
                var callExp = new CallExpression
                {
                    TargetPath = node.Text
                };
                foreach (var childNode in node.ChildNodes)
                    callExp.Parameters.Add(CreateExpression(childNode));

                expression = callExp;
            }
            else if (node.Type == FuncLexer.VAR)
            {
                var varExp = new VarExpression
                {
                    Name = node.Text
                };

                expression = varExp;
            }
            else if (node.Type == FuncLexer.NUMBER)
            {
                var numExp = new NumberExpression
                {
                    Value = Decimal.Parse(node.Text, Format)
                };

                expression = numExp;
            }
            else if (node.Type == FuncLexer.STRING)
            {
                var strExp = new StringExpression
                {
                    Value = node.Text
                };

                expression = strExp;
            }
            else if (node.Type == FuncLexer.BOOLEAN)
            {
                var boolExp = new BoolExpression
                {
                    Value = node.Text == "true"
                };

                expression = boolExp;
            }
            else if (node.Type == FuncLexer.DATE)
            {
                var dateExp = new DateExpression
                {
                    Value = DateTime.ParseExact(node.Text, "yyyy-MM-dd", CultureInfo.CurrentCulture)
                };

                expression = dateExp;
            }
            else if (node.Type == FuncLexer.TIME)
            {
                var format = "HH:mm:ss";
                if (node.Text.Contains("."))
                    format += ".fff";

                var timeExp = new TimeExpression
                {
                    Value = DateTime.ParseExact(node.Text, format, CultureInfo.CurrentCulture)
                };

                expression = timeExp;
            }
            else if (node.Type == FuncLexer.DATETIME)
            {
                var format = "yyyy-MM-dd HH:mm:ss";
                if (node.Text.Contains("."))
                    format += ".fff";

                var dtExp = new DateTimeExpression
                {
                    Value = DateTime.ParseExact(node.Text, format, CultureInfo.CurrentCulture)
                };

                expression = dtExp;
            }
            else
            {
                throw new InvalidProgramException();
            }
            return expression;
        }

        private static FuncType GetFuncType(string text)
        {
            if (text == "string")
                return FuncType.String;
            if (text == "bool")
                return FuncType.Bool;
            if (text == "number")
                return FuncType.Number;
            if (text == "date")
                return FuncType.Date;
            if (text == "time")
                return FuncType.Time;
            if (text == "datetime")
                return FuncType.DateTime;

            throw new InvalidProgramException("Invalid return type: " + text);
        }
    }

    public class EvaluationContext : IDisposable
    {
        private readonly IDictionary<string, Variable> _variables;
        public ProgramContext ProgramContext { get; private set; }

        public EvaluationContext(ProgramContext programContext)
        {
            ProgramContext = programContext;
            _variables = new Dictionary<string, Variable>();
        }
        
        public EvaluationContext CreateChild()
        {
            return new EvaluationContext(ProgramContext);
        }

        public void AddVariable(Variable variable)
        {
            _variables.Add(variable.Name, variable);
        }

        public Variable GetVariable(string variableName)
        {
            return _variables[variableName];
        }

        public void Dispose()
        {

        }
    }

    public class Function : IExpression
    {
        public string Name { get; set; }
        public FuncType ReturnType { get; set; }
        public IList<Variable> Args { get; private set; }
        public FunctionBody Body { get; set; }

        public Function()
        {
            Args = new List<Variable>();
        }

        public virtual object Evaluate(EvaluationContext context)
        {
            foreach (var arg in Args)
                context.AddVariable(arg);

            return Body.Evaluate(context);
        }
    }

    public class SubstrFunction : Function
    {
        public SubstrFunction()
        {
            Name = "substr";
            Args.Add(new Variable { Name = "str", Type = FuncType.String });
            Args.Add(new Variable { Name = "start", Type = FuncType.Number });
            Args.Add(new Variable { Name = "length", Type = FuncType.Number });
        }

        public override object Evaluate(EvaluationContext context)
        {
            var str = (string)Args[0].Value;
            var start = Convert.ToInt32((decimal)Args[1].Value);
            var length = Convert.ToInt32((decimal)Args[2].Value);

            return str.Substring(start, length);
        }
    }

    public class PrintFunction : Function
    {
        public PrintFunction()
        {
            Name = "print";
            Args.Add(new Variable { Name = "str", Type = FuncType.String });
        }

        public override object Evaluate(EvaluationContext context)
        {
            var str = (string)Args[0].Value;
            Console.Write(str);
            return null;
        }
    }

    public class LengthFunction : Function
    {
        public LengthFunction()
        {
            Name = "length";
            Args.Add(new Variable { Name = "str", Type = FuncType.String });
        }

        public override object Evaluate(EvaluationContext context)
        {
            var str = (string)Args[0].Value;
            return str.Length;
        }
    }

    public class Variable
    {
        public string Name { get; set; }
        public FuncType Type { get; set; }
        public object Value { get; set; }
    }

    public class FunctionBody : IExpression
    {
        public IList<IExpression> Expressions { get; private set; }

        public FunctionBody()
        {
            Expressions = new List<IExpression>();
        }

        public object Evaluate(EvaluationContext context)
        {
            object res = null;
            foreach (var expression in Expressions)
                res = expression.Evaluate(context);
            return res;
        }
    }

    public interface IExpression
    {
        object Evaluate(EvaluationContext context);
    }

    public class IfExpression : IExpression
    {
        public IList<CaseExpression> CaseExpressions { get; set; }
        public DefaultExpression DefaultExpression { get; set; }

        public IfExpression()
        {
            CaseExpressions = new List<CaseExpression>();
        }

        public object Evaluate(EvaluationContext context)
        {
            foreach (var caseExpression in CaseExpressions)
            {
                var res = (bool)caseExpression.LogicalExpression.Evaluate(context);
                if (res)
                    return caseExpression.Evaluate(context);
            }

            return DefaultExpression.Evaluate(context);
        }
    }

    public class CaseExpression : IExpression
    {
        public LogicalExpression LogicalExpression { get; set; }
        public IList<IExpression> Expressions { get; set; }

        public CaseExpression()
        {
            Expressions = new List<IExpression>();
        }

        public object Evaluate(EvaluationContext context)
        {
            object res = null;
            foreach (var expression in Expressions)
                res = expression.Evaluate(context);
            return res;
        }
    }

    public class DefaultExpression : IExpression
    {
        public IList<IExpression> Expressions { get; set; }

        public DefaultExpression()
        {
            Expressions = new List<IExpression>();
        }

        public object Evaluate(EvaluationContext context)
        {
            object res = null;
            foreach (var expression in Expressions)
                res = expression.Evaluate(context);
            return res;
        }
    }

    public class SetExpression : IExpression
    {
        public string TargetVariable { get; set; }
        public IExpression SourceExpression { get; set; }

        public object Evaluate(EvaluationContext context)
        {
            var variable = context.GetVariable(TargetVariable);
            return variable.Value = SourceExpression.Evaluate(context);
        }
    }

    public abstract class LogicalExpression : IExpression
    {
        public abstract object Evaluate(EvaluationContext context);
    }

    public abstract class CompareExpression : LogicalExpression
    {
        public IExpression LeftExpression { get; set; }
        public IExpression RightExpression { get; set; }

        public override object Evaluate(EvaluationContext context)
        {
            var l = (IComparable)LeftExpression.Evaluate(context);
            var r = RightExpression.Evaluate(context);

            var rVal = Convert.ChangeType(r, l.GetType());

            return GetResult(l.CompareTo(rVal));
        }

        protected abstract bool GetResult(int comparisonResult);
    }

    public class LessThanExpression : CompareExpression
    {
        protected override bool GetResult(int comparisonResult)
        {
            return comparisonResult < 0;
        }
    }

    public class ReturnExpression : IExpression
    {
        public IExpression Expression { get; set; }

        public object Evaluate(EvaluationContext context)
        {
            return Expression.Evaluate(context);
        }
    }

    public class CallExpression : IExpression
    {
        public string TargetPath { get; set; }
        public IList<IExpression> Parameters { get; set; }

        public CallExpression()
        {
            Parameters = new List<IExpression>();
        }

        public object Evaluate(EvaluationContext context)
        {
            var func = context.ProgramContext.GetFunction(TargetPath);

            if (func.Args.Count != Parameters.Count)
                throw new InvalidProgramException();

            for (var i = 0; i < Parameters.Count; i++)
                func.Args[i].Value = Parameters[i].Evaluate(context);

            return func.Evaluate(context);
        }
    }

    public class VarExpression : IExpression
    {
        public string Name { get; set; }

        public object Evaluate(EvaluationContext context)
        {
            return context.GetVariable(Name).Value;
        }
    }

    public class VariableDeclerationExpression : IExpression
    {
        public Variable Variable { get; set; }

        public object Evaluate(EvaluationContext context)
        {
            context.AddVariable(Variable);
            return null;
        }
    }

    public abstract class ValueExpression<T> : IExpression
    {
        public T Value { get; set; }

        public virtual object Evaluate(EvaluationContext context)
        {
            return Value;
        }

        public override string ToString()
        {
            return Value.ToString();
        }
    }

    public class NumberExpression : ValueExpression<decimal>
    {

    }

    public class StringExpression : ValueExpression<string>
    {

    }

    public class BoolExpression : ValueExpression<bool>
    {

    }

    public class DateExpression : ValueExpression<DateTime>
    {

    }

    public class TimeExpression : ValueExpression<DateTime>
    {

    }

    public class DateTimeExpression : ValueExpression<DateTime>
    {

    }
}
