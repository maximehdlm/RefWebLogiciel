using System;
using System.Collections.Generic;
using RefWebLogiciel.Models;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;


namespace RefWebLogiciel.Data
{
    //Je definie l'interface IProjectRepo avec ses méthodes, proprietés, indexeurs et évenements à implémenter
    public interface IProjectRepo
    {
        //SaveChanges() permet de sauvegarder les changements dans la base de données
        bool SaveChanges();
        //IEnumerable me permet de retouner une liste
        IEnumerable<Project> GetAllProjects(); //pour chercher une liste de tache
        Project GetProjectById(int projectId); //pour récuperer un projet par l'id 
        void CreateProject(Project project); //pour créer un projet
        void UpdateProject(int projectId); //pour mettre à jour un projet
        void DeleteProjectById(int projectId);//pour supprimer un projet
    }
}
