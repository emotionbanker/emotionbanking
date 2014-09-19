using System;
using Ciloci.Flee;
using compucare.Enquire.Legacy.Umfrage2Lib.System;

namespace Compucare.Enquire.Legacy.Umfrage2Lib.Script
{
    public class EnquireScript
    {
        public const String NA = "k.A.";

        private readonly ExpressionContext _context;
        private readonly EnquireScriptFunctionBase _fBase;

        public EnquireScript(Evaluation eval, TargetData td)
        {
            _fBase = new EnquireScriptFunctionBase(eval, td);
            _context = new ExpressionContext(_fBase);

            _context.Options.IntegersAsDoubles = false;
            _context.Options.CaseSensitive = false;
            _context.Options.OwnerMemberAccess = System.Reflection.BindingFlags.Public | System.Reflection.BindingFlags.NonPublic;
            _context.ParserOptions.RequireDigitsBeforeDecimalPoint = true;
            _context.ParserOptions.FunctionArgumentSeparator = ',';
            _context.Imports.AddType(typeof(Math));
        }

        public String Evaluate(String expression)
        {
            try
            {
                IDynamicExpression e = _context.CompileDynamic(expression);
                return e.Evaluate().ToString();
            }
            catch (DivideByZeroException)
            {
                return NA;
            }
        }

        public void SetUserGroup(PersonSetting ps)
        {
            _fBase.UserGroup = ps;
        }
    }
}
