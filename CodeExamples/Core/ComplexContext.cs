using TgBotFramework;

namespace CodeExamples;

public interface IFirstContext 
{
    int Value { get; set; }
}

public interface ISecondContext 
{
    int OtherValue { get; set; }
}

public class ComplexContext : UpdateContext, IFirstContext, ISecondContext 
{
    public int Value { get; set; }
    public int OtherValue { get; set; }
}