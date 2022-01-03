using System;
using System.Collections.Generic;
using RefWebLogiciel.Models;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace RefWebLogiciel.Data
{
        //Je definie l'interface IProjectRepo avec ses méthodes, proprietés, indexeurs et évenements à implémenter
    public interface IProjectTypeRepo
    {
         //SaveChanges() permet de sauvegarder les changements dans la base de données
        bool SaveChanges();
        //IEnumerable me permet de retouner une liste
        IEnumerable<ProjectType> GetAllProjectTypes(); //pour chercher une liste de type de projets
        ProjectType GetProjectTypeById(int projectTypeId); //pour récuperer un type de projet par l'id 
        void CreateProjectType(ProjectType projectType); //pour créer un type projet
        void UpdateProjectType(int projectId); //pour mettre à jour un type de projet
        void DeleteProjectTypeById(int projectTypeId);//pour supprimer un type de projet
    }
}