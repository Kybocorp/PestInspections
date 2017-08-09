namespace CroydonPestControl.Core.Helpers
{
    public interface IXmlHelper
    {
        T ConvertFromXml<T>(string xml) where T : class;
        string ConvertToXml<T>(T dataObject) where T : class;
    }
}
