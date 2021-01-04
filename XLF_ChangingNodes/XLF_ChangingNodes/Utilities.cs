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

        static public XmlNodeList GetNodesContaining(XmlDocument xlfDocument, string nodesName, string searchedText)
        {

            XmlNodeList searchedNodes = null;

            string nodesXPath = "//" + nodesName;
            string searchedNodesXPath = nodesXPath + "[contains(., '" + searchedText + "')]";

            if (xlfDocument != null)
            {
                if (xlfDocument.SelectNodes(nodesXPath).Count > 0)
                {
                    searchedNodes = xlfDocument.SelectNodes(searchedNodesXPath);
                    return searchedNodes;
                }
            }

            return searchedNodes;
        }

        static public XmlNodeList GetSourceNodesContaining(XmlDocument xlfDocument, string searchedText)
        {
            string xpathExpression = "//source[contains(., '" + searchedText + "')]";
            XmlNodeList sourceNodes = xlfDocument.SelectNodes(xpathExpression);

            return sourceNodes;
        }

        static public XmlNodeList GetTargetNodesContaining(XmlDocument xlfDocument, string searchedText)
        {
            string xpathExpression = "//target[contains(., '" + searchedText + "')]";
            XmlNodeList sourceNodes = xlfDocument.SelectNodes(xpathExpression);

            return sourceNodes;
        }

        static public XmlNodeList GetTransUnitNodesContaining(XmlDocument xlfDocument, string searchedText)
        {
            string xpathExpression = "//source[contains(., '" + searchedText + "')]" + "/parent::trans-unit";
            XmlNodeList sourceNodes = xlfDocument.SelectNodes(xpathExpression);

            return sourceNodes;
        }

    }
}
