﻿using System;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Xml;
using System.Xml.Serialization;
using System.Xml.Xsl;
using TechTalk.SpecFlow.Generator.Configuration;

namespace TechTalk.SpecFlow.Reporting
{
    internal static class XsltHelper
    {
        public static bool IsXmlOutput(string outputFilePath)
        {
            return Path.GetExtension(outputFilePath).Equals(".xml", StringComparison.InvariantCultureIgnoreCase);
        }

        public static void TransformXml(XmlSerializer serializer, object report, string outputFilePath)
        {
            string xmlOutputPath = Path.ChangeExtension(outputFilePath, ".xml");

            using (var writer = new StreamWriter(xmlOutputPath, false, Encoding.UTF8))
            {
                serializer.Serialize(writer, report);
            }
        }

        public static void TransformHtml(XmlSerializer serializer, object report, Type reportType, string outputFilePath, GeneratorConfiguration generatorConfiguration)
        {
            var xmlOutputWriter = new StringWriter();
            serializer.Serialize(xmlOutputWriter, report);

            XslCompiledTransform xslt = new XslCompiledTransform();

            var xsltSettings = new XsltSettings(true, false);
            var resourceResolver = new XmlResourceResolver();

            var reportName = reportType.Name.Replace("Generator", "");
            using (var xsltReader = new ResourceXmlReader(reportType, reportName + ".xslt"))
            {
				xslt.Load(xsltReader, xsltSettings, resourceResolver);
            }

            var xmlOutputReader = new XmlTextReader(new StringReader(xmlOutputWriter.ToString()));

            XsltArgumentList argumentList = new XsltArgumentList();
            argumentList.AddParam("feature-language", "", generatorConfiguration.FeatureLanguage.Name);
            argumentList.AddParam("tool-language", "", generatorConfiguration.ToolLanguage.Name);
            
			using (var outFileStream = new FileStream(outputFilePath, FileMode.Create, FileAccess.Write))
			using (var xmlTextWriter = new XmlTextWriter(outFileStream, Encoding.UTF8))
            {
				xslt.Transform(xmlOutputReader, argumentList, xmlTextWriter, resourceResolver);
            }            
        }
    }
}
