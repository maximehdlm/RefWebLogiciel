using RefWebLogiciel.Data;
using Microsoft.EntityFrameworkCore;
using AutoMapper;
using RefWebLogiciel.Dtos;
using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using RefWebLogiciel.Models;


namespace RefWebLogiciel.Controllers
{
    [ApiController]
    // Nous definissons la route du controller.
    [Route("[controller]")]
    public class ProjectTaskController : ControllerBase
    {
        // Ici on Type avec la propriété readonly afin de recuperer les methode du Repo et du IMappeer ( AutoMapper ) 
        private readonly IProjectTaskRepo _repository;
        private readonly IMapper _mapper;

        public ProjectTaskController(IProjectTaskRepo repository, IMapper mapper)
        {

            _repository = repository;
            _mapper = mapper;

        }

        // Ici nous requettons une liste de taches en passant par le DTO qui nous sert de schema pour lire les taches.
        [HttpGet]
        public ActionResult<IEnumerable<ProjectTaskReadDto>> GetTasks()
        {
            // On initialise une variable qui recupere toute les taches par la methode GetAllTask (typage) en passant par le repo.
            var taskItem = _repository.GetAllTasks();
            // On retourne un status 200 avec la liste des taches par l'AutoMapper.
            return Ok(_mapper.Map<IEnumerable<ProjectTaskReadDto>>(taskItem));

        }   


        // Ici on Get une tache par l'ID.
        [HttpGet("id", Name = "GetTaskById")]
        public ActionResult<ProjectTaskReadDto> GetTaskById(int id)
        {
            // On initalise une variage qui recupere depuis le repo la methode GetTaskById
            var taskItem = _repository.GetTaskById(id);
            // Je lui donne une condition que si la tache par Id n'est pas null alors tu retournes un status 200 avec la tache
            // en question grace a l'autoMapper.
            if(taskItem != null){
                return Ok(_mapper.Map<ProjectTaskReadDto>(taskItem));
            }else{
                return NotFound();
            }

        }

        // Ici on requete avec le methode Post ( HttpPost ) pour envoyer les données afin de créé une nouvelle tache
        // En passant par schema du Dto
        [HttpPost]
        public ActionResult<ProjectTaskReadDto> CreateTask(ProjectTaskCreateDto taskCreateDto){

            // On initialise une variable ou l'on stock le model de creation de la tache
            var taskModel = _mapper.Map<ProjectTask>(taskCreateDto);
            // Ici on recupere la méthode du repo CreateTask.
            _repository.CreateTask(taskModel);
            // On recupere la methode SaveChanges du repo.
            _repository.SaveChanges();
            // On stock dans une variable le schema pour lire la nouvelle tache enregistré précedemment.
            var projectTaskReadDto = _mapper.Map<ProjectTaskReadDto>(taskModel);
            // La CreatedAtRoute méthode est destinée à renvoyer un URI à la ressource nouvellement créée lorsque vous appelez une méthode POST pour stocker un nouvel objet.
            return CreatedAtRoute(nameof(GetTaskById), new { id = projectTaskReadDto.id_task }, projectTaskReadDto); 

        }
        // Ici je requete avec la methode Put avec en parametre la route 'update/id'
       [HttpPut("updapte/id", Name = "UpdateTask")]
        public ActionResult<ProjectTaskReadDto> UpdateTask(int id, ProjectTaskUpdateDto taskUpdateDto)
        {
            // On initalise une variage qui recupere depuis le repo la methode GetTaskById
            var taskModelFromRepo = _repository.GetTaskById(id);
            // On lui donne la route a suivre pour l'update qui passera par le dto de l'update et passera par la methode GetTaskById du repo
            _mapper.Map(taskUpdateDto, taskModelFromRepo);

            // Condition que sir taskModelFromRepo est null alors une erreur 400
            if (taskModelFromRepo == null )
            {
                return NotFound();
            }
            // On recupere la methode UpdateTask du repo
            _repository.UpdateTask(id);
            // On recupere la methode SaveChanges du repo
            _repository.SaveChanges();
            // La CreatedAtRoute méthode est destinée à renvoyer un URI à la ressource nouvellement créée lorsque vous appelez une méthode POST pour stocker un nouvel objet.
            return CreatedAtRoute(nameof(GetTaskById), new { id = taskUpdateDto.id_task }, taskUpdateDto);
            
        }

        [HttpPatch("updapte/taskstatus/id", Name = "UpdateTaskStatus")]
        public ActionResult<ProjectTaskReadDto> UpdateTaskStatus(int id, ProjectTaskStatusUpdateDto taskUpdateDto)
        {
            // On initalise une variage qui recupere depuis le repo la methode GetTaskById
            var taskModelFromRepo = _repository.GetTaskById(id);
            // On lui donne la route a suivre pour l'update qui passera par le dto de l'update et passera par la methode GetTaskById du repo
            _mapper.Map(taskUpdateDto, taskModelFromRepo);

            // Condition que sir taskModelFromRepo est null alors une erreur 400
            if (taskModelFromRepo == null )
            {
                return NotFound();
            }
            // On recupere la methode UpdateTask du repo
            _repository.UpdateTask(id);
            // On recupere la methode SaveChanges du repo
            _repository.SaveChanges();
            // La CreatedAtRoute méthode est destinée à renvoyer un URI à la ressource nouvellement créée lorsque vous appelez une méthode POST pour stocker un nouvel objet.
            return CreatedAtRoute(nameof(GetTaskById), new { id = taskUpdateDto.id_task }, taskUpdateDto);
            
        }

        // On requete avec le methode Delete avec en paramatre l'Id
        [HttpDelete("{id}")]
        public ActionResult DeleteTask(int id)
        {
            // On stock dans taskItem la tache a delete par Id avec la methode du repo GetTaskById.
            var taskItem = _repository.GetTaskById(id);
            // Si taskItem n'est pas null alors tu delete la task.
            if(taskItem != null)
            {
                _repository.DeleteTask(taskItem.id_task);
                _repository.SaveChanges();
                return Ok();


            }else{
                return NotFound();
            }

        }

         [HttpPut("updapte/dispatch", Name = "DispatchTask")]
        public ActionResult<ProjectTaskReadDto> DispatchTask()
        {
            _repository.DispatchTask();
            _repository.SaveChanges();
    
            return Ok();   
            
        }

        //Requete du Template pour créer une liste de taches
        [HttpPost("create/tasklist", Name = "AcceptProject")]
        public ActionResult<ProjectTaskCreateDto> AcceptProject()
        {
            _repository.AcceptProject();
            _repository.SaveChanges();

            return Ok(); 

        }


    }

}