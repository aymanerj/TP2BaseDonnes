using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Tp2_BaseDonnes.Data;
using Tp2_BaseDonnes.Models;

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

            return View(equipe);
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
        public async Task<IActionResult> Create([Bind("EquipeId,NomEquipe,Pays,CouleursEquipe,DateFondation")] Equipe equipe)
        {
            if (ModelState.IsValid)
            {
                _context.Add(equipe);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
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
            But? But = await _context.Buts.FirstOrDefaultAsync(x => x.Courriel == courriel);
            if (But != null)

                // Récupérer les cartes bancaires
                string query = "EXEC DecryptDescriptionBut @ButId";
            List<SqlParameter> parameters = new List<SqlParameter>
                    {
                        new SqlParameter{ParameterName = "@ClientID", Value = client.ClientId}
                    };

            List<CarteBancaireEnClair> cartes = await _context.CarteBancaireEnClairs.FromSqlRaw(query, parameters.ToArray()).ToListAsync();

            // Construire le ViewModel
            ProfilClientViewModel vm = new ProfilClientViewModel()
            {
                Client = client,
                Cartes = cartes
            };

            // Envoyez la vue
            return View(vm);



        }
    }
}