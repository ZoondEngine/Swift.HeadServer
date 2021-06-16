namespace Swift.HeadServer.Shared
{
    public interface ISharableAppFolders
    {
        string SystemFolder();
        string ConfigFolder();
        string LogFolder();
        string PluginsFolder();
    }
}