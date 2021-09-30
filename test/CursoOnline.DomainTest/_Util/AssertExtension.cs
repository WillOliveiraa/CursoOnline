using System;
using Xunit;

namespace CursoOnline.DomainTest._Util
{
    public static class AssertExtension
    {
        public static void ComMensagem(this ArgumentException exception, string mensagem)
        {
            if (exception.Message == mensagem)
                Assert.True(true);
            else
                Assert.False(false, $"Esperava a mensagem '{mensagem}'");
        }
    }
}
