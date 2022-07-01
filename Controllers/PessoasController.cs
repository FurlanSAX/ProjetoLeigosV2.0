using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Data;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    //Só apos autorização tem acesso a todos os metodos
    [Authorize]
    public class PessoasController : Controller
    {
        private readonly ApplicationDbContext _context;

        public PessoasController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Pessoas
        public async Task<IActionResult> Index()
        {
            //AsNoTracking não trackear???
            //Where... a pessoa só vê os propios servicos, tirando Where(u=> u.IdPessoa == User.Identity.Name) todos os serviços são visiveis a todos
            return _context.Pessoa != null ? 
                          View(await _context.Pessoa.AsNoTracking().Where(p => p.emailPessoa == User.Identity.Name).ToListAsync()) :
                          Problem("Entity set 'ApplicationDbContext.Pessoa'  is null.");
        }

        // GET: Pessoas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Pessoa == null)
            {
                return NotFound();
            }

            var pessoa = await _context.Pessoa
                .FirstOrDefaultAsync(m => m.idPessoa == id);
            if (pessoa == null)
            {
                return NotFound();
            }

            return View(pessoa);
        }

        // GET: Pessoas/Create
        public IActionResult Create()
        {
            ViewBag.End = new SelectList(_context.Endereco, "idEnd", "rua");
            ViewBag.Gen = new SelectList(_context.Genero, "idGenero", "GeneroNome");

            return View();
        }

        // POST: Pessoas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("idPessoa,nomePessoa,cpfPessoa,rgPessoa,telefonePessoa,senhaPessoa,idGenero,idEndereco")] Pessoa pessoa)
        {
            //pega o email da possoa logado
            pessoa.emailPessoa = User.Identity.Name;

            if (ModelState.IsValid)
            {
                _context.Add(pessoa);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(pessoa);
        }

        // GET: Pessoas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            ViewBag.End = new SelectList(_context.Endereco, "idEnd", "rua");
            ViewBag.Gen = new SelectList(_context.Genero, "idGenero", "GeneroNome");

            if (id == null || _context.Pessoa == null)
            {
                return NotFound();
            }

            var pessoa = await _context.Pessoa.FindAsync(id);
            if (pessoa == null)
            {
                return NotFound();
            }

            //usuario só tem acesso aos propios servicos cadastrados
            if(pessoa.emailPessoa != User.Identity.Name)
            {
                return NotFound();
            }

            return View(pessoa);
        }

        // POST: Pessoas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("idPessoa,nomePessoa,cpfPessoa,rgPessoa,telefonePessoa,emailPessoa,senhaPessoa,idGenero,idEndereco,dataCadastroPessoa")] Pessoa pessoa)
        {
            if (id != pessoa.idPessoa)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    //pode atualizar tudp menos o propio email
                    pessoa.emailPessoa = User.Identity.Name;
                    _context.Update(pessoa);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PessoaExists(pessoa.idPessoa))
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
            return View(pessoa);
        }

        // GET: Pessoas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Pessoa == null)
            {
                return NotFound();
            }

            var pessoa = await _context.Pessoa
                .FirstOrDefaultAsync(m => m.idPessoa == id);
            if (pessoa == null)
            {
                return NotFound();
            }

            //só pode apagar o propio cadastro
            if(pessoa.emailPessoa != User.Identity.Name)
            {
                return NotFound();
            }

            return View(pessoa);
        }

        // POST: Pessoas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Pessoa == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Pessoa'  is null.");
            }
            var pessoa = await _context.Pessoa.FindAsync(id);
            if (pessoa != null)
            {
                _context.Pessoa.Remove(pessoa);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PessoaExists(int id)
        {
          return (_context.Pessoa?.Any(e => e.idPessoa == id)).GetValueOrDefault();
        }
    }
}
