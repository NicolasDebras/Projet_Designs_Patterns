using System;
using Designs_Patterns.Model;

namespace Designs_Patterns.Visitor
{
	public interface IVisitor
    {
        void Visit(PizzaProps pizza);
        void Visit(IngerdientsProps ingredient);
    }
}

