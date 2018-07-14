﻿using System;
using AutoMapper;
using System.Collections.Generic;
using System.Text;
using HometaskEntity.DAL.Models;
using HometaskEntity.BLL.DTOs;

namespace HometaskEntity.BLL.Service
{
    public class MapperService : Profile
    {
        public MapperService()
        {
            new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Aviator, AviatorDTO>().ForAllMembers(opt => opt.Ignore());
            }).CreateMapper();

            new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Crew, CrewDTO>().ForAllMembers(opt => opt.Ignore());
            }).CreateMapper();

            new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Departure, DepartureDTO>().ForAllMembers(opt => opt.Ignore());
            }).CreateMapper();

            new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Flight, FlightDTO>().ForAllMembers(opt => opt.Ignore());
            }).CreateMapper();

            new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Plane, PlaneDTO>().ForAllMembers(opt => opt.Ignore());
            }).CreateMapper();

            new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Stewardess, StewardessDTO>().ForAllMembers(opt => opt.Ignore());
            }).CreateMapper();

            new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Ticket, TicketDTO>().ForAllMembers(opt => opt.Ignore());
            }).CreateMapper();

            new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<TypePlane, TypePlaneDTO>().ForAllMembers(opt => opt.Ignore());
            }).CreateMapper();
       
        }
    }
}
