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
using HometaskEntity.DAL;
using HometaskEntity.DAL.Models;
using HometaskEntity.BLL.DTOs;
using HometaskEntity;
using Xunit;
using Moq;

namespace TestApp
{
    public class DBTests
    {
        private static AirportContext context;
        private static IUnitOfWork unit;
        private static AviatorService service;
        private static AviatorsController controller;

        private static void Initialize()
        {
            var connectionString = @"Server=(localdb)\mssqllocaldb;Database=AirportDB;Trusted_Connection=True;";
            var options = new DbContextOptionsBuilder<AirportContext>();
            options.UseSqlServer(connectionString);
            var contextAirport = new AirportContext(options.Options);
            unit = new UnitOfWork(contextAirport);
            service = new AviatorService(unit);
            MapperInitializator.Initialize();
        }

        [Fact]
        public void Get_Aviator_By_Id_When_Id_Is_Invalid()
        {
            //Arrange
            Initialize();

            
        }
    }
}
