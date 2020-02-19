using Xunit;

namespace ScintillaNET.Tests
{
    public class MainTests
    {
        [Fact]
        public void CanInstantiateControl()
        {
            var scintilla = new Scintilla();
        }
    }
}
