using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using DogGO.Models;
using DogGO.Controllers;
using DogGO.Repositories;
using DogGO.Models.ViewModels;
using System;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;

namespace DogGO.Controllers
{
    public class WalkersController : Controller
    {
        private readonly IWalkerRepository _walkerRepo;
        private readonly IWalkRepository _walkRepo;
        private readonly IOwnerRepository _ownerRepo;
        private readonly IDogRepository _dogRepo;
        public WalkersController(IWalkerRepository walkerRepository, IWalkRepository walkRepo, IOwnerRepository ownerRepo, IDogRepository dogRepo)
        {
            _walkerRepo = walkerRepository;
            _walkRepo = walkRepo;
            _ownerRepo = ownerRepo;
            _dogRepo = dogRepo;
        }

        // GET: Walkers
        public ActionResult Index()
        {
            try
            {
                int currentUserId = GetCurrentUserId();

                Owner owner = _ownerRepo.GetOwnerById(currentUserId);
                List<Walker> walkersInOwnersNeighborhood = _walkerRepo.GetWalkersInNeighborhood(owner.NeighborhoodId);
                return View(walkersInOwnersNeighborhood);
            }
            catch(Exception)
            {
                List<Walker> walkers = _walkerRepo.GetAllWalkers();
                return View(walkers);
            }
        }

        // GET: WalkersController/Details/5
        public ActionResult Details(int id)
        {
            Walker walker = _walkerRepo.GetWalkerById(id);

            List<Walk> walks = _walkRepo.GetWalksByWalkerId(walker.Id); 

            WalkerProfileViewModel vm = new WalkerProfileViewModel()
            {
                Walker = walker,
                Walks = walks
            };
            return View(vm);
        }

        // GET: WalkersController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: WalkersController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: WalkersController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: WalkersController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: WalkersController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: WalkersController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        private int GetCurrentUserId()
        {
            string id = User.FindFirstValue(ClaimTypes.NameIdentifier);
            return int.Parse(id);
        }

    }
}
