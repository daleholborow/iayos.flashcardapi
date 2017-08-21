using iayos.flashcardapi.ServiceModel.DeckCategory;
using Xunit;

namespace iayos.flashcardapi.Api.Test
{
	public class TestListDeckCategoriesByApplication : ApiUnitTester
	{
		[Fact]
		public void DoATest()
		{
			var result = JsonServiceClient.Get(new ListDeckCategoriesByApplicationRequest());

			Assert.True(false);
		}
	}
}
