using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using NUnit.Framework;
using Amazon.S3;
using Amazon.S3.Model;

[TestFixture]
[Category("Storage Test")]
internal class StorageTest
{

    [Test]
    [Category("IdcfTest")]
    async void IdcfTest()
    {
        using (var s3 = new AmazonS3Client(new Amazon.Runtime.BasicAWSCredentials("accessKey", "secretKey")))
        {
            var result = await s3.PutObjectAsync(new PutObjectRequest
            {
                BucketName = "",
                Key = "/a.text",
                FilePath = "a.text",
            });
        }
    }


}
