using System;
using System.Collections.Generic;
using AutoMapper;
using PatikaMovieStore.Applications.ActorOperations.Commands.CreateActor;
using PatikaMovieStore.Applications.ActorOperations.Queries.GetActorDetail;
using PatikaMovieStore.Applications.ActorOperations.Queries.GetActors;
using PatikaMovieStore.Applications.DirectorOperations.Commands.CreateDirector;
using PatikaMovieStore.Applications.DirectorOperations.Queries.GetDirectorDetail;
using PatikaMovieStore.Applications.DirectorOperations.Queries.GetDirectors;
using PatikaMovieStore.Applications.GenreOperations.Commands.CreateGenre;
using PatikaMovieStore.Applications.GenreOperations.Queries.GetGenreDetail;
using PatikaMovieStore.Applications.GenreOperations.Queries.GetGenres;
using PatikaMovieStore.Applications.UserOperations.Commands.CreateUser;
using PatikaMovieStore.Applications.UserOperations.Queries.GetUserDetail;
using PatikaMovieStore.Applications.UserOperations.Queries.GetUsers;
using PatikaMovieStore.Entities;
using static PatikaMovieStore.Applications.MovieOperations.Commands.CreateMovie.CreateMovieCommand;
using static PatikaMovieStore.Applications.MovieOperations.Queries.GetMovieDetail.GetMovieDetailQuery;
using static PatikaMovieStore.Applications.MovieOperations.Queries.GetMovies.GetMoviesQuery;
using static PatikaMovieStore.Applications.OrderOperations.Commands.CreateOrder.CreateOrderCommand;
using static PatikaMovieStore.Applications.OrderOperations.Queries.GetOrderDetail.GetOrderDetailQuery;
using static PatikaMovieStore.Applications.OrderOperations.Queries.GetOrders.GetOrdersQuery;

namespace WebAi.Common
{
  public class MappingProfile : Profile
  {
    public MappingProfile()
    {
      CreateMap<CreateMovieModel, Movie>();      
      CreateMap<Movie, MovieDetailViewModel>()
        .ForMember(dest => dest.Genre, opt => opt.MapFrom(src => src.Genre.Name))
        .ForMember(dest => dest.Director, opt => opt.MapFrom(src => src.Director.Name + " " + src.Director.LastName))
        .ForMember(dest => dest.Actors, opt => opt.MapFrom(src => returnActors(src.Actors)));
      CreateMap<Movie, MoviesViewModel>()
        .ForMember(dest => dest.Genre, opt => opt.MapFrom(src => src.Genre.Name))
        .ForMember(dest => dest.Director, opt => opt.MapFrom(src => src.Director.Name + " " + src.Director.LastName))
        .ForMember(dest => dest.Actors, opt => opt.MapFrom(src => returnActors(src.Actors)));

        CreateMap<CreateOrderModel, Order>();      
        CreateMap<Order, OrderDetailViewModel>()
          .ForMember(dest => dest.BuyerName, opt => opt.MapFrom(src => src.User.Name + " " + src.User.LastName))
          .ForMember(dest => dest.MovieGenre, opt => opt.MapFrom(src => src.Movie.Genre.Name))
          .ForMember(dest => dest.MovieName, opt => opt.MapFrom(src => src.Movie.Name))
          .ForMember(dest => dest.MoviePrice, opt => opt.MapFrom(src => src.Movie.Price + " $"));
        CreateMap<Order, OrdersViewModel>()
          .ForMember(dest => dest.BuyerName, opt => opt.MapFrom(src => src.User.Name + " " + src.User.LastName))
          .ForMember(dest => dest.MovieGenre, opt => opt.MapFrom(src => src.Movie.Genre.Name))
          .ForMember(dest => dest.MovieName, opt => opt.MapFrom(src => src.Movie.Name))
          .ForMember(dest => dest.MoviePrice, opt => opt.MapFrom(src => src.Movie.Price + " $"));

      CreateMap<Genre, GenresViewModel>();
      CreateMap<Genre, GenreDetailViewModel>();
      CreateMap<CreateGenreModel, Genre>();

      CreateMap<Actor, ActorsViewModel>();
      CreateMap<Actor, ActorDetailViewModel>();
      CreateMap<CreateActorModel, Actor>();

      CreateMap<Director, DirectorsViewModel>();
      CreateMap<Director, DirectorDetailViewModel>();
      CreateMap<CreateDirectorModel, Director>();

      CreateMap<CreateUserModel, User>();
      CreateMap<User, UsersViewModel>()
        .ForMember(dest => dest.Genres, opt => opt.MapFrom(src => returnGenres(src.Genres)))
        .ForMember(dest => dest.Movies, opt => opt.MapFrom(src => returnMovies(src.Movies)));
      CreateMap<User, UserDetailViewModel>();
    }
    public List<string> returnActors(List<Actor> actors)
    {
      List<string> actorNames = new List<string>();
      foreach(Actor actor in actors)
      {
        actorNames.Add(actor.Name + " " + actor.LastName);
      }
      return actorNames;
    }

    public List<string> returnGenres(List<Genre> genres)
    {
      List<string> genreNames = new List<string>();
      foreach(Genre genre in genres)
      {
        genreNames.Add(genre.Name);
      }
      return genreNames;
    }
    public List<string> returnMovies(List<Movie> movies)
    {
      List<string> movieNames = new List<string>();
      foreach(Movie movie in movies)
      {
        movieNames.Add(movie.Name);
      }
      return movieNames;
    }
  }
}