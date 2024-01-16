using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using FluentAssertions;
using PatikaMovieStore.Applications.GenreOperations.Commands.CreateGenre;
using PatikaMovieStore.DBOperations;
using PatikaMovieStore.Entities;
using TestSetup;
using Xunit;

namespace PatikaMovieStore.Application.GenreOperations
{
   public class CreateGenreCommandTests : IClassFixture<CommonTestFixture>
    {
        private readonly MovieStoreDbContext _context;
        private readonly IMapper _mapper;

        public CreateGenreCommandTests(CommonTestFixture testFixture)
        {
            _context = testFixture.Context;
            _mapper = testFixture.Mapper;
        }

        [Fact]
        public void WhenAlreadyExistGenreNameIsGiven_InvalidOperationException_ShouldBeReturn()
        {
            // Arrange (Hazırlık)
            var genre = new Genre() {Name = "WhenAlreadyExistGenreNameIsGiven_InvalidOperationException_ShouldBeReturn"};
            _context.Genres.Add(genre);
            _context.SaveChanges();

            CreateGenreCommand command = new CreateGenreCommand(_context);
            command.Model = new CreateGenreModel() {Name = genre.Name};
            // act & asset (Çalıştırma ve Doğrulama)
            FluentActions
                .Invoking(() => command.Handle())
                .Should().Throw<InvalidOperationException>();

        }


        [Fact]
        public void WhenValidInputsAreGiven_Genre_ShouldBeCreated()
        {
            //arrange
            CreateGenreCommand command = new CreateGenreCommand(_context);
            command.Model=new CreateGenreModel(){Name="WhenValidInputIsGiven_Genre_ShouldBeCreated"};
            
            FluentActions.Invoking(()=> command.Handle()).Invoke();

            var genre=_context.Genres.SingleOrDefault(genre=>genre.Name == command.Model.Name);
            genre.Should().NotBeNull();


        }

        
    }
}