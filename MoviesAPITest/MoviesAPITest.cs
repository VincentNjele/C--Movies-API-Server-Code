using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration.UserSecrets;
using Moq;
using Serverside.WEB.Controllers;
using ServersideServices.DAL.Helpers;
using ServersideServices.DAL.Interfaces;
using ServersideServices.DAL.Models;
using System;
using Xunit;

namespace ServersideUnitTest
{
    public class MoviesAPITest
    {
        private readonly Mock<IService> checkRepository = new();


        [Fact]
        public void GetPopular_NullValue_Test()
        {


            checkRepository.Setup(repository => repository.GetPopular())
                .Returns((Result)null);

            var controllerAction = new MoviesController(checkRepository.Object);

            var result = controllerAction.GetPopular();


            result.Should().BeOfType<NotFoundResult>();


        }

        [Fact]
        public void OnGetPopulare_SuccessStatusCode()
        {
            //arrange
            checkRepository.Setup(repository => repository.GetPopular())
                .Returns(new SearchForMovieHelper().GetSearchResults());

            var controllerAction = new MoviesController(checkRepository.Object);

            //act
            var result = (OkObjectResult)controllerAction.GetPopular();

            //assert

            result.StatusCode.Should().Be(200);

        }

        [Fact]
        public void Check_If_GetPopular_Has_Matching_Properties_with_Result()
        {
            //Arrange
            checkRepository.Setup(repository => repository.GetPopular())
                .Returns(GetSearchSampleData());

            var controllerAction = new MoviesController(checkRepository.Object);

            //Act
            var result = (OkObjectResult)controllerAction.GetPopular();

            result.Value.Should().BeEquivalentTo(
                GetSearchSampleData(),
                options => options.ComparingByMembers<Result>()

                );

        }

        [Fact]
        public void CheckGetPopularCalledOnce()
        {
            //Arrange
            checkRepository.Setup(repository => repository.GetPopular())
                .Returns(new SearchForMovieHelper().GetSearchResults());

            var controllerAction = new MoviesController(checkRepository.Object);

            //Act
            var result = (OkObjectResult)controllerAction.GetPopular();

            //Assert

            checkRepository.Verify(
                service => service.GetPopular(), Times.Once()
                );


        }

        private Result GetSearchSampleData()
        {
            return new SearchForMovieHelper().GetSearchResults();
        }
        private MovieProperties GetSampleData()
        {
            return new GetProperties().GetAllProperties();
        }

        [Fact]
        public void Check_If_SearchForMovie_Has_Matching_Properties_with_Result()
        {
            //Arrange
            checkRepository.Setup(repository => repository.SearchForMovie(It.IsAny<string>()))
                .Returns(GetSearchSampleData());

            var controllerAction = new SearchController(checkRepository.Object);

            //Act
            var result = (OkObjectResult)controllerAction.SearchForMovie(It.IsAny<string>());

            result.Value.Should().BeEquivalentTo(
                GetSearchSampleData(),
                options => options.ComparingByMembers<Result>()

                );

        }

        [Fact]
        public void CheckSearchForMovieCalledOnce()
        {
            //Arrange
            checkRepository.Setup(repository => repository.SearchForMovie(It.IsAny<string>()))
                .Returns(new SearchForMovieHelper().GetSearchResults());

            var controllerAction = new SearchController(checkRepository.Object);

            //Act
            var result = (OkObjectResult)controllerAction.SearchForMovie(It.IsAny<string>());

            //Assert

            checkRepository.Verify(
                service => service.SearchForMovie(It.IsAny<string>()), Times.Once()
                );


        }

        [Fact]
        public void SearchForMovie_NullValue_Test()
        {


            checkRepository.Setup(repository => repository.SearchForMovie(It.IsAny<string>()))
                .Returns((Result)null);

            var controllerAction = new SearchController(checkRepository.Object);

            var result = controllerAction.SearchForMovie(It.IsAny<string>());


            result.Should().BeOfType<NotFoundResult>();


        }

        [Fact]
        public void OnSearchForMovie_SuccessStatusCode()
        {
            //arrange
            checkRepository.Setup(repository => repository.SearchForMovie(It.IsAny<string>()))
                .Returns(new SearchForMovieHelper().GetSearchResults());

            var controllerAction = new SearchController(checkRepository.Object);

            //act
            var result = (OkObjectResult)controllerAction.SearchForMovie(It.IsAny<string>());

            //assert

            result.StatusCode.Should().Be(200);


        }


        private SearchSingle GetSingleSample()
        {
            return new GetSingleSampleData().SearchSingle();
        }



        [Fact]
        public void CheckIfGetSingleHasMatchingPropertieswithResult()
        {
            //Arrange
            checkRepository.Setup(repository => repository.GetSingleMovie(It.IsAny<int>()))
                .Returns(GetSingleSample());

            var controllerAction = new MoviesController(checkRepository.Object);

            //Act
            var result = (OkObjectResult)controllerAction.GetSingle(new int());

            result.Value.Should().BeEquivalentTo(
                GetSingleSample(),
                options => options.ComparingByMembers<SearchSingle>()

              );

        }

        [Fact]
        public void CheckGetSingleCalledOnce()
        {
            //Arrange
            checkRepository.Setup(repository => repository.GetSingleMovie(It.IsAny<int>()))
                .Returns(new GetSingleSampleData().SearchSingle());

            var controllerAction = new MoviesController(checkRepository.Object);

            //Act
            var result = (OkObjectResult)controllerAction.GetSingle(new int());

            //Assert

            checkRepository.Verify(
                service => service.GetSingleMovie(new int()), Times.Once()
                );


        }

        [Fact]
        public void OnGetSingle_SuccessStatusCode()
        {
            //arrange
            checkRepository.Setup(repository => repository.GetSingleMovie(It.IsAny<int>()))
                .Returns(new GetSingleSampleData().SearchSingle());

            var controllerAction = new MoviesController(checkRepository.Object);

            //act
            var result = (OkObjectResult)controllerAction.GetSingle(new int());

            //assert

            result.StatusCode.Should().Be(200);

        }

        [Fact]
        public void GetSingle_NullValue_Test()
        {


            checkRepository.Setup(repository => repository.GetSingleMovie(It.IsAny<int>()))
                .Returns((SearchSingle)null);

            var controllerAction = new MoviesController(checkRepository.Object);

            var result = controllerAction.GetSingle(new int());


            result.Should().BeOfType<NotFoundResult>();


        }

    }

}
