using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentAssertions;
using PatikaMovieStore.Applications.GenreOperations.Commands.DeleteGenre;
using TestSetup;
using Xunit;

namespace PatikaMovieStore.Application.GenreOperations
{
     public class DeleteGenreCommandValidatorTests : IClassFixture<CommonTestFixture>
    {
       
        [Theory]
        [InlineData(0)]
        [InlineData(-1)]
        public void WhenInvalidGenreIdIsGiven_Validator_ShouldBeReturnErrors(int genreid)
        {
            //arrange
            DeleteGenreCommand command = new DeleteGenreCommand(null!);
            command.GenreId = genreid;
            
            //act
            DeleteGenreCommandValidator validator = new DeleteGenreCommandValidator();
            var result = validator.Validate(command);

            //assert
            result.Errors.Count.Should().BeGreaterThan(0);
           
        }

        [Theory]
        [InlineData(200)]
        [InlineData(2)]
        public void WhenInvalidGenreIdisGiven_Validator_ShouldNotBeReturnError(int genreid)
        {
            DeleteGenreCommand command = new DeleteGenreCommand(null!);
            command.GenreId = genreid;

            DeleteGenreCommandValidator validator = new DeleteGenreCommandValidator();
            var result = validator.Validate(command);

            result.Errors.Count.Should().Be(0);
            
        }

    }
}