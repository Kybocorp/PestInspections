using System;
using CroydonPestControl.Core.Helpers;
using System.IO;
using System.Xml.Serialization;
using Microsoft.Extensions.Logging;

namespace CroydonPestControl.Core
{
    public class XmlHelper: IXmlHelper
    {

        private readonly ILogger<XmlHelper> _logger;
        public XmlHelper(ILogger<XmlHelper> logger)
        {
            _logger = logger;
        }
        public T ConvertFromXml<T>(string xml) where T : class
        {
            T returnedXmlClass = default(T);

            try
            {
                using (TextReader reader = new StringReader(xml))
                {
                    try
                    {
                        XmlRootAttribute xRoot = new XmlRootAttribute();
                        xRoot.ElementName = "Config";
                        xRoot.IsNullable = true;
                        returnedXmlClass = (T)new XmlSerializer(typeof(T), xRoot).Deserialize(reader);
                    }
                    catch (InvalidOperationException ex)
                    {
                        _logger.LogError(ex.Message);
                        // String passed is not XML, simply return defaultXmlClass
                    }
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
            }

            return returnedXmlClass;
        }

        public string ConvertToXml<T>(T dataObject) where T : class
        {
            if (dataObject == null)
            {
                return string.Empty;
            }
            try
            {
                using (StringWriter stringWriter = new StringWriter())
                {
                    var serializer = new XmlSerializer(typeof(T));
                    serializer.Serialize(stringWriter, dataObject);
                    return stringWriter.ToString();
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return string.Empty;
            }
        }

    }
}
