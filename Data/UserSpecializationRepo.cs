using System.Collections.Generic;
using RefWebLogiciel.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System;


namespace RefWebLogiciel.Data
{
    public class UserSpecializationRepo : IUserSpecializationRepo
    {
        // L'attribut booléen readlony rend l'élément non mutable, l'utilisateur ne peut pas le modifier.
        private readonly AppDbContext _context;

        public UserSpecializationRepo(AppDbContext context)
        {
            _context = context;
        }

        public void CreateUserSpecialization(UserSpecialization userSpecialization)
        {
            // On vérifie que les données lors de la création d'une spécialisation ne soient pas nulles.
            if(userSpecialization != null)
            {
                // La méthode Add() ajoute un objet.
                _context.UserSpecialization.Add(userSpecialization);
            }
            else
            {
                // Sinon on retourne un message d'erreur.
                throw new ArgumentNullException(nameof(userSpecialization));
            }
        }
        public IEnumerable<UserSpecialization> GetAllUserSpecializations()
        {
            // La méthode ToList() crée une liste des données.
            return _context.UserSpecialization.ToList();
        }

        public UserSpecialization GetUserSpecializationById(int id)
        {
            // La méthode Find() recherche l'élément correspondant au paramètre spécifié.
            // Et on le retourne.
            return _context.UserSpecialization.Find(id);
        }

        public void UpdateUserSpecializationById(int id)
        {
            // On stocke la spécialisation recherchée avec la méthode Find() dans la variable userItem.
            var specializationItem = _context.UserSpecialization.Find(id);

            // La méthode Entry() permet un accés aux données de specializationItem et permet la modification de ces données.
            // Puis on dit au context que l'entité a été modifiée.
            _context.Entry(specializationItem).State = EntityState.Modified;
        }

        public void DeleteUserSpecializationById(int id)
        {
            // La méthode Find() recherche l'élément correspondant au paramètre spécifié.
            // Et on le retourne.
            var specializationItem = _context.UserSpecialization.Find(id);

            // On vérifie que l'élément ne soit pas nul.
            if (specializationItem != null)
            {
                // On supprime avec la méthode Remove().
                _context.UserSpecialization.Remove(specializationItem);       
            }

        }

        // La méthode SaveChanges permet de sauvegarer l'état des entités.
        public bool SaveChanges()
        {
            return (_context.SaveChanges() >=0);
        }
    }
}