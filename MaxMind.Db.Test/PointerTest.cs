﻿#region

using System.Collections.Generic;
using System.IO;
using System.Reflection;
using MaxMind.Db.Test.Helper;
using NUnit.Framework;

#endregion

namespace MaxMind.Db.Test
{
    [TestFixture]
    public class PointerTest
    {
        [Test]
        public void TestWithPointers()
        {
            var path = Path.Combine(TestUtils.TestDirectory, "TestData", "MaxMind-DB", "test-data", "maps-with-pointers.raw");

            using (var database = new ArrayBuffer(path))
            {
                var decoder = new Decoder(database, 0);

                long offset;
                var node = decoder.Decode<Dictionary<string, object>>(0, out offset);
                Assert.That(node["long_key"], Is.EqualTo("long_value1"));

                node = decoder.Decode<Dictionary<string, object>>(22, out offset);
                Assert.That(node["long_key"], Is.EqualTo("long_value2"));

                node = decoder.Decode<Dictionary<string, object>>(37, out offset);
                Assert.That(node["long_key2"], Is.EqualTo("long_value1"));

                node = decoder.Decode<Dictionary<string, object>>(50, out offset);
                Assert.That(node["long_key2"], Is.EqualTo("long_value2"));

                node = decoder.Decode<Dictionary<string, object>>(55, out offset);
                Assert.That(node["long_key"], Is.EqualTo("long_value1"));

                node = decoder.Decode<Dictionary<string, object>>(57, out offset);
                Assert.That(node["long_key2"], Is.EqualTo("long_value2"));
            }
        }
    }
}
