using System;
using System.Collections.Generic;
using RefWebLogiciel.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;


namespace RefWebLogiciel.Data
{
    public interface IProjectTaskRepo
    {
        // Dans l'interface nous faisons le lien entre le controller et les methdoes du repo
        bool SaveChanges();

        IEnumerable<ProjectTask> GetAllTasks();

        ProjectTask GetTaskById(int id);

        void CreateTask(ProjectTask task);

        void DeleteTask(int id);

        void UpdateTask(int id);

        void DispatchTask();

        void AcceptProject();
    }
}