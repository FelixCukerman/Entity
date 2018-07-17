using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using HometaskEntity.BLL.Service;
using HometaskEntity.DAL.Contracts;
using HometaskEntity.DAL;
using HometaskEntity.BLL.DTOs;
using HometaskEntity;
using Xunit;

namespace TestApp
{
    public class DBTests
    {
        private static AirportContext context;
        private static IUnitOfWork unit;
        private static AviatorService service;

        private static void Initialize()
        {
            var connectionString = @"Server=(localdb)\mssqllocaldb;Database=AirportDB;Trusted_Connection=True;";
            var options = new DbContextOptionsBuilder<AirportContext>();
            options.UseSqlServer(connectionString);
            context = new AirportContext(options.Options);
            unit = new UnitOfWork(context);
            service = new AviatorService(unit);
            MapperInitializator.Initialize();
        }

        [Fact]
        public void Get_Aviator_By_Id_When_Id_Is_Invalid()
        {
            //Arrange
            Initialize();
            //Act
            Action result = () =>
            {
                service.GetById(-1);
            };
            var ex = Record.Exception(result);
            //Assert
            Assert.IsType<Exception>(ex);
        }

        [Fact]
        public void Get_Aviator_By_Id_When_Id_Is_Valid()
        {
            //Arrange
            Initialize();
            //Act
            var result = service.GetAll().FirstOrDefault();
            //Assert
            Assert.IsType<AviatorDTO>(result);
        }

        [Fact]
        public void Create_Equal_Aviator()
        {
            //Arrange
            Initialize();
            var aviator = new AviatorDTO { Name = "Alex", Surname = "Harper", Experience = 3, DateOfBirthday = DateTime.MinValue };
            //Act
            Action result = () =>
            {
                service.Create(aviator);
            };
            var ex = Record.Exception(result);
            //Assert
            Assert.IsType<Exception>(ex);
        }

        [Fact]
        public void Create_Aviator_When_Value_Is_Null()
        {
            //Arrange
            Initialize();
            //Act
            Action result = () =>
            {
                service.Create(null);
            };
            var ex = Record.Exception(result);
            //Assert
            Assert.IsType<Exception>(ex);
        }

        [Fact]
        public void Update_Aviator_When_Id_Is_Invalid_And_Model_Is_Null()
        {
            //Arrange
            Initialize();
            //Act
            Action result = () =>
            {
                service.Update(-1, null);
            };
            var ex = Record.Exception(result);
            //Assert
            Assert.IsType<Exception>(ex);
        }

        [Fact]
        public void Update_Aviator_To_Equal_Value()
        {
            //Arrange
            Initialize();
            var aviator = service.GetAll().FirstOrDefault();
            int id = service.GetAll().Last().Id;
            //Act
            Action result = () =>
            {
                service.Update(id, aviator);
            };
            var ex = Record.Exception(result);
            //Assert
            Assert.IsType<Exception>(ex);
        }

        [Fact]
        public void Update_Aviator_To_Current_Value()
        {
            //Arrange
            Initialize();
            var aviator = service.GetAll().FirstOrDefault();
            int id = aviator.Id;
            //Act
            Action result = () =>
            {
                service.Update(id, aviator);
            };
            var ex = Record.Exception(result);
            //Assert
            Assert.IsType<Exception>(ex);
        }

        [Fact]
        public void Delete_Aviator_By_Id_When_Id_Is_Valid()
        {
            //Arrange
            Initialize();
            var id = service.GetAll().FirstOrDefault().Id;
            //Act
            service.Delete(id);
            //Assert
            Assert.IsType<Exception>(new Exception("Bad request"));
        }

        [Fact]
        public void Delete_Aviator_By_Id_When_Id_Is_Invalid()
        {
            //Arrange
            Initialize();
            var id = service.GetAll().Last().Id + 1;
            //Act
            service.Delete(id);
            //Assert
            Assert.IsType<Exception>(new Exception("Bad request"));
        }

        [Fact]
        public void Get_All()
        {
            //Arrange
            Initialize();
            //Act
            var items = service.GetAll();
            //Assert
            Assert.NotEmpty(items);
        }
    }
}
