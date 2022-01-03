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
    public class ProjectTaskTypeController : ControllerBase
    {  
        // Ici on Type avec la propriété readonly afin de recuperer les methode du Repo et du IMappeer ( AutoMapper ) 
        private readonly IProjectTaskTypeRepo _repository;
        private readonly IMapper _mapper;

        public ProjectTaskTypeController(IProjectTaskTypeRepo repository, IMapper mapper)
        {

            _repository = repository;
            _mapper = mapper;

        }

        [HttpGet]
        public ActionResult<IEnumerable<ProjectTaskTypeReadDto>> GetTypeTask()
        {
            
            var TypeTaskItem = _repository.GetAllType();

            return Ok(_mapper.Map<IEnumerable<ProjectTaskTypeReadDto>>(TypeTaskItem));

        }

        [HttpGet("id", Name = "GetTypeById")]
        public ActionResult<ProjectTaskTypeReadDto> GetTypeById(int id)
        {

            var typeItem = _repository.GetTypeById(id);

            if(typeItem != null)
            {

                return Ok(_mapper.Map<ProjectTaskTypeReadDto>(typeItem));

            }else
            {
                return NotFound();
            }

        }


        [HttpPost]
        public ActionResult<ProjectTaskTypeCreateDto> CreateTypeTask(ProjectTaskTypeCreateDto createTaskTypeDto)
        {

            var ProjectTypeTaskModel = _mapper.Map<ProjectTaskType>(createTaskTypeDto);

            _repository.CreateTypeTask(ProjectTypeTaskModel);
            _repository.SaveChanges();

            var ReadTaskTypeDto = _mapper.Map<ProjectTaskTypeReadDto>(ProjectTypeTaskModel);

            return CreatedAtRoute(nameof(GetTypeById), new { id = ReadTaskTypeDto.id_task_type }, ReadTaskTypeDto); 

        }

        [HttpDelete("{id}")]
        public ActionResult DeleteTypeOfTask(int id)
        {

            var taskTypeItem = _repository.GetTypeById(id);

            if(taskTypeItem != null)
            {
                _repository.DeleteTypeOfTask(taskTypeItem.id_task_type);
                _repository.SaveChanges();
                return Ok();


            }else{
                return NotFound();
            }



        }
    }
}