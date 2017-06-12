using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VeDoThi
{
     //Loại bao gồm : Biến, giá trị, toán tử, chức năng, kết quả, ngoặc, phẩy, lỗi
    public enum Type { Variable, Value, Operator, Function, Result, Bracket, Comma, Error }

    public struct Symbol
    {
        public string m_name; //Tên kí hiệu
        public double m_value; //Giá trị
        public Type m_type; //Loại 

        public override string ToString()
        {
            return m_name; //Trả về tên của kí hiệu đó
        }
    }


    public delegate Symbol EvaluateFunctionDelegate(string name, Object[] args);


    class HamTinh
    {
        protected bool m_bError = false;
        protected string m_sErrorDescription = "None";
        protected double m_result = 0;
        protected ArrayList m_equation = new ArrayList();// mảng phương trình
        protected ArrayList m_postfix = new ArrayList();// mảng lỗi
        protected EvaluateFunctionDelegate m_defaultFunctionEvaluation;

        public double Result //Kết quả
        {
            get
            {
                return m_result;
            }
        }

        public ArrayList Equation //Phương trình
        {
            get
            {
                return (ArrayList)m_equation.Clone();
            }
        }
        public ArrayList Postfix //Sửa lỗi ở phương trình
        {
            get
            {
                return (ArrayList)m_postfix.Clone();
            }
        }

        public EvaluateFunctionDelegate DefaultFunctionEvaluation
        {
            set
            {
                m_defaultFunctionEvaluation = value;
            }
        }

        public bool Error  //Lỗi hay không
        {
            get
            {
                return m_bError;
            }
        }

        public string ErrorDescription//Mô tả lỗi
        {
            get
            {
                return m_sErrorDescription;
            }
        }

        public ArrayList Variables //danh sách Biến
        {
            get
            {
                ArrayList var = new ArrayList();
                foreach (Symbol sym in m_equation) //Duyệt phương trình
                {
                    if ((sym.m_type == Type.Variable) && (!var.Contains(sym))) //Nếu là biến và biến đó chưa xuất hiện
                        var.Add(sym); //Thêm vào cuối danh sách biến
                }
                return var;
            }
            set
            {
                foreach (Symbol sym in value)//duyệt các giá trị trong arraylist
                {
                    for (int i = 0; i < m_postfix.Count; i++) //duyệt các 
                    {
                        //Xác định là biến
                        if ((sym.m_name == ((Symbol)m_postfix[i]).m_name) && (((Symbol)m_postfix[i]).m_type == Type.Variable))
                        {
                            Symbol sym1 = (Symbol)m_postfix[i];
                            sym1.m_value = sym.m_value;
                            m_postfix[i] = sym1;
                        }
                    }
                }
            }
        }

        public HamTinh()
        { }

        public void Parse(string equation) //Phân tích cú pháp 
        {
            int state = 1;
            string temp = "";
            Symbol ctSymbol;

            m_bError = false;
            m_sErrorDescription = "None";

            m_equation.Clear();
            m_postfix.Clear();

            int nPos = 0;
            //Xóa toàn bộ khoảng trắng đầu và cuối chuỗi
            equation = equation.Trim();
            //Xóa các khoảng trắng thừa còn lại
            while ((nPos = equation.IndexOf(' ')) != -1)
                equation = equation.Remove(nPos, 1);

            //Duyệt qua các kí tự trong hàm
            for (int i = 0; i < equation.Length; i++)
            {
                switch (state)
                {
                    case 1:
                        if (Char.IsNumber(equation[i]))//Nếu là số
                        {
                            state = 2;
                            temp += equation[i];
                        }
                        else if (Char.IsLetter(equation[i]))//nếu là chữ cái
                        {
                            state = 3;
                            temp += equation[i];
                        }
                        else//trường hợp khác
                        {
                            ctSymbol.m_name = equation[i].ToString();
                            ctSymbol.m_value = 0;
                            switch (ctSymbol.m_name)
                            {
                                case ",":
                                    ctSymbol.m_type = Type.Comma;
                                    break;
                                case "(":
                                case ")":
                                case "[":
                                case "]":
                                case "{":
                                case "}":
                                    ctSymbol.m_type = Type.Bracket;
                                    break;
                                default:
                                    ctSymbol.m_type = Type.Operator;
                                    break;
                            }
                            m_equation.Add(ctSymbol);
                        }
                        break;
                    case 2:
                        if ((Char.IsNumber(equation[i])) || (equation[i] == '.'))//là số hoặc là dấu chấm
                            temp += equation[i];
                        else if (!Char.IsLetter(equation[i]))//Không là chữ cái->loại số
                        {
                            state = 1;
                            ctSymbol.m_name = temp;
                            ctSymbol.m_value = Double.Parse(temp);
                            ctSymbol.m_type = Type.Value;
                            m_equation.Add(ctSymbol);
                            ctSymbol.m_name = equation[i].ToString();
                            ctSymbol.m_value = 0;
                            switch (ctSymbol.m_name)
                            {
                                case ",":
                                    ctSymbol.m_type = Type.Comma;
                                    break;
                                case "(":
                                case ")":
                                case "[":
                                case "]":
                                case "{":
                                case "}":
                                    ctSymbol.m_type = Type.Bracket;
                                    break;
                                default:
                                    ctSymbol.m_type = Type.Operator;
                                    break;
                            }
                            m_equation.Add(ctSymbol);
                            temp = "";
                        }
                        break;
                    case 3:
                        if (Char.IsLetterOrDigit(equation[i]))
                            temp += equation[i];
                        else
                        {
                            state = 1;
                            ctSymbol.m_name = temp;
                            ctSymbol.m_value = 0;
                            if (equation[i] == '(')
                                ctSymbol.m_type = Type.Function;
                            else
                            {
                                if (ctSymbol.m_name == "pi")
                                    ctSymbol.m_value = System.Math.PI;
                                else if (ctSymbol.m_name == "e")
                                    ctSymbol.m_value = System.Math.E;
                                ctSymbol.m_type = Type.Variable;
                            }
                            m_equation.Add(ctSymbol);
                            ctSymbol.m_name = equation[i].ToString();
                            ctSymbol.m_value = 0;
                            switch (ctSymbol.m_name)
                            {
                                case ",":
                                    ctSymbol.m_type = Type.Comma;
                                    break;
                                case "(":
                                case ")":
                                case "[":
                                case "]":
                                case "{":
                                case "}":
                                    ctSymbol.m_type = Type.Bracket;
                                    break;
                                default:
                                    ctSymbol.m_type = Type.Operator;
                                    break;
                            }
                            m_equation.Add(ctSymbol);
                            temp = "";
                        }
                        break;
                }
            }
            if (temp != "")
            {
                ctSymbol.m_name = temp;
                if (state == 2)
                {
                    ctSymbol.m_value = Double.Parse(temp);
                    ctSymbol.m_type = Type.Value;
                }
                else
                {
                    if (ctSymbol.m_name == "pi")
                        ctSymbol.m_value = System.Math.PI;
                    else if (ctSymbol.m_name == "e")
                        ctSymbol.m_value = System.Math.E;
                    else
                        ctSymbol.m_value = 0;
                    ctSymbol.m_type = Type.Variable;
                }
                m_equation.Add(ctSymbol);
            }
        }

        public void Infix2Postfix()
        {
            Symbol tpSym;
            Stack tpStack = new Stack();
            foreach (Symbol sym in m_equation)
            {
                if ((sym.m_type == Type.Value) || (sym.m_type == Type.Variable))
                    m_postfix.Add(sym);
                else if ((sym.m_name == "(") || (sym.m_name == "[") || (sym.m_name == "{"))
                    tpStack.Push(sym);
                else if ((sym.m_name == ")") || (sym.m_name == "]") || (sym.m_name == "}"))
                {
                    if (tpStack.Count > 0)
                    {
                        tpSym = (Symbol)tpStack.Pop();
                        while ((tpSym.m_name != "(") && (tpSym.m_name != "[") && (tpSym.m_name != "{"))
                        {
                            m_postfix.Add(tpSym);
                            tpSym = (Symbol)tpStack.Pop();
                        }
                    }
                }
                else
                {
                    if (tpStack.Count > 0)
                    {
                        tpSym = (Symbol)tpStack.Pop();
                        while ((tpStack.Count != 0) && ((tpSym.m_type == Type.Operator) || (tpSym.m_type == Type.Function) || (tpSym.m_type == Type.Comma)) && (Precedence(tpSym) >= Precedence(sym)))
                        {
                            m_postfix.Add(tpSym);
                            tpSym = (Symbol)tpStack.Pop();
                        }
                        if (((tpSym.m_type == Type.Operator) || (tpSym.m_type == Type.Function) || (tpSym.m_type == Type.Comma)) && (Precedence(tpSym) >= Precedence(sym)))
                            m_postfix.Add(tpSym);
                        else
                            tpStack.Push(tpSym);
                    }
                    tpStack.Push(sym);
                }
            }
            while (tpStack.Count > 0)
            {
                tpSym = (Symbol)tpStack.Pop();
                m_postfix.Add(tpSym);
            }
        }

        public void EvaluatePostfix()
        {
            Symbol tpSym1, tpSym2, tpResult;
            Stack tpStack = new Stack();
            ArrayList fnParam = new ArrayList();
            m_bError = false;
            foreach (Symbol sym in m_postfix)
            {
                
                if ((sym.m_type == Type.Value) || (sym.m_type == Type.Variable) || (sym.m_type == Type.Result))
                    tpStack.Push(sym);
                else if (sym.m_type == Type.Operator)
                {
                    tpSym1 = (Symbol)tpStack.Pop();
              
                    tpSym2 = (Symbol)tpStack.Pop();
                    tpResult = Evaluate(tpSym2, sym, tpSym1);
                    if (tpResult.m_type == Type.Error)
                    {
                        m_bError = true;
                        m_sErrorDescription = tpResult.m_name;
                        return;
                    }
                    tpStack.Push(tpResult);
                }
                else if (sym.m_type == Type.Function)
                {
                    fnParam.Clear();
                    tpSym1 = (Symbol)tpStack.Pop();
                    if ((tpSym1.m_type == Type.Value) || (tpSym1.m_type == Type.Variable) || (tpSym1.m_type == Type.Result))
                    {
                        tpResult = EvaluateFunction(sym.m_name, tpSym1);
                        if (tpResult.m_type == Type.Error)
                        {
                            m_bError = true;
                            m_sErrorDescription = tpResult.m_name;
                            return;
                        }
                        tpStack.Push(tpResult);
                    }
                    else if (tpSym1.m_type == Type.Comma)
                    {
                        while (tpSym1.m_type == Type.Comma)
                        {
                            tpSym1 = (Symbol)tpStack.Pop();
                            fnParam.Add(tpSym1);
                            tpSym1 = (Symbol)tpStack.Pop();
                        }
                        fnParam.Add(tpSym1);
                        tpResult = EvaluateFunction(sym.m_name, fnParam.ToArray());
                        if (tpResult.m_type == Type.Error)
                        {
                            m_bError = true;
                            m_sErrorDescription = tpResult.m_name;
                            return;
                        }
                        tpStack.Push(tpResult);
                    }
                    else
                    {
                        tpStack.Push(tpSym1);
                        tpResult = EvaluateFunction(sym.m_name);
                        if (tpResult.m_type == Type.Error)
                        {
                            m_bError = true;
                            m_sErrorDescription = tpResult.m_name;
                            return;
                        }
                        tpStack.Push(tpResult);
                    }
                }
            }
            if (tpStack.Count == 1)
            {
                tpResult = (Symbol)tpStack.Pop();
                m_result = tpResult.m_value;
            }
        }

        protected int Precedence(Symbol sym)
        {
            switch (sym.m_type)
            {
                case Type.Bracket:
                    return 5;
                case Type.Function:
                    return 4;
                case Type.Comma:
                    return 0;
            }
            switch (sym.m_name)
            {
                case "^":
                    return 3;
                case "/":
                case "*":
                case "%":
                    return 2;
                case "+":
                case "-":
                    return 1;
            }
            return -1;
        }

        protected Symbol Evaluate(Symbol sym1, Symbol opr, Symbol sym2)
        {
            Symbol result;
            result.m_name = sym1.m_name + opr.m_name + sym2.m_name;
            result.m_type = Type.Result;
            result.m_value = 0;
            switch (opr.m_name)
            {
                case "^":
                    result.m_value = System.Math.Pow(sym1.m_value, sym2.m_value);
                    break;
                case "/":
                    {
                        //if(sym2.m_value > 0)
                        result.m_value = sym1.m_value / sym2.m_value;
                        //else
                        {
                            //  result.m_name = "Divide by Zero.";
                            //  result.m_type = Type.Error;
                        }
                        break;
                    }
                case "*":
                    result.m_value = sym1.m_value * sym2.m_value;
                    break;
                case "%":
                    result.m_value = sym1.m_value % sym2.m_value;
                    break;
                case "+":
                    result.m_value = sym1.m_value + sym2.m_value;
                    break;
                case "-":
                    result.m_value = sym1.m_value - sym2.m_value;
                    break;
                default:
                    result.m_type = Type.Error;
                    result.m_name = "Không xác định được toán tử " + opr.m_name + ".";
                    break;
            }
            return result;
        }

        protected Symbol EvaluateFunction(string name, params Object[] args)
        {
            Symbol result;
            result.m_name = "";
            result.m_type = Type.Result;
            result.m_value = 0;
            switch (name)
            {
                case "cos":
                    if (args.Length == 1)
                    {
                        result.m_name = name + "(" + ((Symbol)args[0]).m_value.ToString() + ")";
                        result.m_value = System.Math.Cos(((Symbol)args[0]).m_value);

                    }
                    else
                    {
                        result.m_name = "Tham số không đúng: " + name + ".";
                        result.m_type = Type.Error;
                        
                    }
                    break;
                case "sin":
                    if (args.Length == 1)
                    {
                        result.m_name = name + "(" + ((Symbol)args[0]).m_value.ToString() + ")";
                        result.m_value = System.Math.Sin(((Symbol)args[0]).m_value);
                    }
                    else
                    {
                        result.m_name = "Tham số không đúng: " + name + ".";
                        result.m_type = Type.Error;
                    }
                    break;
                case "tan":
                    if (args.Length == 1)
                    {
                        result.m_name = name + "(" + ((Symbol)args[0]).m_value.ToString() + ")";
                        result.m_value = System.Math.Tan(((Symbol)args[0]).m_value);
                    }
                    else
                    {
                        result.m_name = "Tham số không đúng: " + name + ".";
                        result.m_type = Type.Error;
                    }
                    break;
                case "cot":
                    if (args.Length == 1)
                    {
                        result.m_name = name + "(" + ((Symbol)args[0]).m_value.ToString() + ")";
                        result.m_value = 1.0f/(System.Math.Tan(((Symbol)args[0]).m_value));
                    }
                    else
                    {
                        result.m_name = "Tham số không đúng: " + name + ".";
                        result.m_type = Type.Error;
                    }
                    break;
                case "cosh":
                    if (args.Length == 1)
                    {
                        result.m_name = name + "(" + ((Symbol)args[0]).m_value.ToString() + ")";
                        result.m_value = System.Math.Cosh(((Symbol)args[0]).m_value);
                    }
                    else
                    {
                        result.m_name = "Tham số không đúng: " + name + ".";
                        result.m_type = Type.Error;
                    }
                    break;
                case "sinh":
                    if (args.Length == 1)
                    {
                        result.m_name = name + "(" + ((Symbol)args[0]).m_value.ToString() + ")";
                        result.m_value = System.Math.Sinh(((Symbol)args[0]).m_value);
                    }
                    else
                    {
                        result.m_name = "Tham số không đúng: " + name + ".";
                        result.m_type = Type.Error;
                    }
                    break;
                case "tanh":
                    if (args.Length == 1)
                    {
                        result.m_name = name + "(" + ((Symbol)args[0]).m_value.ToString() + ")";
                        result.m_value = System.Math.Tanh(((Symbol)args[0]).m_value);
                    }
                    else
                    {
                        result.m_name = "Tham số không đúng: " + name + ".";
                        result.m_type = Type.Error;
                    }
                    break;
                case "coth":
                    if (args.Length == 1)
                    {
                        result.m_name = name + "(" + ((Symbol)args[0]).m_value.ToString() + ")";
                        result.m_value = System.Math.Cosh(((Symbol)args[0]).m_value)/ System.Math.Sinh(((Symbol)args[0]).m_value);
                    }
                    else
                    {
                        result.m_name = "Tham số không đúng: " + name + ".";
                        result.m_type = Type.Error;
                    }
                    break;
                case "log":
                    if (args.Length == 1)
                    {
                        result.m_name = name + "(" + ((Symbol)args[0]).m_value.ToString() + ")";
                        result.m_value = System.Math.Log10(((Symbol)args[0]).m_value);
                    }
                    else
                    {
                        result.m_name = "Tham số không đúng: " + name + ".";
                        result.m_type = Type.Error;
                    }
                    break;
                case "ln":
                    if (args.Length == 1)
                    {
                        result.m_name = name + "(" + ((Symbol)args[0]).m_value.ToString() + ")";
                        result.m_value = System.Math.Log(((Symbol)args[0]).m_value, 2);
                    }
                    else
                    {
                        result.m_name = "Tham số không đúng: " + name + ".";
                        result.m_type = Type.Error;
                    }
                    break;
                case "sqrt":
                    if (args.Length == 1)
                    {
                        result.m_name = name + "(" + ((Symbol)args[0]).m_value.ToString() + ")";
                        result.m_value = System.Math.Sqrt(((Symbol)args[0]).m_value);
                    }
                    else
                    {
                        result.m_name = "Tham số không đúng: " + name + ".";
                        result.m_type = Type.Error;
                    }
                    break;
                case "sqr":
                    if (args.Length == 1)
                    {
                        result.m_name = name + "(" + ((Symbol)args[0]).m_value.ToString() + ")";
                        result.m_value = System.Math.Pow(((Symbol)args[0]).m_value,2);
                    }
                    else
                    {
                        result.m_name = "Tham số không đúng: " + name + ".";
                        result.m_type = Type.Error;
                    }
                    break;
                case "abs":
                    if (args.Length == 1)
                    {
                        result.m_name = name + "(" + ((Symbol)args[0]).m_value.ToString() + ")";
                        result.m_value = System.Math.Abs(((Symbol)args[0]).m_value);
                    }
                    else
                    {
                        result.m_name = "Tham số không đúng: " + name + ".";
                        result.m_type = Type.Error;
                    }
                    break;
                case "arccos":
                    if (args.Length == 1)
                    {
                        result.m_name = name + "(" + ((Symbol)args[0]).m_value.ToString() + ")";
                        result.m_value = System.Math.Acos(((Symbol)args[0]).m_value);
                    }
                    else
                    {
                        result.m_name = "Tham số không đúng: " + name + ".";
                        result.m_type = Type.Error;
                    }
                    break;
                case "arcsin":
                    if (args.Length == 1)
                    {
                        result.m_name = name + "(" + ((Symbol)args[0]).m_value.ToString() + ")";
                        result.m_value = System.Math.Asin(((Symbol)args[0]).m_value);
                    }
                    else
                    {
                        result.m_name = "Tham số không đúng: " + name + ".";
                        result.m_type = Type.Error;
                    }
                    break;
                case "arctan":
                    if (args.Length == 1)
                    {
                        result.m_name = name + "(" + ((Symbol)args[0]).m_value.ToString() + ")";
                        result.m_value = System.Math.Atan(((Symbol)args[0]).m_value);
                    }
                    else
                    {
                        result.m_name = "Tham số không đúng: " + name + ".";
                        result.m_type = Type.Error;
                    }
                    break;
                case "exp":
                    if (args.Length == 1)
                    {
                        result.m_name = name + "(" + ((Symbol)args[0]).m_value.ToString() + ")";
                        result.m_value = System.Math.Exp(((Symbol)args[0]).m_value);
                    }
                    else
                    {
                        result.m_name = "Tham số không đúng: " + name + ".";
                        result.m_type = Type.Error;
                    }
                    break;
                default:
                    if (m_defaultFunctionEvaluation != null)
                        result = m_defaultFunctionEvaluation(name, args);
                    else
                    {
                        result.m_name = "Không tìm thấy hàm: " + name + ".";
                        result.m_type = Type.Error;
                    }
                    break;
            }
            return result;
        }
    }
}
