using System;
using System.Collections.Generic;
using System.IO;
using System.Xml.Linq;
using YamlDotNet.Serialization;
using YamlDotNet.Serialization.NamingConventions;

namespace ServiceFabricManifests
{
    class Program
    {
        static void Main(string[] args)
        {
            Manifest manifest;
            manifest = ReadManifest();

            Console.WriteLine(manifest.Application.Name);
            Console.ReadLine();
        }

        private static Manifest ReadManifest()
        {
            Manifest app;
            using (var input = new StreamReader("sample.yaml"))
            {
                var deserializer = new DeserializerBuilder()
                    .WithNamingConvention(new CamelCaseNamingConvention())
                    .Build();

                app = deserializer.Deserialize<Manifest>(input);
            }

            return app;
        }
    }

    public class Manifest
    {
        public Application Application { get; set; }
    }

    public class Application
    {
        public string Name { get; set; }
        public IEnumerable<Parameter> Parameters { get; set; }
        public IEnumerable<Service> Services { get; set; }
    }

    public class Parameter
    {
        public string Name { get; set; }
    }

    public class Service
    {
        public string Name { get; set; }
        public IEnumerable<EnvironmentVariable> EnvironmentVariables { get; set; }
        public IEnumerable<Extension> Extensions { get; set; }
        public GuestExe GuestExe { get; set; }
        public IEnumerable<Endpoint> Endpoints { get; set; }
    }

    public class EnvironmentVariable
    {
        public string Name { get; set; }
        public string Value { get; set; }
        public string ParameterValue { get; set; }        
    }    

    public class Extension
    {
        public string Name { get; set; }
        public XDocument XmlValue { get; set; }
    }

    public class GuestExe
    {
        public string SourceDir { get; set; }
        public string Program { get; set; }        
    }

    public class Endpoint
    {
        public string Name { get; set; }
        public string UriScheme { get; set; }
        public int Port { get; set; }
    }
}
