using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Xml;

namespace XLF_ChangingNodes
{
    public class Utilities
    {   
        /*
         * 
         */
        static public XmlNodeList GetNodesByTagName(XmlDocument xmlDocument, string tagName)
        {
            XmlNodeList foundNodes = null;

            if (xmlDocument != null)
            {
                foundNodes = xmlDocument.GetElementsByTagName(tagName);
            }

            return foundNodes;
        }

        static public XmlNodeList GetTransUnitNodes(XmlDocument xmlDocument)
        {
            return GetNodesByTagName(xmlDocument, "trans-unit");
        }

        static public XmlNodeList GetSourceNodes(XmlDocument xmlDocument)
        {
            return GetNodesByTagName(xmlDocument, "source");
        }

        static public XmlNodeList GetTargetNodes(XmlDocument xmlDocument)
        {
            return GetNodesByTagName(xmlDocument, "target");
        }

        /*
         * 
         */
        static public XmlNodeList GetNodesContaining(XmlDocument xmlDocument, string tagName, string containedText)
        {
            XmlNodeList foundNodes = null;

            string tagNameXPath = "//" + tagName;
            string limitedTagNameXPath = tagNameXPath + "[contains(., '" + containedText + "')]";

            if (xmlDocument != null)
            {
                foundNodes = xmlDocument.SelectNodes(limitedTagNameXPath);
            }

            return foundNodes;
        }

        static public XmlNodeList GetSourceNodesContaining(XmlDocument xmlDocument, string containedText)
        {
            return GetNodesContaining(xmlDocument, "source", containedText);
        }

        static public XmlNodeList GetTargetNodesContaining(XmlDocument xmlDocument, string containedText)
        {
            return GetNodesContaining(xmlDocument, "target", containedText);
        }


        /*
         * 
         */
        static public XmlNodeList GetTransUnitNodesContainingInSource(XmlDocument xmlDocument, string containedText)
        {
            XmlNodeList foundNodes = null;

            string limitedTagNameXPath = "//source" + "[contains(., '" + containedText + "')]/parent::trans-unit";

            if (xmlDocument != null)
            {
                foundNodes = xmlDocument.SelectNodes(limitedTagNameXPath);
            }

            return foundNodes;
        }

        /*
         * 
         */
        static public XmlNodeList GetTransUnitNodesContainingInTarget(XmlDocument xmlDocument, string containedText)
        {
            XmlNodeList foundNodes = null;

            string limitedTagNameXPath = "//target" + "[contains(., '" + containedText + "')]/parent::trans-unit";

            if (xmlDocument != null)
            {
                foundNodes = xmlDocument.SelectNodes(limitedTagNameXPath);
            }

            return foundNodes;
        }

    }
}
