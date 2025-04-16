using System;
using System.Threading;
using System.Threading.Tasks;
using FluentAssertions;
using NSubstitute;
using Taxually.TechnicalTest.Enums;
using Taxually.TechnicalTest.Handlers;
using Taxually.TechnicalTest.Interfaces.Commands;
using Taxually.TechnicalTest.UnitTests.Builders;
using Xunit;

namespace Taxually.TechnicalTest.UnitTests
{
    public class VatRegistrationCommandHandlerTests
    {
        [Fact]
        public async Task Handle_ShouldReturnSuccessResponse_WhenRegistrationIsSuccessful()
        {
            // Arrange
            var command = new VatRegistrationCommandBuilder()
                .WithCountry("FR")
                .Build();

            var sut = new VatRegistrationCommandHandlerBuilder().Build();

            // Act
            var result = await sut.Handle(command, CancellationToken.None);

            // Assert
            result.IsSuccess.Should().BeTrue();
            result.Message.Should().Be("VAT Registration request sent successfully.");
        }


        [Fact]
        public async Task Handle_ShouldReturnErrorResponse_WhenCountryIsNotSupported()
        {
            // Arrange
            var command = new VatRegistrationCommandBuilder()
                .WithCountry("XX")
                .Build();

            var sut = new VatRegistrationCommandHandlerBuilder().Build();

            // Act
            var result = await sut.Handle(command, CancellationToken.None);

            // Assert
            result.IsSuccess.Should().BeFalse();
        }
    }
}