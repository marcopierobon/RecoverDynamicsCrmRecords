using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net.Configuration;
using System.ServiceModel.Description;
using System.Text;
using System.Xml;
using Microsoft.Xrm.Sdk.Client;

namespace RestoreRecords
{
    class CrmConnection
    {
        private readonly string _filePath;
        public Hashtable HashTable { get; private set; }
        public OrganizationServiceProxy Service { get; set; }

        public CrmConnection(string filePath)
        {
            this._filePath = filePath;
            HashTable = GetSettings(filePath);
            Connect(HashTable);
        }

        

        private void Connect(IDictionary hashTable)
        {
            //parameters to connect
            var credentials = new ClientCredentials();
            credentials.UserName.UserName = hashTable["domain"] + @"\" + hashTable["username"];
            credentials.UserName.Password = hashTable["password"].ToString();
            //URI of the organisation service
            var organizationUri = new Uri(hashTable["organizationUri"].ToString());
            //URI of the cross realm STS metadata endpoint
            var homeRealmUri = hashTable["homeRealmUri"].ToString().Equals("") ? null : new Uri(hashTable["homeRealmUri"].ToString());
            //Connect to CRM
            Service = new OrganizationServiceProxy(organizationUri, homeRealmUri, credentials, null);
        }

        private static Hashtable GetSettings(string filePath)
        {
            var ret = new Hashtable();
            if (!File.Exists(filePath)) return (ret);
            XmlDocument doc;
            string xmlIn;
            using (var reader = new StreamReader(new FileStream(filePath, FileMode.Open, FileAccess.Read, FileShare.Read)))
            {
                doc = new XmlDocument();
                xmlIn = reader.ReadToEnd();
                reader.Close();
            }
            doc.LoadXml(xmlIn);
            foreach (XmlNode child in doc.ChildNodes)
                if (child.Name.Equals("Settings"))
                    foreach (XmlNode node in child.ChildNodes)
                        if (node.Name.Equals("add"))
                        {
                            Debug.Assert(node.Attributes != null, "node.Attributes != null");
                            ret.Add
                                (
                                    node.Attributes["key"].Value,
                                    node.Attributes["value"].Value
                                );
                        }
            return (ret);
        }

    }
}
