using System.Collections.Generic;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using RefWebLogiciel.Models;
using RefWebLogiciel.Data;
using RefWebLogiciel.Dtos;

namespace RefWebLogiciel.Controllers
{
    // L'attribut ApiController permet de bénéficier de certaines conventions
    // et évite la duplication de code concernant la validation des données, il la gère automatiquement.
    [ApiController]
    [Route("[controller]")]
    public class UserSpecializationController : ControllerBase
    {
        // L'attribut booléen readlony rend l'élément non mutable, l'utilisateur ne peut pas le modifier.
        private readonly IUserSpecializationRepo _repository;
        private readonly IMapper _mapper;
        public UserSpecializationController(IUserSpecializationRepo repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        // GET: api/UserSpecialization
        [HttpGet]

        // On appelle la classe abstraite ActionResult pour avoir un retour
        // puis la classe UserSpecializationReadDto pour suivre le modèle du dto
        // et on crée la fonction GetAllUserSpecialization().
        public ActionResult<IEnumerable<UserSpecializationReadDto>> GetAllUserSpecializations()
        {
            // On applique la méthode GetAllUserSpecializations() de la classe UserSpecializationRepo 
            // et on stocke le résultat dans la variable specializationItem.
            var UserSpecializationItem = _repository.GetAllUserSpecializations();

            // La méthode Ok retourne un statut 200 et la liste de toutes les user spécialisations.
            return Ok(_mapper.Map<IEnumerable<UserSpecializationReadDto>>(UserSpecializationItem));
        }

        // GET: api/UserSpecialization/5
        [HttpGet("{id}", Name = "GetUserSpecializationById")]

        // On appelle la classe abstraite ActionResult pour avoir un retour
        // puis la classe UserSpecializationReadDto pour suivre le modèle du dto
        // et on crée la fonction GetUserSpecializationById().
        public ActionResult<UserSpecializationReadDto> GetUserSpecializationById(int id)
        {
            // On applique la méthode GetUserSpecializationById() de la classe UserSpecializationRepo 
            // et on stocke le résultat dans la variable userSpecializationItem.
            var userSpecializationItem = _repository.GetUserSpecializationById(id);

            // On vérifie que userSpecializationItem ne soit pas vide.
            if (userSpecializationItem == null)
            {
                return NotFound();
            }

            // La méthode Ok retourne un statut 200 et la spécialisation avec l'id demandée.
            return Ok(_mapper.Map<UserSpecializationReadDto>(userSpecializationItem));
        }

        // PUT: api/UserSpecializations/5
        [HttpPut("{id}", Name = "UpdateUserSpecializationById")]

        // On appelle la classe abstraite ActionResult pour avoir un retour
        // puis la classe UserSpecializationUpdateDto pour suivre le modèle du dto
        // et on crée la fonction UpdateUserSpecializationById().
        public ActionResult<UserSpecializationUpdateDto> UpdateUserSpecializationById(int id, UserSpecializationUpdateDto updateUserSpecialization)
        {
            // On applique la méthode GetUserSpecializationById() de la classe UserSpecializationRepo 
            // et on stocke le résultat dans la variable userSpecializationItem.
            var userSpecializationItem = _repository.GetUserSpecializationById(id);

            // On lui donne la route a suivre pour l'update qui passera par le dto
            // et qui prendra la variable userSpecializationItem en paramètre.
            _mapper.Map(updateUserSpecialization, userSpecializationItem);

            // On vérifie que userSpecializationItem ne soit pas vide.
            if (userSpecializationItem == null)
            {
                return NotFound();
            }
                
            // On applique la méthode UpdateUserSpecializationById de la classe UserSpecializationRepo.
            _repository.UpdateUserSpecializationById(id);

            // On sauvegarde les changements.
            _repository.SaveChanges();

            // La CreatedAtRoute crée une route.
            // Cette méthode est destinée à renvoyer un URI
            // à la ressource nouvellement créée lorsqu'on appelle une méthode POST ou PUT pour stocker un nouvel objet.
            return CreatedAtRoute(nameof(GetUserSpecializationById), new { id = updateUserSpecialization.id_specialization }, updateUserSpecialization);
        }

        // POST: api/UserSpecialization
        [HttpPost]

        // On appelle la classe abstraite ActionResult pour avoir un retour
        // puis la classe UserSpecializationCreateDto pour suivre le modèle du dto
        // et on crée la fonction CreateUserSpecialization().
        public ActionResult<UserSpecializationCreateDto> CreateUserSpecialization(UserSpecializationCreateDto createUserSpecialization)
        {
            // On stocke le modèle UserSpecialization dans la variable userSpecializationModel.
            var userSpecializationModel = _mapper.Map<UserSpecialization>(createUserSpecialization);

            // On applique la méthode CreateUserSpecialization de la classe UserSpecializationRepo.
            _repository.CreateUserSpecialization(userSpecializationModel);

            // On sauvegarde les changements.
            _repository.SaveChanges();

            // On stocke le résultat de la UserSpecialization nouvellement crée dans la variable readUserSpecialization.
            var readUserSpecialization = _mapper.Map<UserSpecializationReadDto>(userSpecializationModel);

            // La CreatedAtRoute crée une route.
            // Cette méthode est destinée à renvoyer un URI
            // à la ressource nouvellement créée lorsqu'on appelle une méthode POST ou PUT pour stocker un nouvel objet.
            return CreatedAtRoute(nameof(GetUserSpecializationById), new { id = readUserSpecialization.id_specialization }, readUserSpecialization);
        }

        // DELETE: api/UserSpecialization/5
        [HttpDelete("{id}")]

        // On appelle la classe abstraite ActionResult pour avoir un retour
        // puis la classe UserSpecializationReadDto pour suivre le modèle du dto
        // et on crée la fonction DeleBySpecializationId().
        public ActionResult DeleteUserSpecializationById(int id)
        {
            // On applique la méthode GetUserSpecializationById() de la classe UserSpecializationRepo 
            // et on stocke le résultat dans la variable userSpecializationItem.
            var userSpecializationItem = _repository.GetUserSpecializationById(id);

            // On vérifie que specializationItem ne soit pas vide.
            if (userSpecializationItem == null)
            {
                return NotFound();
            }

            // On applique la méthode DeleteByUserSpecializationId de la classe UserSpecializationRepo.
            _repository.DeleteUserSpecializationById(userSpecializationItem.id_specialization);
            
            // On sauvegarde les changements.
            _repository.SaveChanges();

            return NoContent();
        }
    }
}