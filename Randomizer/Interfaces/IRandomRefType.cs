namespace Randomizer.Interfaces
{
    public interface IRandomRefType<in TInput,out TReturn>
    {
        TReturn GenerateValue();

    }
}
