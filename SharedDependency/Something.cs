using System.ComponentModel.Composition;
using SharedDependency.Common;

namespace SharedDependency
{
    [Export(typeof(IDoSomething))]
    public class Something : IDoSomething
    {
        public string DoSomething(int number)
        {
            return $"I do something {number}!";
        }
    }
}
