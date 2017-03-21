namespace Randomizer.Interfaces
{
    public interface IRandomRefType<out TReturn>
    {
        TReturn GenerateValue();
    }
}
