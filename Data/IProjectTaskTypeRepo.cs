using System;
using System.Collections.Generic;
using RefWebLogiciel.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using AutoMapper;

namespace RefWebLogiciel.Data
{
    public interface IProjectTaskTypeRepo
    {
          bool SaveChanges();

        IEnumerable<ProjectTaskType> GetAllType();

        ProjectTaskType GetTypeById(int id);

        void CreateTypeTask(ProjectTaskType taskType);

        void DeleteTypeOfTask(int id);



    }
}