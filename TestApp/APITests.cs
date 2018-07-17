using System;
using AutoMapper;
using System.Collections.Generic;
using System.Net.Http;
using System.Linq;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using HometaskEntity.Controllers;
using HometaskEntity.BLL.Service;
using HometaskEntity.DAL.Contracts;
using HometaskEntity.BLL.Contracts;
using HometaskEntity.DAL.Models;
using HometaskEntity.DAL;
using HometaskEntity.BLL.DTOs;
using HometaskEntity;
using Xunit;
using Moq;

namespace TestApp
{
    public class APITests
    {
        private static AviatorsController controller;
        private static IService<AviatorDTO> service;
        private static IUnitOfWork unit;
        private static AirportContext context;
        public static void Initialize()
        {
            var connectionString = @"Server=(localdb)\mssqllocaldb;Database=AirportDB;Trusted_Connection=True;";
            var options = new DbContextOptionsBuilder<AirportContext>();
            options.UseSqlServer(connectionString);
            context = new AirportContext(options.Options);
            unit = new UnitOfWork(context);
            service = new AviatorService(unit);
            controller = new AviatorsController(service);
            MapperInitializator.Initialize();
        }

        [Fact]
        public void Get_All_Aviators()
        {
            //Arrange
            Initialize();
            //Act
            var result = controller.Get();
            //Assert
            Assert.NotNull(result);
            Assert.NotEmpty(result);
        }

        [Fact]
        public void Get_Aviator_By_Valid_Id()
        {
            //Arrange
            Initialize();
            //Act
            int id = service.GetAll().Last().Id;
            var result = controller.Get(id);
            //Assert
            Assert.Equal(result.Id, id);
        }

        [Fact]
        public void Create_Aviator_By_Custom_Values()
        {
            //Arrange
            Initialize();
            Aviator aviator = new Aviator { Name = "Lord", Surname = "Satanus", Experience = 666, DateOfBirthday = DateTime.MinValue };
            //Act
            controller.Post(Mapper.Map<AviatorDTO>(aviator));
            var result = controller.Get().Where(x => x.Name == "Lord" && x.Surname == "Satanus" && x.Experience == 666);
            //Assert
            Assert.NotNull(result);
        }

        [Fact]
        public void Put_Aviator_By_Id()
        {
            //Arrange
            Initialize();
            Aviator aviator = new Aviator { Name = "Lord", Surname = "Andre", Experience = 666, DateOfBirthday = DateTime.MinValue };
            int id = controller.Get().FirstOrDefault(x => x.Name == "Lord" && x.Surname == "Satanus" && x.Experience == 666).Id;
            //Act
            controller.Put(id, Mapper.Map<AviatorDTO>(aviator));
            var result = controller.Get().Where(x => x.Name == "Lord" && x.Surname == "Andre" && x.Experience == 666);
            //Assert
            Assert.NotNull(result);
        }

        [Fact]
        public void Delete_Aviator_By_Id()
        {
            //Arrange
            Initialize();
            int id = controller.Get().FirstOrDefault().Id;
            //Act
            controller.Delete(id);
            var result = controller.Get().FirstOrDefault(x => x.Id == id);
            //Assert
            Assert.Null(result);
        }
    }
}