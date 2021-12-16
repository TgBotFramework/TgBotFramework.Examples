using TgBotFramework;

namespace SimpleConsole;

public interface IFirstContext : IUpdateContext
{
    int Value { get; set; }
}

public interface ISecondContext : IUpdateContext
{
    int OtherValue { get; set; }
}

public class ComplexContext : BaseUpdateContext, IFirstContext, ISecondContext 
{
    public int Value { get; set; }
    public int OtherValue { get; set; }
}