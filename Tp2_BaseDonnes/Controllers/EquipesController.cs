﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Tp2_BaseDonnes.Data;
using Tp2_BaseDonnes.Models;
using Tp2_BaseDonnes.ViewModels;

namespace Tp2_BaseDonnes.Controllers
{
    public class EquipesController : Controller
    {
        private readonly FootContext _context;

        public EquipesController(FootContext context)
        {
            _context = context;
        }

        // GET: Equipes
        public async Task<IActionResult> Index()
        {
            return _context.Equipes != null ?
                        View(await _context.Equipes.ToListAsync()) :
                        Problem("Entity set 'FootContext.Equipes'  is null.");
        }

        //// GET: Equipes
        //public async Task<IActionResult> Index()
        //{
        //    var viewModel = new DetailedButViewModel
        //    {
        //        StartDate = DateTime.Now,
        //        EndDate = DateTime.Now,
        //        EquipeId = 0,
        //        DetailedButs = new List<DetailedBut>()
        //    };

        //    return View(viewModel);
        //}


        // GET: Equipes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Equipes == null)
            {
                return NotFound();
            }

            var equipe = await _context.Equipes
                .FirstOrDefaultAsync(m => m.EquipeId == id);
            if (equipe == null)
            {
                return NotFound();
            }
         
            // Récupérer le But par son ID
            Equipe? equipe1 = await _context.Equipes.FirstOrDefaultAsync(x => x.EquipeId == id);
            // Définir la requête et les paramètres
            string query = "EXEC dbo.GetMatchsByEquipe @EquipeId";
            List<SqlParameter> parameters = new List<SqlParameter>
            {
                new SqlParameter { ParameterName = "@EquipeId", Value = id }
            };

          

            // Exécuter la procédure stockée et récupérer 
                 List<Match1> Match1 = await _context.Match1s
                .FromSqlRaw(query, parameters.ToArray())
                .ToListAsync();
            DescriptionViewModel vm = new DescriptionViewModel()
            {
                equipe = equipe,
                Match1 = Match1

            };

            /*
               var result = await _context.Equipes
              .FromSqlRaw("EXEC GetButsByEquipe")
              .ToListAsync();

              */
            return View(vm);
        }

        // GET: Equipes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Equipes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("EquipeId,NomEquipe,Pays,CouleursEquipe,DateFondation")]Equipe equipe, DescriptionViewModel imageVM)
        {
          
            return View(equipe);
        }

        // GET: Equipes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Equipes == null)
            {
                return NotFound();
            }

            var equipe = await _context.Equipes.FindAsync(id);
            if (equipe == null)
            {
                return NotFound();
            }
            return View(equipe);
        }

        // POST: Equipes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("EquipeId,NomEquipe,Pays,CouleursEquipe,DateFondation")] Equipe equipe)
        {
            if (id != equipe.EquipeId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(equipe);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EquipeExists(equipe.EquipeId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(equipe);
        }
       /* [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AjoutImageEquipe2( DescriptionViewModel imageVM)
        {
            if (ModelState.IsValid)
            {
                if (imageVM.FormFile != null && imageVM.FormFile.Length >= 0)
                {
                    MemoryStream stream = new MemoryStream();
                    await imageVM.FormFile.CopyToAsync(stream);
                    byte[] fichierImage = stream.ToArray();

                    imageVM.image. = fichierImage;
                }
                _context.Add(imageVM.image);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(imageVM.image);
         
        }
       */

        // GET: Equipes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Equipes == null)
            {
                return NotFound();
            }

            var equipe = await _context.Equipes
                .FirstOrDefaultAsync(m => m.EquipeId == id);
            if (equipe == null)
            {
                return NotFound();
            }

            return View(equipe);
        }

        // POST: Equipes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Equipes == null)
            {
                return Problem("Entity set 'FootContext.Equipes'  is null.");
            }
            var equipe = await _context.Equipes.FindAsync(id);
            if (equipe != null)
            {
                _context.Equipes.Remove(equipe);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EquipeExists(int id)
        {
            return (_context.Equipes?.Any(e => e.EquipeId == id)).GetValueOrDefault();
        }

        public async Task<IActionResult> IndexView()
        {
            return View(await _context.VueStatistiquesJoueurs.ToListAsync());
        }


        public async Task<IActionResult> IndexProcedure(int id)
        {
            // Récupérer le But par son ID
            Equipe? equipe = await _context.Equipes.FirstOrDefaultAsync(x => x.EquipeId == id);
            // Définir la requête et les paramètres
            string query = "EXEC dbo.DecryptCouleurEquipe @EquipeId";
            List<SqlParameter> parameters = new List<SqlParameter>
            {
                new SqlParameter { ParameterName = "@EquipeId", Value = id }
            };

            // Exécuter la procédure stockée et récupérer les descriptions décryptées
            List<CouleurDequipe> couleur = await _context.CouleurDequipes
                .FromSqlRaw(query, parameters.ToArray())
                .ToListAsync();

            // Construire le ViewModel
            DescriptionViewModel vm = new DescriptionViewModel()
            {
                equipe = equipe,
                CouleurDequipe = couleur[0]
            };

            // Envoyer la vue
            return View(vm);
        }

        

    }
}
