using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentAssertions;
using PatikaMovieStore.Applications.GenreOperations.Commands.UpdateGenre;
using PatikaMovieStore.DBOperations;
using PatikaMovieStore.Entities;
using TestSetup;
using Xunit;

namespace PatikaMovieStore.Application.GenreOperations
{
     public class UpdateGenreCommandTests : IClassFixture<CommonTestFixture>
    {
        private readonly MovieStoreDbContext _context;

        public UpdateGenreCommandTests(CommonTestFixture testFixture)
        {
            _context = testFixture.Context;
        }

        [Fact]
        public void WhenAlreadyExistGenreIdIsGiven_InvalidOperationException_ShouldBeReturn()
        {
            // Arrange (Hazırlık)
            UpdateGenreCommand command = new UpdateGenreCommand(_context);
            command.GenreId = 0;

            // act & asset (Çalıştırma ve Doğrulama)
            FluentActions
                .Invoking(() => command.Handle())
                .Should().Throw<InvalidOperationException>();

        }

        [Fact]
        public void WhenGivenNameIsSameWithAnotherGenre_InvalidOperationException_ShouldBeReturn()
        {
            var genre = new Genre(){Name= "Romancee" };
            _context.Genres.Add(genre);
            _context.SaveChanges();

            UpdateGenreCommand command = new UpdateGenreCommand(_context);
            command.GenreId=2;
            command.Model=new UpdateGenreModel(){Name= "Romancee" };

            FluentActions.Invoking(() => command.Handle()).Should().Throw<InvalidOperationException>();
        }

        
    }
}