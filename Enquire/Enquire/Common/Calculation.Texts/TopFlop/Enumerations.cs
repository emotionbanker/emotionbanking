using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Compucare.Enquire.Common.Calculation.Texts.TopFlop
{
     public enum ResultOrdering
     {
         Highest,
         Lowest
     }

    public enum ResultType
    {
        Averages,
        Gaps
    }

    public enum ResultSorting
    {
        CurrentOnly,
        Current,
        Historic,
        Change
    }

    public enum QuestionTopFlop
    {
        All,
        Select
    }
}
