using System;
using System.Collections;
using System.Collections.Generic;

namespace ServiceFabricManifests.Output
{
    public class ApplicationManifest
    {
        public string Name { get; }

        public Version ApplicationTypeVersion { get; }

        public IEnumerable<Parameter> Parameters { get; set; }

        public ApplicationManifest(string name, Version applicationTypeVersion)
        {
            if(string.IsNullOrWhiteSpace(name))
                throw new ArgumentException("Name must be a non-empty string", nameof(name));

            if(applicationTypeVersion == null)
                throw new ArgumentException("ApplicationTypeVersion must be a valid semver version number", nameof(applicationTypeVersion));

            this.Name = name;
            this.ApplicationTypeVersion = applicationTypeVersion;
            this.Parameters = new List<Parameter>();
        }
    }

    public class Parameter
    {
        public string Name { get; set; }
    }
}