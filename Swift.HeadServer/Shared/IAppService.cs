using System;

namespace Swift.HeadServer.Shared
{
    public interface IAppService
    {
        string Name();
        Version Version();
    }
}