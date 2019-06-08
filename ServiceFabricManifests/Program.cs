using System;
using System.IO;
using ServiceFabricManifests.Input;
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

    public class ApplicationManifestGenerator
    {
        public Output.ApplicationManifest Generate(Input.Manifest input)
        {
            var applicationManifest = new Output.ApplicationManifest(input.Application.Name, input.Application.Version);

            return applicationManifest;
        }
    }
}
