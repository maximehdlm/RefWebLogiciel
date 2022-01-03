using RefWebLogiciel.Data;
using System.Linq;
using System;
using System.Collections.Generic;
using RefWebLogiciel.Models;
using Microsoft.EntityFrameworkCore;
using System.IO;
using Newtonsoft.Json.Linq;

namespace RefWebLogiciel.Data
{
    public class ProjectTaskRepo : IProjectTaskRepo
    {

        private readonly AppDbContext _context;

        public ProjectTaskRepo(AppDbContext context)
        {
        //Ici on stock dans une variable le context de la Bdd
                _context = context;
  
        }
        
        public void CreateTask(ProjectTask task)
        {
            // Si la taches n'est pas null alors tu ajoutes une tache par rapport au context et au model
            // et tu enregistres.
            if(task != null)
            {

                _context.task.Add(task);
                _context.SaveChanges();

            }else{
                throw new ArgumentException(nameof(task));
            }

        }

        public IEnumerable<ProjectTask> GetAllTasks()
        {
            // On lui dit qu'il nous retourne une liste de taches par rapport au model et au context.
            return _context.task.ToList();

        }

        public ProjectTask GetTaskById(int id)
        {
            // On lui dit qu'il nous retourne une taches en fonction de son ID
            return _context.task.Find(id);

        }

        public void UpdateTask(int id)
        {

                var taskItem = _context.task.Find(id);

                // On indique au contexte d’attacher l’entité et de définir son état sur modifié ( et une fois cela fait on va pouvoir invoqué la methode SaveChanges)
                _context.Entry(taskItem).State = EntityState.Modified;

        }

        public void DeleteTask(int id)
        {
            // On indique au contexte d'attacher l'entité par Id et de definir son état de Remove ( suppression )
            var task = _context.task.Find(id);

              if(task != null)
            {

                _context.task.Remove(task);

            }

        }

        // Cette méthode indique au contexte d'enregistré les changements.
        public bool SaveChanges()
        {
            return (_context.SaveChanges() >= 0);
        }

        public void DispatchTask()
        {
            var dispatchRequeste = "UPDATE task INNER JOIN user ON user.user_xp = task.task_xp AND user.fk_id_specialisation = task.fk_id_task_type OR user.user_xp > task.task_xp AND task.fk_id_user = NULL SET fk_id_user= user.id_user;";

            _context.task.FromSqlRaw(dispatchRequeste);

            Console.WriteLine("Dispatch ok : " + DateTime.Now);
        }


         public void AcceptProject()
        {
            /** Lecture du fichier json, on le parse en tant que tableau,
                on boucle dessus pour retourner les valeurs obtenues en string
                puis on les parse en tant qu'objet.
                
                Ceci fait ,on declare un nouvel objet ProjectTask et on le met
                en paramètre de la méthode createTask*/

                //Chemin du fichier json
                string path = @"./taskList.json"; 

                JArray array = JArray.Parse(File.ReadAllText(path));
                foreach(object a in array){
                    dynamic data = JObject.Parse(a.ToString());
                    var Task = new ProjectTask(){
                        task_name =  data.task_name,
                        task_description = data.task_description,
                        task_time = data.task_time,
                        task_status = data.task_status,
                        task_xp = data.task_xp,
                        fk_id_task_type = data.fk_id_task_type
                    };
                    CreateTask(Task);
                }
        }
    }
}