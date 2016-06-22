namespace Randomizer.OutputTests
{
    public interface IOutpuTest
    {
        void ValidateConfitions();

        void PerformTest(object min, object max);
    }
}