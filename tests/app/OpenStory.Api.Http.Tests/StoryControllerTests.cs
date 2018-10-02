using Bogus;
using FizzWare.NBuilder;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MockQueryable;
using MockQueryable.NSubstitute;
using Moq;
using OpenStory.Api.Data;
using OpenStory.Api.Services.Story;
using System.Collections.Generic;
using System.Linq;
using System.Threading;


namespace OpenStory.Api.Http.Tests
{
    [TestClass]
    public class StoryControllerTests
    {
        [TestMethod]
        public void ReturnsStoriesWithCorrectTitlesAuthorAndContent()
        {
            var mockRepository = new Mock<IDataRepository>();

            var fakeStories = new Faker<Story>()
                .RuleFor(u => u.Date, (f, u) => f.Date.Past())
                .RuleFor(u => u.Title, (f, u) => f.Lorem.Sentence())
                .RuleFor(u => u.BlobImagePath, f => f.Internet.Url());

            List<Story> stories = fakeStories.GenerateLazy(10).ToList();
            var storiesMock = Enumerable.Empty<Story>().AsQueryable();

            //var mock = new Mock<ICollection<Story>>();

            //mockRepository.As<IDataRepository>()
            //    .Setup(m => m.Get<Story>(null, default(CancellationToken), null))
            //    .Returns(new TestAsyncEnumerator<Story>(storiesMock.GetEnumerator()));


            //// build mock by extension
            //var mock = stories.AsQueryable().BuildMock();

            ////setup the mock as Queryable for Moq
            //mockRepository.Setup(x => x.Get<Story>(null, default(CancellationToken), null)).Returns(mock);

            //setup the mock as Queryable for NSubstitute
            //_userRepository.GetQueryable().Returns(mock);


            //mockRepository.Setup(x => x.Get<Story>(null, default(CancellationToken), null))
            //    .Returns(new Story { Content = "New Story" });

            //mockRepository.Setup(x => x.G(42))
            //    .Returns(new { Id = 42 });

            //var controller = new ProductsController(mockRepository.Object);

            //// Act
            //IHttpActionResult actionResult = controller.Get(42);
            //var contentResult = actionResult as OkNegotiatedContentResult<Product>;

            //// Assert
            //Assert.IsNotNull(contentResult);
            //Assert.IsNotNull(contentResult.Content);
            //Assert.AreEqual(42, contentResult.Content.Id);
        }

    }
}