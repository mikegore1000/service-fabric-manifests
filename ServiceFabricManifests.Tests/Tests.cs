﻿using System;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
using ServiceFabricManifests.Input;
using ServiceFabricManifests.Output;
using Parameter = ServiceFabricManifests.Input.Parameter;

namespace ServiceFabricManifests.Tests
{
    [TestFixture]
    public class ApplicationManifestGeneratorTests
    {
        [Test]
        public void given_a_manifest_with_no_services_and_no_parameters_an_application_manifest_is_created()
        {
            var input = new Manifest();
            input.Application = new Application();
            input.Application.Name = "TestApp";
            input.Application.Version = Version.Parse("1.0.0");
            input.Application.Parameters = new Parameter[] {};

            var output = new ApplicationManifestGenerator().Generate(input);

            Assert.That(output, Is.Not.Null);
            Assert.That(output.Name, Is.EqualTo(input.Application.Name));
            Assert.That(output.ApplicationTypeVersion, Is.EqualTo(input.Application.Version));
            Assert.That(output.Parameters, Has.Count.EqualTo(input.Application.Parameters.Count()));
        }
    }
}
