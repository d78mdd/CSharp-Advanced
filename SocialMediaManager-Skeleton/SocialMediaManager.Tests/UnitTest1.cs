using System;
using NUnit.Framework;
using System.Linq;
using System.Collections.Generic;
using Microsoft.VisualStudio.CodeCoverage;

namespace SocialMediaManager.Tests
{
    public class Tests
    {
        [Test]
        public void RegisterInfluencer_ThrowsException_WhenArgumentNull()
        {
            InfluencerRepository repository = new InfluencerRepository();

            Assert.That(
                () => repository.RegisterInfluencer(null),
                Throws.ArgumentNullException
            );
        }

        [Test]
        public void RegisterInfluencer_ThrowsException_WhenInfluencerExists()
        {
            InfluencerRepository repository = new InfluencerRepository();

            Influencer influencer = new Influencer("him", 0);
            repository.RegisterInfluencer(influencer);

            Assert.That(
                () => repository.RegisterInfluencer(influencer),
                Throws.InvalidOperationException
            );
        }

        [Test]
        public void RegisterInfluencer_Succeeds()
        {
            InfluencerRepository repository = new InfluencerRepository();

            Influencer influencer = new Influencer("him", 0);

            string result = repository.RegisterInfluencer(influencer);

            Assert.AreEqual("Successfully added influencer him with 0", result);
            Assert.AreEqual(1, repository.Influencers.Count);
        }





        [Test]
        public void RemoveInfluencer_ThrowsException()
        {
            InfluencerRepository repository = new InfluencerRepository();

            Influencer influencer = new Influencer("him", 0);
            repository.RegisterInfluencer(influencer);

            Assert.That(
                () => repository.RemoveInfluencer(""),
                Throws.ArgumentNullException
            );
        }

        [Test]
        public void RemoveInfluencer_ThrowsException_WhenWhitespaces()
        {
            InfluencerRepository repository = new InfluencerRepository();

            Influencer influencer = new Influencer("him", 0);
            repository.RegisterInfluencer(influencer);

            Assert.That(
                () => repository.RemoveInfluencer("  "),
                Throws.ArgumentNullException
            );
        }

        [Test]
        public void RemoveInfluencer_ThrowsException_WhenNull()
        {
            InfluencerRepository repository = new InfluencerRepository();

            Influencer influencer = new Influencer("him", 0);
            repository.RegisterInfluencer(influencer);

            Assert.That(
                () => repository.RemoveInfluencer(null),
                Throws.ArgumentNullException
            );
        }

        [Test]
        public void RemoveInfluencer_Succeeds()
        {
            InfluencerRepository repository = new InfluencerRepository();

            Influencer influencer = new Influencer("him", 0);

            repository.RegisterInfluencer(influencer);

            bool result = repository.RemoveInfluencer("him");

            Assert.AreEqual(true, result);
            Assert.AreEqual(0, repository.Influencers.Count);
        }




        [Test]
        public void GetInfluencerWithMostFollowers_Succeeds()
        {
            InfluencerRepository repository = new InfluencerRepository();

            Influencer influencer1 = new Influencer("him", 1);
            Influencer influencer2 = new Influencer("her", 3);
            Influencer influencer3 = new Influencer("another", 2);

            repository.RegisterInfluencer(influencer1);
            repository.RegisterInfluencer(influencer2);
            repository.RegisterInfluencer(influencer3);

            Influencer result = repository.GetInfluencerWithMostFollowers();

            Assert.AreEqual(3, result.Followers);
        }

        //[Test]
        //public void GetInfluencerWithMostFollowers_ThrowsException_WhenNone()
        //{
        //    InfluencerRepository repository = new InfluencerRepository();

        //    Assert.That(
        //        () => repository.GetInfluencerWithMostFollowers(),
        //        Throws.ArgumentException  // cant use IndexOutOfRangeException
        //    );

        //}







        [Test]
        public void GetInfluencer_Succeeds()
        {
            InfluencerRepository repository = new InfluencerRepository();

            Influencer influencer1 = new Influencer("him", 1);

            repository.RegisterInfluencer(influencer1);

            Influencer result = repository.GetInfluencer("him");

            Assert.AreEqual(influencer1.Username, result.Username);
        }

        [Test]
        public void GetInfluencer_ReturnsNull()
        {
            InfluencerRepository repository = new InfluencerRepository();

            Influencer influencer1 = new Influencer("him", 1);

            repository.RegisterInfluencer(influencer1);

            Influencer result = repository.GetInfluencer("another");

            Assert.AreEqual(null, result);
        }





        [Test]
        public void Constructor_Succeeds()
        {
            InfluencerRepository repository = new InfluencerRepository();

            Assert.AreNotEqual(null, repository.Influencers);
        }





    }
}