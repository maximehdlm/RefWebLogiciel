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
    public class UserController : ControllerBase
    {
        // L'attribut booléen readlony rend l'élément non mutable, l'utilisateur ne peut pas le modifier.
        private readonly IUserRepo _repository;
        private readonly IMapper _mapper;

        public UserController(IUserRepo repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        // GET: api/User
        [HttpGet]

        // On appelle la classe abstraite ActionResult pour avoir un retour
        // puis la classe UserReadDto pour suivre le modèle du dto
        // et on crée la fonction GetAllUsers().
        public ActionResult<IEnumerable<UserReadDto>> GetAllUsers()
        {
            // On applique la méthode GetAllUsers() de la classe UserRepo 
            // et on stocke le résultat dans la variable userItem.
            var userItem = _repository.GetAllUsers();

            // La méthode Ok retourne un statut 200 et la liste de tous les users.
            return Ok(_mapper.Map<IEnumerable<UserReadDto>>(userItem));
        }

        // GET: api/User/5
        [HttpGet("{id}", Name = "GetUserById")]

        // On appelle la classe abstraite ActionResult pour avoir un retour
        // puis la classe UserReadDto pour suivre le modèle du dto
        // et on crée la fonction GetUserById().
        public ActionResult<UserReadDto> GetUserById(int id)
        {
            // On applique la méthode GetUserById() de la classe UserRepo 
            // et on stocke le résultat dans la variable userItem.
            var userItem = _repository.GetUserById(id);

            // On vérifie que userItem ne soit pas vide.
            if (userItem == null)
            {
                return NotFound();
            }

            // La méthode Ok retourne un statut 200 et l'user avec l'id demandée.
            return Ok(_mapper.Map<UserReadDto>(userItem));
        }

        // PUT: api/Users/5
        [HttpPut("{id}", Name = "UpdateUserById")]

        // On appelle la classe abstraite ActionResult pour avoir un retour
        // puis la classe UserUpdateDto pour suivre le modèle du dto
        // et on crée la fonction UpdateUserById().
        public ActionResult<UserUpdateDto> UpdateUserById(int id, UserUpdateDto updateUser)
        {
            // On applique la méthode GetUserById() de la classe UserRepo 
            // et on stocke le résultat dans la variable userItem.
            var userItem = _repository.GetUserById(id);

            // On lui donne la route a suivre pour l'update qui passera par le dto
            // et qui prendra la variable userItem en paramètre.
            _mapper.Map(updateUser, userItem);

            // On vérifie que userItem ne soit pas vide.
            if (userItem == null)
            {
                return NotFound();
            }
                
            // On applique la méthode UpdateUserById de la classe UserRepo.
            _repository.UpdateUserById(id);

            // On sauvegarde les changements.
            _repository.SaveChanges();

            // La CreatedAtRoute crée une route.
            // Cette méthode est destinée à renvoyer un URI
            // à la ressource nouvellement créée lorsqu'on appelle une méthode POST ou PUT pour stocker un nouvel objet.
            return CreatedAtRoute(nameof(GetUserById), new { id = updateUser.id_user }, updateUser);
        }

        // POST: api/User
        [HttpPost]

        // On appelle la classe abstraite ActionResult pour avoir un retour
        // puis la classe UserCreateDto pour suivre le modèle du dto
        // et on crée la fonction CreateUser().
        public ActionResult<UserCreateDto> CreateUser(UserCreateDto createUser)
        {
            // On stocke le modèle User dans la variable userModel.
            var userModel = _mapper.Map<User>(createUser);

            // On applique la méthode CreateUser de la classe UserRepo.
            _repository.CreateUser(userModel);

            // On sauvegarde les changements.
            _repository.SaveChanges();

            // On stocke le résultat de l'user nouvellement crée dans la variable readUser.
            var readUser = _mapper.Map<UserReadDto>(userModel);

            // La CreatedAtRoute crée une route.
            // Cette méthode est destinée à renvoyer un URI
            // à la ressource nouvellement créée lorsqu'on appelle une méthode POST ou PUT pour stocker un nouvel objet.
            return CreatedAtRoute(nameof(GetUserById), new { id = readUser.id_user }, readUser);
        }

        // DELETE: api/User/5
        [HttpDelete("{id}")]

        // On appelle la classe abstraite ActionResult pour avoir un retour
        // puis la classe ReadUser pour suivre le modèle du dto
        // et on crée la fonction DeleByUserId().
        public ActionResult DeleteUserById(int id)
        {
            // On applique la méthode GetUserById() de la classe UserRepo 
            // et on stocke le résultat dans la variable userItem.
            var userItem = _repository.GetUserById(id);

            // On vérifie que userItem ne soit pas vide.
            if (userItem == null)
            {
                return NotFound();
            }

            // On applique la méthode DeleteByUserId de la classe UserRepo.
            _repository.DeleteUserById(userItem.id_user);

            // On sauvegarde les changements.
            _repository.SaveChanges();

            return NoContent();
        }

    }
}