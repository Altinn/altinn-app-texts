using Altinn.AppTexts.Controllers;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc.Testing;
using System.Collections.Generic;
using System.Text.Json;
using Xunit;

namespace Altinn.AppTexts.Tests
{
    public class TextsControllerTests : IClassFixture<WebApplicationFactory<TextsController>>
    {
        private readonly WebApplicationFactory<TextsController> _factory;

        public TextsControllerTests(WebApplicationFactory<TextsController> factory)
        {
            _factory = factory;
        }

        [Fact]
        public async void Get_ZeroTextsDefined_ShouldReturnOkWithEmptyList()
        {
            var client = _factory.CreateClient();

            var response = await client.GetAsync("texts/api/v1/texts");
            var textsJson = await response.Content.ReadAsStringAsync();
            var texts = JsonSerializer.Deserialize<Dictionary<string, string>>(textsJson);

            response.StatusCode.Should().Be(System.Net.HttpStatusCode.OK);
            texts.Should().HaveCount(0);
        }
    }
}