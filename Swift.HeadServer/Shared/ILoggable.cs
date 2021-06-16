using System;

namespace Swift.HeadServer.Shared
{
    public interface ILoggable
    {
        void Error(string message);
        void Warning(string message);
        void Debug(string message);
        void Success(string message);
    }
}