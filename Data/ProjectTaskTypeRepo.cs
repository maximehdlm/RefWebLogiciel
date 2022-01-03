using RefWebLogiciel.Dtos;
using RefWebLogiciel.Data;
using System.Linq;
using System;
using System.Collections.Generic;
using RefWebLogiciel.Models;
using Microsoft.EntityFrameworkCore; 
using AutoMapper;



namespace RefWebLogiciel.Data
{
    public class ProjectTaskTypeRepo : IProjectTaskTypeRepo
    {
        
        private readonly AppDbContext _context;

        public ProjectTaskTypeRepo(AppDbContext context)
        {
          
                _context = context;
  
        }

        public void CreateTypeTask(ProjectTaskType taskType)
        {

            if(taskType != null)
            {

                _context.task_type.Add(taskType);
                _context.SaveChanges();

            }else
                {

                    throw new ArgumentException(nameof(taskType));
                    
                }

        }

        public IEnumerable<ProjectTaskType> GetAllType()
        {

            return _context.task_type.ToList();

        }

        public ProjectTaskType GetTypeById(int id)
        {
            return _context.task_type.Find(id);
        }

        public void DeleteTypeOfTask(int id)
        {
            // Tout d'abord on 
            var taskType = _context.task_type.Find(id);

              if(taskType != null)
            {

                _context.task_type.Remove(taskType);

            }

        }

              public bool SaveChanges()
        {

            return (_context.SaveChanges() >= 0);

        }

    }
}