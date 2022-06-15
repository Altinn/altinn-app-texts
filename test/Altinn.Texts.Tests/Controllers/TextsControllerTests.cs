using Altinn.Texts.Controllers;
using FluentAssertions;
using System.Collections.Generic;
using Xunit;

namespace Altinn.Texts.Tests
{
    public class TextsControllerTests
    {
        [Fact]
        public async void Get_ZeroTextsDefined_ReturnsEmptyDictionary()
        {
            var controller = new TextsController();

            var texts = await controller.Get();

            texts.Value.Should().HaveCount(0);
        }
    }
}