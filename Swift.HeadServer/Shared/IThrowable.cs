using System;

namespace Swift.HeadServer.Shared
{
    public interface IThrowable
    {
        void ThrowIf(bool condition, Exception ex = null, string message = "");
        void ThrowUnless(bool condition, Exception ex = null, string message = "");
    }
}